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


	$(document).ready(function () {
		// Handle click events for modify quantity buttons
		$(".modify-quantity-btn").click(function () {
			var productId = $(this).data("product-id");
			var change = $(this).data("change");
			modifyQuantity(productId, change);
		});

		// Handle click events for remove from cart button
		$(".remove-from-cart-btn").click(function () {
			var productId = $(this).data("product-id");
			removeFromCart(productId);
		});
	});

	function modifyQuantity(productId, change) {
		$.ajax({
			url: "/ShoppingCart/ModifyQuantity",
			type: "POST",
			data: { productId: productId, change: change },
			success: function (response) {
				// Update the quantity in the corresponding span element
				var $quantitySpan = $('[data-product-id="' + productId + '"].quantity-text');
				var currentQuantity = parseInt($quantitySpan.text());
				var newQuantity = currentQuantity + change;
				$quantitySpan.text(newQuantity);

				// If the new quantity is 0, remove the entire row from the table
				if (newQuantity === 0) {
					$quantitySpan.closest('tr').remove();
				}

				// Update the total cart items count immediately
				updateCartCount();

				// Calculate total price asynchronously
				updateTotalPrice();
			},
			error: function (xhr, status, error) {
				alert("An error occurred: " + error);
			}
		});
	}

	function removeFromCart(productId) {
		$.ajax({
			url: "/ShoppingCart/RemoveFromCart",
			type: "POST",
			data: { productId: productId },
			success: function (response) {
				// Find the corresponding row in the table based on the productId
				var $row = $('table').find('tr').filter(function () {
					return $(this).find('.remove-from-cart-btn').data('product-id') == productId;
				});

				// Remove the row from the table
				$row.remove();

				// Update the total cart items count immediately
				updateCartCount();

				// Calculate total price asynchronously
				updateTotalPrice();
			},
			error: function (xhr, status, error) {
				alert("An error occurred: " + error);
			}
		});
	}

	// Event listener for quantity elements
	$('.quantity-text').on('input', function () {
		// Calculate total price
		updateTotalPrice();
	});

	// Function to update total price
	function updateTotalPrice() {
		$.ajax({
			url: '/ShoppingCart/GetTotalPrice', // URL to action method
			type: 'GET',
			success: function (data) {
				$('#totalPrice').text(data); // Update total price element
			},
			error: function () {
				// Handle error
				alert("An error occurred: ");
			}
		});
	}



	// Call updateCartCount function initially and then at regular intervals (e.g., every 5 seconds)
	updateCartCount();
	setInterval(updateCartCount, 5000); // Update every 5 seconds
});
