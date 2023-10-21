$(function () {
    $(document).scroll(function () {
        if ($(this).scrollTop() > 10) {
            $(".navbar").addClass("scrolled", 1000)
        }
        else {
            $(".navbar").removeClass("scrolled", 1000)
        }
    });


    $(".kateqoriyalar li").click(function () {
        $(".butun").hide();
        $("." + $(this).attr("filt")).show();
    }) 


    $(".kategory").change(function () {
        $(".butun").hide();
        $(".subcat .aslan" + $(this).val()).show();
    })


    $(".kateqoriyalar li").click(function () {
        $(".kateqoriyalar li").removeClass("selected");
        $(this).addClass("selected");
    })

    $('.navbar li').click(function () {
        this.css("color", "blueviolet");
    });

    window.onload = function () {
        $('.' + window.location.href.split('/')[window.location.href.split('/').length - 1]).addClass("active");
    }

});


