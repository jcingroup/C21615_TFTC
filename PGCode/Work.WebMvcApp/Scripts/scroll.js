    $(document).ready(function () {

        $('a.btn').click(function () {
            $('html, body').animate({
                scrollTop: $($.attr(this, 'href')).offset().top
            }, 500);
            return false;
        });

    });