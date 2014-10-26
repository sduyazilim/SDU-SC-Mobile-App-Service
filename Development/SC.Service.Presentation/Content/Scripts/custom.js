$(document).ready(function () {

    var jsResources = {
        DeleteModalMessage: "That record and some attached another records will be deleted.<br />Do you agree it ?"
    };

    $(".button-delete").click(function (e) {
        e.preventDefault();
        var message = $(this).attr("data-message") == null ? jsResources.DeleteModalMessage : $(this).attr("data-message");

        bootbox.confirm(message, function (result) {
            if (result == true) {
                window.location.href = e.target.href;
            }
        });
    });

});