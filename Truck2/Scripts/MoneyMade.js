$(function () {
    
    var editId = 0;
    var editIdRoute = 0;
    var editMode = false;
    var editRouteMode = false;
    $(".events").hide();
    
    $("#seeEvents").on('click', function () {
       
        $(".routes").hide();
        $(".events").show();
    })

    $("#seeRoutes").on('click', function () {
        $(".events").hide();
        $(".routes").show();
    });
    //until now is for showing the correct table
    //now for showing route modal
    $("#addRoute").on('click', function () {
        $("#addRouteModal").modal();
        editRouteMode = false;
       
    });

        //disabling submit button if select fields aren't filled
       
        $("#saveRoute").prop('disabled', true);
        $('.route').keyup(function () {
            if ($("#amountMadeRoute").val() == "" || $("#dateRoute").val() == "") {
                $("#saveRoute").prop("disabled", true);
            }
            else {
                $("#saveRoute").prop("disabled", false);
            }
        });


       
        //saving field on route modal
        $("#saveRoute").on('click', function () {
            
            //confirm leaving fields empty
            if ($("#timeStartedRoute").val() == "" || $("#timeEndedRoute").val() == "") {
                var check = confirm("Are You Sure You Want To Leave Some Fields Empty?");
                if (!check) {
                    return;
                }
            }

            var amountMade = $("#amountMadeRoute").val();
            var timeStarted = $("#timeStartedRoute").val();
            var timeEnded = $("#timeEndedRoute").val();
            var driverName = $("#driverRoute").val();
            var date = $("#dateRoute").val();

            if (editRouteMode == false) {
                $.post("/MoneyMade/AddRoute", { amountMade: amountMade, timeStarted: timeStarted, timeEnded: timeEnded, driverName: driverName, date: date }, function () {
                });
            }
            if (editRouteMode == true) {
                $.post("/MoneyMade/UpdateRoute", {id:editIdRoute, amountMade: amountMade, timeStarted: timeStarted, timeEnded: timeEnded, driverName: driverName, date: date }, function () {
                });
            }
            $("#addRouteModal").modal('hide');
        });
    
    //event modal
    
    $("#addEvent").on('click', function () {
        $("#addEventModal").modal();
        editMode = false;
    })

    //diabling button for event modal
    $('#saveEvent').prop('disabled', true);
    $('.event').keyup(function () {
        if ($("#nameEvent").val() ==""||  $("#amountMadeEvent").val() == "") {
            $("#saveEvent").prop("disabled", true);
        }
        else {
            $("#saveEvent").prop("disabled", false);
        }
    });
    //saving data from fields for new event
            
    $("#saveEvent").on('click', function () {
        //confirm leaving fields empty
        if ($("#amountOfPeopleEvent").val() == "" || $("#timeStartedEvent").val() == "" || $("#timeEndedEvent").val() == "" || $("#dateEvent").val() == "") {
            var eventCheck = confirm("Are You Sure You Want To Leave Some Fields Empty?");
            if (!eventCheck) {
                return;
            }
        }
       
        
        var name = $("#nameEvent").val();
        var amountOfPeople = $("#amountOfPeopleEvent").val();
        var amountMade = $("#amountMadeEvent").val();
        var productType = $("#productTypeEvent").val();
        var timeStarted = $("#timeStartedEvent").val();
        var timeEnded = $("#timeEndedEvent").val();
        var driverName = $("#driverEvent").val();
        var date = $("#dateEvent").val();
        
        var eventType = $("#eventType").val();
        if(editMode == false){
            $.post("/MoneyMade/AddEvent", { name: name, amountOfPeople: amountOfPeople, amountMade: amountMade, productType: productType, timeStarted: timeStarted, timeEnded: timeEnded, driverName: driverName, date: date, eventType: eventType }, function () {
            });

        }
        if (editMode == true) {
            $.post("/MoneyMade/UpdateEvent", { editId: editId, name: name, amountOfPeople: amountOfPeople, amountMade: amountMade, productType: productType, timeStarted: timeStarted, timeEnded: timeEnded, driverName: driverName, date: date, eventType: eventType }, function () {
            });
                           
            $("#addEventModal").modal('hide');
        }
    })
    //delete route button
    $ ( ".deleteRoute").on('click', function () {
                
        var currentButton = $(this);
        var id = currentButton.data('id');
        $.post("/MoneyMade/DeleteRoute", { id: id }, function () {
            location.reload(true);
        });
    })
    //delete event button
    $(".deleteEvent").on('click', function () {

        var currentButton = $(this);
        var id = currentButton.data('id');
        $.post("/MoneyMade/DeleteEvent", { id: id }, function () {
            location.reload(true);
        });
    })
    //this is code to edit event using same modal as add event, having the fields prefilled
    $(".editEvent").on('click', function () {
       
        var currentButton = $(this);
        editId = currentButton.data('id');
        var name = $(this).closest('tr').find("td:eq(0)").html();
        var amountOfPeople = $(this).closest('tr').find("td:eq(1)").html();
        var eventType = $(this).closest('tr').find("td:eq(2)").html();
        var amountMade = $(this).closest('tr').find("td:eq(3)").html();
        var productType = $(this).closest('tr').find("td:eq(4)").html();
        var timeStarted = $(this).closest('tr').find("td:eq(5)").html();
        var timeEnded = $(this).closest('tr').find("td:eq(6)").html();
        var driver = $(this).closest('tr').find("td:eq(7)").html();
        var date = $(this).closest('tr').find("td:eq(8)").html();
        
        $("#nameEvent").val(name);
        $("#amountOfPeopleEvent").val(amountOfPeople);
        $("#amountMadeEvent").val(amountMade);
        $("#productTypeEvent").val(productType);
        $("#timeStartedEvent").val(timeStarted);
        $("#timeEndedEvent").val(timeEnded);
        $("#driverEvent").val(driver);
        $("#dateEvent").val(date);
        $("#eventType").val(eventType);
        $("#saveEvent").text("Update");
        $("#addEventModal").modal();
        editMode = true;
       
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

            
          
   
   

   
    

   

