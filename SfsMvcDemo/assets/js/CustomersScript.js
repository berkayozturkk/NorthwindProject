
function GetByCustomers() {
    
    let CompanyName = $("#CompanyName").val();
    let ContactName = $("#ContactName").val();
    let ContactTitle = $("#ContactTitle").val();

    $.ajax({
        url: "/Customers/GetByCustomers/",
        dataType: "JSON",
        data: { CompanyName: CompanyName, ContactName: ContactName, ContactTitle: ContactTitle },
        type: "GET",
        success: function (data) {
            
          
            $.each(data, function (index, item) {
                var row = "<tr>";
                row += "<td>" + item.CustomerID + "</td>";
                row += "<td>" + item.CompanyName + "</td>";
                row += "<td>" + item.ContactName + "</td>";
                row += "<td>" + item.ContactTitle + "</td>";
                row += "<td>" + item.Address + "</td>";
                row += "<td>" + item.City + "</td>";
                row += "<td>" + item.Region + "</td>";
                row += "<td>" + item.Country + "</td>";
                row += "<td>" + item.Phone + "</td>";
                row += "</tr>";
                $('#customersData').append(row);
            });
        },
        error: function () {
            alert('hata');
        }
    });
}