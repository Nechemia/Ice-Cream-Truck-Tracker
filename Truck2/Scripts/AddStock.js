$(function () {


    var editId = 0;

    var editMode = false;




    //until now is for showing the correct table
    //now for showing route modal
    $("#addStock").on('click', function () {
        $("#addStockModal").modal();

        editMode = false;


    });

    //disabling submit button if select fields aren't filled

    $("#saveStock").prop('disabled', true);
    $('.expense').keyup(function () {
        if ($("#date").val() == "" || $("#amount").val() == "") {
            $("#saveStock").prop("disabled", true);
        }
        else {
            $("#saveStock").prop("disabled", false);
        }
    });

    



    //saving field on route modal
    $("#saveStock").on('click', function () {
        
        var product = $("#product").val();
        var date = $("#date").val();
        var amount = $("#amount").val();

        if (editMode == false) {
            $.post("/addstock/addStock", { product: product, date: date, amount: amount }, function () {
            });
        }
        if (editMode == true) {
            $.post("/addstock/UpdateStock", { id: editId, product: product, date: date, amount: amount }, function () {
            });
        }
        $("#addStockModal").modal('hide');
        location.reload(true);
    });

   
    $(".deleteStock").on('click', function () {

        var currentButton = $(this);
        var id = currentButton.data('id');
        $.post("/addstock/Deletestock", { id: id }, function () {
            location.reload(true);
        });
    })


    //this is code to edit route using same modal as add route, having the fields prefilled
    $(".editStock").on('click', function () {
        var currentButton = $(this);
        editId = currentButton.data('id');
        var product = $(this).closest('tr').find("td:eq(0)").html();
        var amount = $(this).closest('tr').find("td:eq(1)").html();
        var date = $(this).closest('tr').find("td:eq(2)").html();
        
        $("#product").val(product);
        $("#amount").val(amount);
        $("#date").val(date);


        $("#saveStock").text("Update");
        $("#addStockModal").modal();
        editMode = true;

    })
});