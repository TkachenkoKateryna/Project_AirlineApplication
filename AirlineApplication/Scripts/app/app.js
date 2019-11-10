var FlightsController = function () {

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

    var dropdownFilter = function () {
        $("#departure").change(function () {
            var val = $("#departure").val();
            $("#landing").children('option').show();
            $('#landing option[value=' + val + ']').hide();
        })
    }

    return {
        datetimepicker,
        discard,
        moveSidebar,
        dropdownFilter
    }
}();

var MembersController = function () {

    var fillTable = function () {
        $("#members").DataTable({
            ajax: {
                url: "/api/crewmembers",
                dataSrc: "",
            },
            columns: [
                {
                    data: "fullName",
                    render: function (data, type, member) {
                        return "<a href='/crewmembers/editmember/" + member.crewMemberId + "'>" + member.fullName + "</a>"
                    }
                },
                {
                    data: "profession.name",
                },
                {
                    data: "crewMemberId",
                    render: function (data) {
                        return "<a href='#' class='js-delete-member' data-member-id=" + data + ">Delete</a>";
                    }
                },
            ]
        });
    }

    var deleteCrewMemeber = function () {
        $("#members").on("click", ".js-delete-member", function (e) {
            var link = $(e.target);
            bootbox.dialog({
                title: "Confirm",
                message: "<p>Are you sure you want delete this member</p>",
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
                            $.ajax({
                                url: `/api/crewmembers/${link.attr('data-member-id')}`,
                                method: "DELETE"
                            })
                                .done(function () {
                                    link.parents("tr").fadeOut(function () {
                                        $(this).remove();
                                    });
                                })
                                .fail(function (xhr, status, error) {
                                    alert("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
                                });
                        }
                    },
                }
            });
        });
    }

    var getProfessions = function () {
        $.ajax({
            type: "GET",
            url: "/api/profession",
            data: "{}",
            success: function (data) {
                var s = '<option value="-1">Please Select a Profession</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].professionId + '">' + data[i].name + '</option>';
                }
                $("#professionDropdown").html(s);
            }
        });
    }

    var createCrewMembers = function () {
        $('#submit').on("click", function () {
            var name = $("#name").val();
            var profId = $("#professionDropdown").val();
            $.ajax({
                type: "POST",
                url: "/api/crewmembers",
                data: {
                    'fullName': name,
                    'professionId': profId
                },
                cache: false,
                success: function () {
                    location.href = "http://localhost:57475/CrewMembers/ShowMembers"
                }
            })
            return false;
        });
    }

    return {
        getProfessions,
        createCrewMembers,
        deleteCrewMemeber,
        fillTable
    }
}();