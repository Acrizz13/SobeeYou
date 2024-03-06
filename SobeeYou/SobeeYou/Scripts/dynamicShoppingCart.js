$(document).ready(function () {
	// Function to update shopping cart count
	function updateCartCount() {
		$.ajax({
			url: '/ShoppingCart/GetTotalCartItems', // Adjust the URL as needed
			type: 'GET',
			success: function (data) {
				$('#cartItemCount').text(data);
			},
			error: function () {
				// Handle error
			}
		});
	}

	// function for adding products to shopping cart asynchronously
	$(document).ready(function () {
		$('.add-to-cart-btn').click(function () {
			// Get the product details from the button's data attributes
			var productId = $(this).data('product-id');
			var quantity = parseInt($(this).closest('tr').find('.quantity-dropdown').val());

			// Create a new CartItems object
			var newItem = {
				intProductID: productId,
				intQuantity: quantity,
				dtmDateAdded: new Date() // Use the current date/time
			};

			// Make AJAX request to add the item to the cart
			$.ajax({
				url: '/ShoppingCart/AddToCart',
				method: 'POST',
				data: newItem, // Pass the new CartItems object as data
				success: function (response) {
					// Handle success response
					alert('Item added to cart successfully');
				},
				error: function (xhr, status, error) {
					// Handle error response
					alert('Error adding item to cart: ' + error);
				}
			});
		});
	});


	// Call updateCartCount function initially and then at regular intervals (e.g., every 5 seconds)
	updateCartCount();
	setInterval(updateCartCount, 5000); // Update every 5 seconds
});
