// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function emtyCart(customerId) {

    Swal.fire({
        title: 'Are you sure?',
        text: "You're about to empty the cart completely, are you sure?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.post("/Cart/EmptyCart?customerId=" + customerId);
            Swal.fire(
                'Deleted!',
                'Your cart is completely emptied.',
                'success'
            ).then((result) => {
                if (result.isConfirmed) {
                    $("tbody").html("Your cart is emty");
                }
            })

        }
    })
}

function cartAlreadyEmty() {
    Swal.fire(
        'Info!',
        'Your cart is already empty.',
        'success'
    )

}

function changeQuantity(cartId, quantity, decrease) {
    if (quantity == 0 && decrease == -1) { }
    else {
        $.post("/Cart/UpdateCartQuantity?cartId=" + cartId + "&quantity=" + decrease).then(
            function (result) { $("#cartList").html(result); }
        );
    }
}

function brandFilter(brandId) {
    $.post("/Product/BrandFilter?brandId=" + brandId).then(
        function () {

            $.post("/Product/GetFilteredProducts").then(
                function (result) {
                    $("#mydiv").html(result);
                }
            );

        }
    );


}

function starFilter(starRate) {
    $.post("/Product/StarFilter?starRate=" + starRate).then(
        function () {

            $.post("/Product/GetFilteredProducts").then(
                function (result) {
                    $("#mydiv").html(result);
                }
            );

        }
    );


}

function textFilter() {
    var text = $("#searchInput").val();
    $.post("/Product/TextFilter?text=" + text).then(
        function () {

            $.post("/Product/GetFilteredProducts").then(
                function (result) {
                    $("#mydiv").html(result);
                }
            );

        }
    );
}

function priceFilter() {
    var min = $("#minPrice").val();
    var max = $("#maxPrice").val();
    $.post("/Product/PriceFilter?min=" + min+ "&max="+max).then(
        function () {

            $.post("/Product/GetFilteredProducts").then(
                function (result) {
                    $("#mydiv").html(result);
                }
            );

        }
    );
}


function addItemToCart(productId, quantity, customerId) {

    $.post("/Home/IsAuthorize").then(function (result) {
        if (result == false) {
            Swal.fire(
                'Info!',
                'It seems you are not logged in. You cant add item to cart.',
                'success'
            )
        }
        else {
            $.post("/Cart/AddItemToCart?productId=" + productId + "&quantity=" + quantity + "&customerId=" + customerId).then(
                function (result) {
                    if (result.result == true) {
                        Swal.fire({
                            title: 'Info',
                            text: result.message,
                            confirmButtonColor: '#3085d6',
                            confirmButtonText: 'Okey'
                        })
                    } else {
                        Swal.fire({
                            title: 'Info',
                            text: result.message,
                            confirmButtonColor: '#f20f0f',
                            confirmButtonText: 'Okey'
                        })
                    }

                });

        }
    })

}










