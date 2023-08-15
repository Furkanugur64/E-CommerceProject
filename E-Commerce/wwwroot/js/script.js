$("#BtnCopy").click(function () {
    let metin = $("#txtcouponcode").text().trim();
    let tempInput = $("<input>");
    tempInput.val(metin);
    $("body").append(tempInput);
    tempInput.select();
    document.execCommand("copy");
    tempInput.remove();
});

$("#BtnCommentAdd").click(function () {
    debugger;
    var formData = $("#FrmComment").serialize();
    $.ajax({
        type: "POST",
        url: "/Product/AddComment",
        data: formData,
        success: function (data) {           
            if (data.sonuc) {
                swal("Kaydedildi", "Yorumunuz başarıyla kaydedildi", "success");
            }
            else {
                swal("Hata", "Yorum Ekleme İşleminde Bir Hata Oluştu", "error");
            }

        },
        error: function () {
            swal("Hata", "Yorum Ekleme İşleminde Bir Hata Oluştu", "error");
        }
    });
});

$("#sendMessageButton").click(function () {
    debugger;
    var formData = $("#FrmContact").serialize();
    $.ajax({
        type: "POST",
        url: "/Contact/AddContact",
        data: formData,
        success: function (data) {
            if (data.sonuc) {
                swal("Kaydedildi", "Mesajınız başarıyla kaydedildi", "success");
                document.getElementById("name").value = "";
                document.getElementById("mail").value = "";
                document.getElementById("subject").value = "";
                document.getElementById("message").value = "";
            }
            else {
                swal("Hata", "Mesaj Ekleme İşleminde Bir Hata Oluştu", "error");
            }

        },
        error: function () {
            swal("Hata", "Mesaj Ekleme İşleminde Bir Hata Oluştu", "error");
        }
    });
});

$('.quantity button').on('click', function () {
    var button = $(this);
    var stockValue = button.parent().parent().find('input').data('stock');
    var oldValue = button.parent().parent().find('input').val();

    if (button.hasClass('btn-plus')) {
        if (oldValue == stockValue) {
            newVal = stockValue;
        }
        else {
            var newVal = parseFloat(oldValue) + 1;
        }
    }
    else {
        if (oldValue > 1) {
            var newVal = parseFloat(oldValue) - 1;
        } else {

            newVal = 1;
        }
    }
    button.parent().parent().find('input').val(newVal);
});

$("#BtnAddBasket").click(function () {
    var productid = document.getElementById("productid").value;
    var basketCount = document.getElementById('basketCount');
    var count = parseInt(basketCount.textContent);
    $.ajax({
        type: "POST",
        url: "/Basket/AddBasket",
        data: {
            ProductID: productid
        },
        success: function (data) {
            if (data.sonuc) {
                count++;
                basketCount.textContent = count;
                swal({
                    title: "Ürün Sepete Eklendi!",
                    icon: "success",
                    buttons: {
                        devam: "Alışverişe Devam Et",
                        sepeteGit: "Sepete Git"
                    },
                }).then((value) => {
                    switch (value) {
                        case "devam":
                            break;
                        case "sepeteGit":
                            window.location.href = "/Basket/Index/"
                            break;
                        default:
                            break;
                    }
                });
            }
            else {
                swal({
                    title: "Ürün Zaten Sepetinizde Var !",
                    icon: "error",
                    buttons: {
                        devam: "Alışverişe Devam Et",
                        sepeteGit: "Sepete Git"
                    },
                }).then((value) => {
                    switch (value) {
                        case "devam":
                            break;
                        case "sepeteGit":
                            window.location.href = "/Basket/Index/"
                            break;
                        default:
                            break;
                    }
                });
            }

        },
        error: function () {
            swal("Hata", "Mesaj Ekleme İşleminde Bir Hata Oluştu", "error");
        }
    });
});

$("#BtnCouponUse").click(function () {
    var sumPrice = document.getElementById("sumPrice").textContent;
    var sum = parseInt(sumPrice);
    var couponcode = document.getElementById("couponCode").value;
    if (couponcode == null || couponcode == "") {
        swal("Hata", "Geçerli Bir Kupon Kodu Girin", "error");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Coupon/CheckCoupon/",
            data: {
                couponCode: couponcode
            },
            success: function (data) {
                if (data.uygun) {
                    if (sum != 50) {
                        $("#BtnCouponUse").addClass("disabled");
                        swal({
                            title: "Tebrikler",
                            text: "%40 İndirim Kuponunuz Başarıyla Uygulandı",
                            icon: "success",
                            buttons: {
                                tamam: "Tamam",
                            },
                        });
                        var discount = (sum * 0.4) + 50;
                        sum -= sum * 0.4;
                        sum = sum - 50;

                        document.getElementById("sumPrice").textContent = sum;


                        document.getElementById("cargo").textContent = "Ücretsiz";

                        const container = document.getElementById("container");

                        const newExample = `                                       
                                        <div class="d-flex justify-content-between mb-3">
                                                <h6 style="color:red">İndirim Tutarı</h6>
                                                <h6 style="color:red"><span>${discount}</span> ₺</h6>
                                        </div>                                       
                                        `;
                        container.insertAdjacentHTML("beforeend", newExample);
                    }




                }
                else {
                    if (data.sonuc) {
                        swal({
                            title: "Hata",
                            text: "Kuponun kullanım süresi geçmiş",
                            icon: "error",
                            buttons: {
                                tamam: "Tamam",
                            },
                        });
                    }
                    else {
                        swal({
                            title: "Hata",
                            text: "Böyle Bir Kupon Bulunamadı",
                            icon: "error",
                            buttons: {
                                tamam: "Tamam",
                            },
                        });
                    }
                }

            },
            error: function () {
                swal("Hata", "Kupon Ekleme İşleminde Bir Hata Oluştu", "error");
            }
        });
    }
});

$(document).on('touchstart click', '#BtnDeleteBasket', function () {

    var id = $(this).data('basketid');
    var basketCount = document.getElementById('basketCount');
    var count = parseInt(basketCount.textContent);

    var producttotalprice = parseInt($(this).closest("tr").find(".total-price-cell").text());
    var totalPrice = parseInt(document.getElementById("totalPrice").textContent);
    $.ajax({
        type: "POST",
        url: "/Basket/UpdateBasket",
        data: {
            basketid: id,
            count: 0,
            Operation: "Delete"
        },
        success: function (data) {
            if (data.sonuc) {

                // Sepet kısmının değerini azalttık
                count--;
                basketCount.textContent = count;

                // Toplam Tutar kısmını düzenledik
                var newTotalPrice = totalPrice - producttotalprice;
                document.getElementById("totalPrice").textContent = newTotalPrice;

                // Toplam Para (kargo dahil) kısmı düzenlendi
                if (newTotalPrice > 100000) {
                    var sumPrice = totalPrice - producttotalprice;
                    document.getElementById("cargo").textContent = "Ücretsiz";
                }
                else {
                    var sumPrice = totalPrice - producttotalprice + 50;
                    document.getElementById("cargo").textContent = "50 ₺";
                }
                document.getElementById("sumPrice").textContent = sumPrice;

                var rowToRemove = $("tr[data-basketlistid='" + id + "']");
                rowToRemove.remove();
                swal({
                    title: "Ürün Sepetten Silindi",
                    icon: "success",
                    buttons: {
                        tamam: "Tamam",
                    },
                }).then((value) => {
                    switch (value) {
                        case "tamam":
                            break;
                        default:
                            break;
                    }
                });
                const divCount = $("#container").children("div").length;
                if (divCount === 3) {
                    $("#container").children().last().remove();
                }
                $("#BtnCouponUse").removeClass("disabled");
            }
            else {
                swal("Hata", "Mesaj Ekleme İşleminde Bir Hata Oluştu", "error");
            }

        },
        error: function () {
            swal("Hata", "Mesaj Ekleme İşleminde Bir Hata Oluştu", "error");
        }
    });
});


$(document).ready(function () {

    $(".btn-plus").on("click", function () {
        var basketId = $(this).data("basketid");
        var quantityInput = $(this).closest("tr").find(".form-control");
        var price = $(this).closest("tr").find(".price-cell");
        var priceCell = $(this).closest("tr").find(".total-price-cell");
        var totalPrice = document.getElementById("totalPrice").textContent;
        var total = parseInt(totalPrice);
        $.ajax({
            type: "POST",
            url: "/Basket/UpdateBasket",
            data: {
                basketid: basketId,
                count: quantityInput.val(),
                Operation: "Update"
            },
            success: function (data) {
                if (data.sonuc) {

                    var currentQuantity = parseInt(quantityInput.val());
                    var pricePerItem = parseInt(price.text());
                    var TotalProductPrice = total + pricePerItem;
                    document.getElementById("totalPrice").textContent = TotalProductPrice;
                    if (TotalProductPrice > 100000) {
                        var TotalPrice = total + pricePerItem;
                        document.getElementById("cargo").textContent = "Ücretsiz";
                    }
                    else {
                        var TotalPrice = total + pricePerItem + 50;
                        document.getElementById("cargo").textContent = "50 ₺";
                    }
                    document.getElementById("sumPrice").textContent = TotalPrice;
                    var newTotalPrice = (pricePerItem * currentQuantity);
                    priceCell.text(newTotalPrice);
                    const divCount = $("#container").children("div").length;
                    if (divCount === 3) {
                        $("#container").children().last().remove();
                    }
                    $("#BtnCouponUse").removeClass("disabled");
                }
                else {
                }
            },
            error: function () {
                swal("Hata", "Mesaj Ekleme İşleminde Bir Hata Oluştu", "error");
            }
        });
    });
    $(".btn-minus").on("click", function () {
        var basketId = $(this).data("basketid");
        var quantityInput = $(this).closest("tr").find(".form-control");
        var price = $(this).closest("tr").find(".price-cell");
        var priceCell = $(this).closest("tr").find(".total-price-cell");
        var totalPrice = document.getElementById("totalPrice").textContent;
        var total = parseInt(totalPrice);
        $.ajax({
            type: "POST",
            url: "/Basket/UpdateBasket",
            data: {
                basketid: basketId,
                count: quantityInput.val(),
                Operation: "Update"
            },
            success: function (data) {
                if (data.sonuc) {

                    var currentQuantity = parseInt(quantityInput.val());
                    var pricePerItem = parseInt(price.text());
                    var TotalProductPrice = total - pricePerItem;
                    document.getElementById("totalPrice").textContent = TotalProductPrice;
                    if (TotalProductPrice > 100000) {
                        var TotalPrice = total - pricePerItem;
                        document.getElementById("cargo").textContent = "Ücretsiz";
                    }
                    else {
                        var TotalPrice = total - pricePerItem + 50;
                        document.getElementById("cargo").textContent = "50 ₺";
                    }
                    document.getElementById("sumPrice").textContent = TotalPrice;
                    var newTotalPrice = (pricePerItem * currentQuantity);
                    priceCell.text(newTotalPrice);
                    if (currentQuantity == 1) {
                        //buton disable olacak                         
                    }
                    const divCount = $("#container").children("div").length;
                    if (divCount === 3) {
                        $("#container").children().last().remove();
                    }
                    $("#BtnCouponUse").removeClass("disabled");
                }
                else {
                }
            },
            error: function () {
                swal("Hata", "Mesaj Ekleme İşleminde Bir Hata Oluştu", "error");
            }
        });
    });

});


$("#BtnKartOnay").click(function () {
    var cardnumber = document.getElementById("cardNumber").value;
    if (cardnumber != null && cardnumber != "") {
        $.ajax({
            type: "POST",
            url: "/Basket/CardControl",
            data: {
                cardNumber: cardnumber
            },
            success: function (data) {
                if (data.sonuc) {
                    var checkbox = document.getElementById("CardConfirm");
                    checkbox.checked = true;
                    swal({
                        title: "Kart Doğrulama Başarılı",
                        icon: "success",
                        buttons: {
                            tamam: "Tamam",
                        }
                    })
                }
                else {
                    swal({
                        title: "Hatalı Kart Numarası !",
                        icon: "error",
                        buttons: {
                            tamam: "Tamam",
                        }
                    })
                }
            },
            error: function () {
                swal("Hata", "Mesaj Ekleme İşleminde Bir Hata Oluştu", "error");
            }
        });
    }
});

$("#BtnCheckout").click(function () {
    var totalPrice = document.getElementById("sumPrice").textContent
    var total = parseInt(totalPrice);
    window.location.href = "/Basket/Checkout/?price=" + total;
});

$("#BtnCreateOrder").click(function () {
    var checkbox = document.getElementById("CardConfirm");
    var totalPrice = document.getElementById("totalPrice").textContent
    var total = parseInt(totalPrice);
    var basketCount = document.getElementById('basketCount');

    if (checkbox.checked) {
        $.ajax({
            type: "POST",
            url: "/Basket/AddOrder",
            data: {
                totalPrice: total
            },
            success: function (data) {
                if (data.sonuc) {
                    $("#BtnCreateOrder").addClass("disabled");
                    basketCount.textContent = 0;
                    swal({
                        title: "Tebrikler",
                        text: "Siparişiniz Başarılı Bir Şekilde Oluştu",
                        icon: "success",
                        buttons: {
                            tamam: "Tamam",
                        }
                    }).then((value) => {
                        switch (value) {
                            case "tamam":
                                window.location.href = "/User/MyOrders/"
                                break;
                            default:
                                break;
                        }
                    });
                }

            },
            error: function () {
                swal("Hata", "Sipariş Ekleme İşleminde Bir Hata Oluştu", "error");
            }
        });
    }
    else {
        swal({
            title: "Hata Oluştu",
            text: "Önce Kart Bilgilerinizi Doğrulayın",
            icon: "error",
            buttons: {
                tamam: "Tamam",
            }
        })
    }

});