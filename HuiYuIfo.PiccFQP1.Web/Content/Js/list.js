$(document).ready
(
    function () {
        $(".list tr").click
        (
            function () {
                $(".click").removeClass("click");
                $(this).addClass("click");
            }
        );
        $(".date").focus(function () {
                showCalendar(this)
        });
        $(".list tr:even").addClass("alt");
    })