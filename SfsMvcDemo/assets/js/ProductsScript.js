////$(document).ready(function () {

////    $.ajax({
////        url: "/Products/GetProductList",
////        dataType: "JSON",
////        type: "GET",
////        success: function (data) {
////            $.each(data, function (index, item) {
////                var row = "<tr>";
////                row += "<td>" + item.ProductID + "</td>";
////                row += "<td>" + item.ProductName + "</td>";
////                row += "<td>" + item.QuantityPerUnit + "</td>";
////                row += "<td>" + item.UnitPrice + "</td>";
////                row += "<td>" + item.UnitsInStock + "</td>";
////                row += "<td>" + item.UnitsOnOrder + "</td>";
////                row += "<td>" + item.ReorderLevel + "</td>";
////                row += "</tr>";
////                $('#productsData').append(row);
////            })
////        }
////    })
////});

function load() {

    $.ajax({
        url: "/Products/GetProductList",
        dataType: "JSON",
        type: "GET",
        success: function (data) {

            $.each(data, function (index, item) {
                var row = "<tr>";
                row += "<td>" + item.ProductID + "</td>";
                row += "<td>" + item.ProductName + "</td>";
                row += "<td>" + item.QuantityPerUnit + "</td>";
                row += "<td>" + item.UnitPrice + "</td>";
                row += "<td>" + item.UnitsInStock + "</td>";
                row += "<td>" + item.UnitsOnOrder + "</td>";
                row += "<td>" + item.ReorderLevel + "</td>";
                row += "</tr>";
                $('#productsData').append(row);
            })
        }
    })
}

function unload() {
    $('#productsData').empty();
}

function loadUnitsInStock() {

    unload()

    $.ajax({
        url: "/Products/GetOrderByToUnitsInStock",
        dataType: "JSON",
        type: "GET",
        success: function (data) {
            $.each(data, function (index, item) {
                var row = "<tr>";
                row += "<td>" + item.ProductID + "</td>";
                row += "<td>" + item.ProductName + "</td>";
                row += "<td>" + item.QuantityPerUnit + "</td>";
                row += "<td>" + item.UnitPrice + "</td>";
                row += "<td>" + item.UnitsInStock + "</td>";
                row += "<td>" + item.UnitsOnOrder + "</td>";
                row += "<td>" + item.ReorderLevel + "</td>";
                row += "</tr>";
                $('#productsData').append(row);
            })
        }
    })
}

function loadUnitsOnOrder() {

    unload()

    $.ajax({
        url: "/Products/GetOrderByToUnitsOnOrder",
        dataType: "JSON",
        type: "GET",
        success: function (data) {
            $.each(data, function (index, item) {
                var row = "<tr>";
                row += "<td>" + item.ProductID + "</td>";
                row += "<td>" + item.ProductName + "</td>";
                row += "<td>" + item.QuantityPerUnit + "</td>";
                row += "<td>" + item.UnitPrice + "</td>";
                row += "<td>" + item.UnitsInStock + "</td>";
                row += "<td>" + item.UnitsOnOrder + "</td>";
                row += "<td>" + item.ReorderLevel + "</td>";
                row += "</tr>";
                $('#productsData').append(row);
            })
        }
    })
}

function loadUnitPrice() {

    unload()

    $.ajax({
        url: "/Products/GetOrderByToUnitPrice",
        dataType: "JSON",
        type: "GET",
        success: function (data) {
            $.each(data, function (index, item) {
                var row = "<tr>";
                row += "<td>" + item.ProductID + "</td>";
                row += "<td>" + item.ProductName + "</td>";
                row += "<td>" + item.QuantityPerUnit + "</td>";
                row += "<td>" + item.UnitPrice + "</td>";
                row += "<td>" + item.UnitsInStock + "</td>";
                row += "<td>" + item.UnitsOnOrder + "</td>";
                row += "<td>" + item.ReorderLevel + "</td>";
                row += "</tr>";
                $('#productsData').append(row);
            })
        }
    })
}

function GetByProductNameList() {

    let ProductName = $("#ProductName").val()
    $.ajax({
        url: "/Products/GetByProductNameList",
        data: { ProductName: ProductName },
        dataType: "JSON",
        type: "GET",
        success: function (data) {
            $.each(data, function (index, item) {
                var row = "<tr>";
                row += "<td>" + item.ProductID + "</td>";
                row += "<td>" + item.ProductName + "</td>";
                debugger;
                row += "<td>" + item.QuantityPerUnit + "</td>";
                row += "<td>" + item.UnitPrice + "</td>";
                row += "<td>" + item.UnitsInStock + "</td>";
                row += "<td>" + item.UnitsOnOrder + "</td>";
                row += "<td>" + item.ReorderLevel + "</td>";
                row += "</tr>";
                $('#productsData').append(row);
            })
        }
    })
}

