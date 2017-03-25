$(document).ready(function(){
    $(".date").focus(function () {
        showCalendar(this);
    })
    $(".list tr").click
    (
        function () {
            $(".click").removeClass("click");
            $(this).addClass("click");
        }
    );
})