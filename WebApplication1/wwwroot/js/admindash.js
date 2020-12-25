﻿
'use strict';

(function ($) {

    /*Thêm vào giỏ hàng*/
    $(".btn-add-od").on("click", function () {
        $("#OrderDetailModal").modal();
    });

    $(".btn-edit-od").on("click", function () {
        $("#OrderModal").modal();
    });

    /*Remove CTDH */
    $(".btn-remove").on("click", function () {
        var recordItem = $(this).attr("data-id");
        $(this).parent().parent().remove();
        if (recordItem != '') {
            $.post("../Admin/RemoveOrderDetail", { "mactdh": recordItem },
                function (data) {
                    if (data.status == "success") {

                    }
                    else {
                        alert("không thành công");
                    }
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


})(jQuery);