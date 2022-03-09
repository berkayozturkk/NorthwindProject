$(document).ready(function () {

    //var tableName = "<tr>";
    //tableName += "<th>" + EmployeeID + "</th>";
    //tableName += "<th>" + LastName + "</th>";
    //tableName += "<th>" + FirstName + "</th>";
    //tableName += "<th>" + Title + "</th>";
    //tableName += "<th>" + TitleOfCourtesy + "</th>";
    //tableName += "<th>" + City + "</th>";
    //tableName += "<th>" + Country + "</th>";
    //tableName += "<tr>";
    //$('tableName').append(tableName);

    //$.ajax({
    //    url: "/Employees/EmplooyeToList",
    //    dataType: "JSON",
    //    type: "GET",
    //    success: function (data) {
    //        $.each(data, function (index, item) {
    //            var row = "<tr>";
    //            row += "<td>" + item.EmployeeID + "</td>";
    //            row += "<td>" + item.LastName + "</td>";
    //            row += "<td>" + item.FirstName + "</td>";
    //            row += "<td>" + item.Title + "</td>";
    //            row += "<td>" + item.TitleOfCourtesy + "</td>";
    //            row += "<td>" + item.City + "</td>";
    //            row += "<td>" + item.Country + "</td>";
    //            row += "<td>" + "</td>";
    //            row += "</tr>";
    //            $('#employeesData').append(row);
    //        })
    //    }
    //})
    });

    function load() {

        $.ajax({
            url: "/Employees/EmplooyeToList",
            dataType: "JSON",
            type: "GET",
            success: function (data) {
                $.each(data, function (index, item) {
                    var row = "<tr>";
                    row += "<td>" + item.EmployeeID + "</td>";
                    row += "<td>" + item.LastName + "</td>";
                    row += "<td>" + item.FirstName + "</td>";
                    row += "<td>" + item.Title + "</td>";
                    row += "<td>" + item.TitleOfCourtesy + "</td>";
                    row += "<td>" + item.City + "</td>";
                    row += "<td>" + item.Country + "</td>";
                    row += "</tr>";
                    $('#employeesData').append(row);
                })
            }
        })
    }

    function unload() {
        $('#employeesData').empty();
    }

    function addEmplooye() {

        var employee = {
            LastName: $("#lastName").val(),
            FirstName: $("#firstName").val(),
            Title: $("#title").val(),
            TitleOfCourtesy: $("#titleOfCourtesy").val(),
            City: $("#city").val(),
            Country: $("#country").val(),
        };

        $.ajax({
            url: "/Employees/AddEmplooye", //+employee,
            dataType: "json",
            data: employee,
            type: "POST",
            success: function (data) {

            }
        })

    }

    function deleteEmployee() {

        let id = $("#id").val()

        /*        alert(id);*/
        $.ajax({
            url: "/Employees/DeleteEmplooye/" + id,
            dataType: "json",
            type: "POST",
            success: function (func) {

            }
        });

        load();
    }

function GetByName() {
    $("#GetByName").click(function () {
            let lastName = $("#lastName").val()
            let firstName = $("#firstName").val()
    })
}

function GetById() {

        unload()
        let id = $("#GetById").val()

        $.ajax({
            url: "/Employees/GetById",
            dataType: "JSON",
            type: "GET",
            data: { id: id },
            success: function (data) {
                $.each(data, function (index, item) {
                    var row = "<tr>";
                    row += "<td>" + item.EmployeeID + "</td>";
                    row += "<td>" + item.LastName + "</td>";
                    row += "<td>" + item.FirstName + "</td>";
                    row += "<td>" + item.Title + "</td>";
                    row += "<td>" + item.TitleOfCourtesy + "</td>";
                    row += "<td>" + item.City + "</td>";
                    row += "<td>" + item.Country + "</td>";
                    row += "</tr>";
                    $('#employeesData').append(row);
                })
            }
        })
    }


