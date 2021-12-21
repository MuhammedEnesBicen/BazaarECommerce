// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




//$('#removeCart').click(function () {


//    Swal.fire({
//        title: 'Are you sure?',
//        text: "You're about to empty the cart completely, are you sure?",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, delete it!'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.post("/Cart/EmptyCart?customerId=" + 2);
//            //Swal.fire(
//            //    'Deleted!',
//            //    'Your cart is completely emptied.',
//            //    'success'
//            //)

//        }
//    })
//});




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

function brandFilter(categoryId,brandId) {

    $.post("/Product/GetFilteredProducts?categoryId=" + categoryId, "&brandId=" + brandId).then(
        function (result) {
            $("#mydiv").html(result);
        }
    );
}

function addItemToCart(productId, quantity, customerId) {
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
            
        }    );
}










