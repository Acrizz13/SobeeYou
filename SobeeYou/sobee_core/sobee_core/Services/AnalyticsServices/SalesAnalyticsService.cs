using Microsoft.EntityFrameworkCore;
using sobee_core.Data;
using sobee_core.Models.AnalyticsModels;
using sobee_core.Models.AzureModels;

namespace sobee_core.Services.AnalyticsServices {
    public class SalesAnalyticsService : ISalesAnalyticsService {
        private readonly SobeecoredbContext _context;

        public SalesAnalyticsService(SobeecoredbContext context) {
            _context = context;
        }


        public List<dynamic> GetSalesTrends(List<Torder> filteredOrders, int? year, int? month) {
            var salesTrends = new List<SalesTrendData>();

            if (year.HasValue && month.HasValue) {
                // Generate all days in the selected month
                int daysInMonth = DateTime.DaysInMonth(year.Value, month.Value);
                var datesInMonth = Enumerable.Range(1, daysInMonth)
                    .Select(day => new DateTime(year.Value, month.Value, day))
                    .ToList();

                // Join the generated date range with the filtered orders
                salesTrends = datesInMonth
                    .GroupJoin(
                        filteredOrders.Where(o => o.DtmOrderDate.HasValue),
                        date => date,
                        order => order.DtmOrderDate.Value.Date,
                        (date, orders) => new SalesTrendData {
                            Date = date,
                            TotalSales = orders.Sum(o => o.DecTotalAmount)
                        }
                    )
                    .OrderBy(st => st.Date)
                    .ToList();
            }
            else {
                // If no month is selected, use the existing code
                salesTrends = filteredOrders
                    .Where(o => o.DtmOrderDate.HasValue)
                    .GroupBy(o => o.DtmOrderDate.Value.Date)
                    .Select(g => new SalesTrendData {
                        Date = g.Key,
                        TotalSales = g.Sum(o => o.DecTotalAmount)
                    })
                    .OrderBy(st => st.Date)
                    .ToList();

                if (year.HasValue) {
                    salesTrends = salesTrends
                        .Where(st => st.Date.Year == year.Value)
                        .GroupBy(st => new { st.Date.Year, st.Date.Month })
                        .Select(g => new SalesTrendData {
                            Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                            TotalSales = g.Sum(st => st.TotalSales)
                        })
                        .Distinct()
                        .OrderBy(st => st.Date)
                        .ToList();
                }
            }

            return salesTrends.Cast<dynamic>().ToList();
        }

        public List<dynamic> GetTopSellingProducts(IQueryable<Torder> orders) {
            var topSellingProducts = orders
                .SelectMany(o => o.TorderItems)
                .GroupBy(oi => oi.IntProductId)
                .Select(g => new {
                    ProductID = g.Key,
                    TotalQuantity = g.Sum(oi => oi.IntQuantity)
                })
                .OrderByDescending(tp => tp.TotalQuantity)
                .Take(10)
                .Join(_context.Tproducts, tp => tp.ProductID, p => p.IntProductId, (tp, p) => new {
                    ProductName = p.StrName,
                    tp.TotalQuantity
                })
                .ToList();

            return topSellingProducts.Cast<dynamic>().ToList();
        }

        public List<dynamic> GetPaymentMethodBreakdown(List<Torder> filteredOrders) {
            var paymentMethodBreakdown = filteredOrders
                .GroupBy(o => o.IntPaymentMethodId)
                .Select(g => new {
                    PaymentMethodID = g.Key,
                    TotalOrders = g.Count()
                })
                .Join(_context.TpaymentMethods, pm => pm.PaymentMethodID, p => p.IntPaymentMethodId, (pm, p) => new {
                    PaymentMethod = p.StrDescription,
                    pm.TotalOrders
                })
                .ToList();

            return paymentMethodBreakdown.Cast<dynamic>().ToList();
        }


        public List<dynamic> GetProductSalesData(List<Torder> filteredOrders) {
            var productSalesData = filteredOrders
                .SelectMany(o => o.TorderItems)
                .Where(oi => oi.IntProduct != null) // Filter out TorderItems with null IntProduct
                .GroupBy(oi => oi.IntProduct.StrName)
                .Select(g => new ProductSalesData {
                    ProductName = g.Key,
                    TotalSales = (decimal)g.Sum(oi => oi.IntQuantity * oi.MonPricePerUnit)
                })
                .ToList();

            var productSalesDataDynamic = productSalesData
                .Select(p => new { ProductName = p.ProductName, TotalSales = p.TotalSales })
                .Cast<dynamic>()
                .ToList();

            return productSalesDataDynamic;
        }


        public IQueryable<Torder> FilterOrdersByDate(IQueryable<Torder> orders, int? year, int? month, int? day) {
            orders = orders.Include(o => o.TorderItems)
                           .ThenInclude(oi => oi.IntProduct);

            if (year.HasValue) {
                orders = orders.Where(o => o.DtmOrderDate.Value.Year == year.Value);
            }

            if (month.HasValue) {
                orders = orders.Where(o => o.DtmOrderDate.Value.Month == month.Value);
            }

            if (day.HasValue) {
                orders = orders.Where(o => o.DtmOrderDate.Value.Day == day.Value);
            }

            return orders;
        }


    }
}
