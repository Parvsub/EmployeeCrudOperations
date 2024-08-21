

$(document).ready(function () {
    alert("Praveen")
    GetMethod();


    $('#btnAddEmployee').click(function () {
        $('#addEmployeeModal').modal('show');
        $('#employeeForm')[0].reset();
        $('#employeeId').prop('readonly', false);
        $('#submitEmployeeForm').show();
        $('#updateEmployeeForm').hide();
    });

    $('#Closebuttun').click(function () {
        $('#addEmployeeModal').modal('hide');
    })
   
     
    $(document).on('click', '.delete-btn', function () {
        button = $(this);
        var id = button.data('id');
        DeleteEmployee(button, id);
    });

    //$(document).on('click', '.edit-btn', function () {
    //    var Id = $(this).data('id');
    //    GetEmployeeById(Id);
    //})


});

function GetMethod() {
    $.ajax({
        url: '/Employee/GetEmployees1',
        type: 'GET', // 'Type' should be 'type'
        content: 'json',
        success: function (data) {
           
            var rows = '';
            $.each(data, function (index, employee) {
                rows += '<tr>'; // Open the row
                rows += '<td>' + employee.id + '</td>'; // Use 'employee.id' for ID
                rows += '<td>' + employee.name + '</td>';
                rows += '<td>' + employee.companyName + '</td>';
                rows += '<td>' + employee.designation + '</td>';
                rows += '<td>';
                rows += '<button class="edit-btn" data-id="' + employee.id + '">Edit</button>';
                rows += '<button class="delete-btn" data-id="' + employee.id + '">Delete</button>';
                rows += '</td>';
                rows += '</tr>'; // Close the row
            });
            $('#employeeTable tbody').html(rows);
        },
        error: function (xhr, status, error) {
            console.error('AJAX Error:', status, error);
        }
    });
}


function AddEmployee() {
    var employeeData = {
        Id:$('#employeeId').val(),
        Name: $('#employeeName').val(),
        CompanyName: $('#employeeCompany').val(),
        Designation: $('#employeeDesignation').val()
    };

    $.ajax({
        url: '/Employee/addEmployee',
        type: 'Post',
        //contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: employeeData,
        success: function (response) {
            debugger;
            if (response.success) {
                $('#addEmployeeModal').modal('hide');
                alert('Employee added successfully');
                $('#submitEmployeeForm').prop('disabled', false);
                $('#employeeForm')[0].reset();

                GetMethod();
            } else {
                alert('Falied');
            }
        },
    });

}

function DeleteEmployee(button, id) {
    debugger
    var confirmation = confirm('are you sure want to delete');
    
        if (confirmation) {
            $.ajax({
                //url: '/Employee/DeleteEmployee?id=' + id,
                url: '/Employee/DeleteEmployee',
                data: { id: id },
                type: 'delete',
                dataType: 'json',
                success: function (resposne) {
                   
                    if (resposne.success) {
                        button.closest('tr').remove();
                    } else {
                        alert("Error:" + resposne.message);
                    }
                },


            });
        }
}

$(document).on('click', '.edit-btn', function () {
    var employeeId = $(this).data('id');

    // Fetch the employee details
    $.ajax({
        url: '/Employee/GetEmployeeById/' + employeeId,
        type: 'GET',
        dataType: 'json',
        success: function (employee) {
            debugger;
            // Populate the form with employee data
            $('#employeeId').val(employee.id);
            $('#employeeName').val(employee.name);
            $('#employeeCompany').val(employee.companyName);
            $('#employeeDesignation').val(employee.designation);

            // Set the modal title and button visibility
            $('#addEmployeeModalLabel').text('Edit Employee');
            $('#submitEmployeeForm').hide(); 
            $('#updateEmployeeForm').show();
            $('#employeeId').prop('disabled', true);

            // Show the modal
            $('#addEmployeeModal').modal('show');
        },
        error: function (xhr, status, error) {
            console.error('Error fetching employee details:', error);
        }
    });
});


function UpdateEmployee() {
    debugger
    var updatedEmployee = {
        id: $('#employeeId').val(),
        name: $('#employeeName').val(),
        companyName: $('#employeeCompany').val(),
        designation: $('#employeeDesignation').val()
    };

    $.ajax({
        url: '/Employee/UpdateEmployee',
        type: 'Post',
        data: updatedEmployee,
        dataType: 'json',
        success: function (response) {
            debugger
            $('#addEmployeeModal').modal('hide');
            GetMethod();
        },
        error: function (xhr, status, error) {
            $('#response').html('An error occurred: ' + error);
        }
});
}












