$(function () {

    
    var editId = 0;
    
    var editMode = false;
   


    
    //until now is for showing the correct table
    //now for showing route modal
    $("#addExpense").on('click', function () {
        $("#addExpenseModal").modal();
        $("#other").hide();
        editMode = false;


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

    $('#name').change(function () {
        if ($("#name").val() == 'Other') {
            $("#other").show();
        }
        if ($("#name").val() != 'Other') {
            $("#other").hide();
        }

    });



    //saving field on route modal
    $("#saveExpense").on('click', function () {
        if ($("#name").val() == 'Other') {
            var name = $("#other").val()
        }
        else {
            var name = $("#name").val();
        }
        var date = $("#date").val();
        var amount = $("#amount").val();
        

        
        //up to hear dealing with other

        if (editMode == false) {
            $.post("/MoneySpent/AddExpense", { name: name, date: date, amount: amount }, function () {
            });
        }
        if (editMode == true) {
            $.post("/MoneySpent/UpdateExpense", { id: editId, name: name, date: date, amount: amount }, function () {
            });
        }
        $("#addExpenseModal").modal('hide');
        location.reload(true);
    });

  

    

    
    
    //delete route button
    $(".deleteExpense").on('click', function () {

        var currentButton = $(this);
        var id = currentButton.data('id');
        $.post("/MoneySpent/DeleteExpense", { id: id }, function () {
            location.reload(true);
        });
    })
    
    
    //this is code to edit route using same modal as add route, having the fields prefilled
    $(".editExpense").on('click', function () {
        var currentButton = $(this);
        editId = currentButton.data('id');
        var name = $(this).closest('tr').find("td:eq(0)").html();
        var date = $(this).closest('tr').find("td:eq(1)").html();
        var amount = $(this).closest('tr').find("td:eq(2)").html();
        if (name == 'Kliens' || name == 'Credit Card Bill' || name == 'Repairs' || name == 'Licensing Expenses' || name == 'Driver' || name == 'Parking' || name == 'Ices') {
            $("#name").val(name);
            $("#other").hide();
        }
        else {
            $("#name").val('Other');
            $("#other").show();
            $("#other").val(name);

        }
       
        $("#amount").val(amount);
        $("#date").val(date);
       

        $("#saveExpense").text("Update");
        $("#addExpenseModal").modal();
        editMode = true;

    })
})











