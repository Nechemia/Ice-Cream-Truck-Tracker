$(function () {

    
    var editIdRoute = 0;
    
    var editRouteMode = false;
   


    
    //until now is for showing the correct table
    //now for showing route modal
    $("#addExpense").on('click', function () {
        $("#addExpenseModal").modal();
        editRouteMode = false;

    });

    //disabling submit button if select fields aren't filled

    $("#saveExpense").prop('disabled', true);
    $('.expense').keyup(function () {
        if ($("#date").val() == "" || $("#amount").val() == "") {
            $("#saveRoute").prop("disabled", true);
        }
        else {
            $("#saveExpense").prop("disabled", false);
        }
    });



    //saving field on route modal
    $("#saveExpense").on('click', function () {

        ////confirm leaving fields empty
        //if ($("#timeStartedRoute").val() == "" || $("#timeEndedRoute").val() == "") {
        //    var check = confirm("Are You Sure You Want To Leave Some Fields Empty?");
        //    if (!check) {
        //        return;
        //    }
        //}

        var name = $("#name").val();
        var date = $("#date").val();
        var amount = $("#amount").val();
        

        //function checkvalue(val) {
        //    if (val === "others")
        //        document.getElementById('name').style.display = 'block';
        //    else
        //        document.getElementById('name').style.display = 'none';
        //}
        //up to hear dealing with other

        if (editRouteMode == false) {
            $.post("/MoneyMade/AddRoute", { amountMade: amountMade, timeStarted: timeStarted, timeEnded: timeEnded, driverName: driverName, date: date }, function () {
            });
        }
        if (editRouteMode == true) {
            $.post("/MoneyMade/UpdateRoute", { id: editIdRoute, amountMade: amountMade, timeStarted: timeStarted, timeEnded: timeEnded, driverName: driverName, date: date }, function () {
            });
        }
        $("#addRouteModal").modal('hide');
    });

  

    

    
    
    //delete route button
    $(".deleteRoute").on('click', function () {

        var currentButton = $(this);
        var id = currentButton.data('id');
        $.post("/MoneyMade/DeleteRoute", { id: id }, function () {
            location.reload(true);
        });
    })
    
    
    //this is code to edit route using same modal as add route, having the fields prefilled
    $(".editRoute").on('click', function () {
        var currentButton = $(this);
        editIdRoute = currentButton.data('id');
        var date = $(this).closest('tr').find("td:eq(0)").html();
        var amountMade = $(this).closest('tr').find("td:eq(1)").html();
        var driver = $(this).closest('tr').find("td:eq(2)").html();
        var timeStarted = $(this).closest('tr').find("td:eq(3)").html();
        var timeEnded = $(this).closest('tr').find("td:eq(4)").html();




        $("#amountMadeRoute").val(amountMade);
        $("#timeStartedRoute").val(timeStarted);
        $("#timeEndedRoute").val(timeEnded);
        $("#driverRoute").val(driver);
        $("#dateRoute").val(date);

        $("#saveRoute").text("Update");
        $("#addRouteModal").modal();
        editRouteMode = true;

    })
})











