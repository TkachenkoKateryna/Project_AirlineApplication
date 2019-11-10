var GigsController = function () {

    var cancel = function () {
        $(".js-delete-flight").click(cancelFlight);
    };

    var cancelFlight = function (e) {
        var link = $(e.target);
        bootbox.dialog({
            title: "Confirm",
            message: "<p>Are you sure you want delete this flight</p>",
            size: 'large',
            buttons: {
                no: {
                    label: "No",
                    className: 'btn-default',
                    callback: function () {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Yes",
                    className: 'btn-danger',
                    callback: function () {
                        actionDelete()
                    },
                },
            }
        });

        var actionDelete = function () {
            $.ajax({
                url: `/api/flights/${link.attr('data-flight-id')}`,
                method: "DELETE"
            })
                .done(function () {
                    link.parents("tr").fadeOut(function () {
                        $(this).remove();
                    });
                })
                .fail(fail);
        };

        var fail = function (xhr, status, error) {
            alert("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
        };
    };
    return {
        cancel: cancel
    }
} ();

var filter = function () {
    var datetimepicker = function () {
        $('#datetimepicker1').datetimepicker({
            format: 'DD-MM-YYYY'
        });
    };
    var discard = function () {
        $('#discard').on('click', function () {
            $("#departure").val("");
            $("#landing").val("");
            $("#status").val("");
            $("#date").val("");
        });
    }
    var moveSidebar = function () {
        $('#open').on('click', function () {
            if ($('#filterBar').css("width") == '0px') {
                $('#filterBar').attr('style', 'width:300px');
                $('#main').attr('style', 'margin-left:300px');
            } else {
                $('#filterBar').attr('style', 'width:0px');
                $('#main').attr('style', 'margin-left:0px');
            }
        });
    }
    return {
        datetimepicker,
        discard,
        moveSidebar
    }
}();

