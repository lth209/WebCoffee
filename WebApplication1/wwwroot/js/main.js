

'use strict';

(function ($) {

    /*Thêm vào giỏ hàng*/
        $(".fa-shopping-cart").on("click", function () {
            var recordAddToCart = $(this).attr("data-id");

            if (recordAddToCart != '') {
                // Perform the ajax post
                $.post("/Shoppingcart/AddToCart", {"masp": recordAddToCart, "quantity":1 },
                    function (data) {
                        // Successful requests get here
                        if (data.status == "no product") {
                            $("#NoProductModal").modal();
                        }
                        if (data.status == "not signin") {
                            $("#LoginModal").modal();
                        }
                        else {
                            //update number
                            $(".shoping-bag > span").text(data.cart.amount);
                            $(".total-price > span").text(data.cart.total);
                            $(".total-cart > span").text(data.cart.total);
                            $(".subtotal-cart > span").text(data.cart.total);
                            //$(".shopping-bag").popover("show");
                        }
                    })
            }
        });
    

    $(".btn-login").on("click", function () {
        window.location = "/DangNhap";
    });
    /*thêm xóa giỏ hàng*/
    $(".shoping__cart__item__close").on("click", function () {
        var recordItem = $(this).attr("data-id");
        $(this).parent().remove();
        if (recordItem != '') {
            $.post("Shoppingcart/RemoveItem", { "masp": recordItem },
                function (data) {
                    if (data.status == "success") {
                        $(".shoping-bag > span").text(data.cart.amount);
                        $(".total-price > span").text(data.cart.total);
                    }
                    else {
                        if (data.status == "no product") {
                            $("#NoProductModal").modal();
                        }
                    }
                })
        }
    });

/*Nút thêm vào giỏ ở chi tiết*/
    $(".btn-add-to-cart").on("click", function () {
        var newVal = $(this).parent().find("input").val();
        var recordItem = $(this).attr("data-id");
        $.post("/Shoppingcart/AddToCart", { "masp": recordItem, "quantity": newVal },
            function (data) {
                // Successful requests get here
                if (data.status == "not signin") {
                    $("#LoginModal").modal();
                }
                else {
                    //update number
                    $(".shoping-bag > span").text(data.cart.amount);
                    $(".total-price > span").text(data.cart.total);
                    $(".shopping-bag").popover("show");
                }
            })
    });
    /*------------------
        Preloader
    --------------------*/
    

    $(window).on('load', function () {
        $(".loader").fadeOut();
        $("#preloder").delay(200).fadeOut("slow");

        /*------------------
            Gallery filter
        --------------------*/
        $('.featured__controls li').on('click', function () {
            $('.featured__controls li').removeClass('active');
            $(this).addClass('active');
        });
        if ($('.featured__filter').length > 0) {
            var containerEl = document.querySelector('.featured__filter');
            var mixer = mixitup(containerEl);
        }
    });

    /*------------------
        Background Set
    --------------------*/
    $('.set-bg').each(function () {
        var bg = $(this).data('setbg');
        $(this).css('background-image', 'url(' + bg + ')');
    });

    //Humberger Menu
    $(".humberger__open").on('click', function () {
        $(".humberger__menu__wrapper").addClass("show__humberger__menu__wrapper");
        $(".humberger__menu__overlay").addClass("active");
        $("body").addClass("over_hid");
    });

    $(".humberger__menu__overlay").on('click', function () {
        $(".humberger__menu__wrapper").removeClass("show__humberger__menu__wrapper");
        $(".humberger__menu__overlay").removeClass("active");
        $("body").removeClass("over_hid");
    });

    /*------------------
		Navigation
	--------------------*/
    $(".mobile-menu").slicknav({
        prependTo: '#mobile-menu-wrap',
        allowParentLinks: true
    });

    /*-----------------------
        Categories Slider
    ------------------------*/
    $(".categories__slider").owlCarousel({
        loop: true,
        margin: 0,
        items: 4,
        dots: false,
        nav: true,
        navText: ["<span class='fa fa-angle-left'><span/>", "<span class='fa fa-angle-right'><span/>"],
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
        responsive: {

            0: {
                items: 1,
            },

            480: {
                items: 2,
            },

            768: {
                items: 3,
            },

            992: {
                items: 4,
            }
        }
    });


    $('.hero__categories__all').on('click', function(){
        $('.hero__categories ul').slideToggle(400);
    });

    /*--------------------------
        Latest Product Slider
    ----------------------------*/
    $(".latest-product__slider").owlCarousel({
        loop: true,
        margin: 0,
        items: 1,
        dots: false,
        nav: true,
        navText: ["<span class='fa fa-angle-left'><span/>", "<span class='fa fa-angle-right'><span/>"],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true
    });

    /*-----------------------------
        Product Discount Slider
    -------------------------------*/
    $(".product__discount__slider").owlCarousel({
        loop: true,
        margin: 0,
        items: 3,
        dots: true,
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
        responsive: {

            320: {
                items: 1,
            },

            480: {
                items: 2,
            },

            768: {
                items: 2,
            },

            992: {
                items: 3,
            }
        }
    });

    /*---------------------------------
        Product Details Pic Slider
    ----------------------------------*/
    $(".product__details__pic__slider").owlCarousel({
        loop: true,
        margin: 20,
        items: 4,
        dots: true,
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true
    });

    /*-----------------------
		Price Range Slider
	------------------------ */
    var rangeSlider = $(".price-range"),
        minamount = $("#minamount"),
        maxamount = $("#maxamount"),
        minPrice = rangeSlider.data('min'),
        maxPrice = rangeSlider.data('max');
    rangeSlider.slider({
        range: true,
        min: minPrice,
        max: maxPrice,
        values: [minPrice, maxPrice],
        slide: function (event, ui) {
            minamount.val('$' + ui.values[0]);
            maxamount.val('$' + ui.values[1]);
        }
    });
    minamount.val('$' + rangeSlider.slider("values", 0));
    maxamount.val('$' + rangeSlider.slider("values", 1));

    /*--------------------------
        Select
    ----------------------------*/
    $("select").niceSelect();

    /*------------------
		Single Product
	--------------------*/
    $('.product__details__pic__slider img').on('click', function () {

        var imgurl = $(this).data('imgbigurl');
        var bigImg = $('.product__details__pic__item--large').attr('src');
        if (imgurl != bigImg) {
            $('.product__details__pic__item--large').attr({
                src: imgurl
            });
        }
    });

    /*-------------------
		Quantity change
	--------------------- */
    var proQty = $('.pro-qty-not-add');
    proQty.prepend('<span class="dec qtybtn">-</span>');
    proQty.append('<span class="inc qtybtn">+</span>');
    proQty.on('click', '.qtybtn', function () {
        var $button = $(this);
        var oldValue = $button.parent().find('input').val();
        //inc button tăngsl
        if ($button.hasClass('inc')) {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 1) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 1;
            }
        }
        $button.parent().find('input').val(newVal);
    });
    /*Click gửi request xuống db */
    var proQtyAdd = $('.pro-qty-add');
    proQtyAdd.prepend('<span class="dec qtybtn">-</span>');
    proQtyAdd.append('<span class="inc qtybtn">+</span>');
    proQtyAdd.on('click', '.qtybtn', function () {
        var $button = $(this);
        var recordItem = $(this).parent().attr("data-id");
        var oldValue = $button.parent().find('input').val();
        if ($button.hasClass('inc')) {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 1) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 1;
            }
        }
        $.post("Shoppingcart/UpdateCartDetail", { "quantity": newVal, "masp": recordItem },
            function (data) {
                if (data.status == "success") {
                    $(".shoping-bag > span").text(data.cart.amount);
                    $(".total-price > span").text(data.cart.total);
                    $(".total-cart > span").text(data.cart.total);
                    $(".subtotal-cart > span").text(data.cart.total);
                }
                else {
                    if (data.status == "no product") {
                        $("#NoProductModal").modal();
                    }
                }
            });
        var $item = $button.parent().parent().parent().parent();
        var gia = $item.find(".shoping__cart__price").text();
        $item.find(".shoping__cart__total").text(gia * newVal);
        $button.parent().find('input').val(newVal);
    });

})(jQuery);