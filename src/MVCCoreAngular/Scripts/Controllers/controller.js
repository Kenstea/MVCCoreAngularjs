(function () {
    'use strict';
    angular.module("employeeapp").controller('employeeController', ['$scope', 'EmployeeService', function ($scope, EmployeeService) {

        $scope.divEmployee = false;
        GetAllEmployee();
        //To Get All Records 
        function GetAllEmployee() {
            debugger;
            var getData = EmployeeService.getEmployees();
            debugger;
            getData.then(function (emp) {
                $scope.employees = emp.data;
                console.log($scope.employees);
            }, function () {
                alert('Error in getting records');
                console.log(error);
            });
        }

        $scope.AddEmployeeDiv = function () {
            debugger
            ClearFields();
            $scope.Action = "Add";
            $scope.divEmployee = true;
        }

        $scope.editEmployee = function (employee) {
            debugger;
            var getData = EmployeeService.getEmployee(employee.employeeId);
            getData.then(function (emp) {
                $scope.employee = emp.data;
                $scope.employeeId = employee.employeeId;
                $scope.employeeCode = employee.employeeCode;
                $scope.firstName = employee.firstName;
                $scope.lastName = employee.lastName;
                $scope.Action = "Update";
                $scope.divEmployee = true;
            },
            function () {
                alert('Error in getting records');
            });
        }

        $scope.AddUpdateEmployee = function () {

            var Employee = {
                EmployeeCode: $scope.employeeCode,
                FirstName: $scope.firstName,
                LastName: $scope.lastName
            };
            var getAction = $scope.Action;

            if (getAction == "Update") {
                Employee.EmployeeId = $scope.employeeId;
                debugger;
                var getData = EmployeeService.updateEmp(Employee);
                getData.then(function (msg) {
                    GetAllEmployee();
                    alert(msg.data);
                    $scope.divEmployee = false;
                }, function () {
                    alert('Error in updating record');
                });
            } else {
                debugger;
                var getData = EmployeeService.AddEmp(Employee);
                console.log(Employee);
                getData.then(function (msg) {
                    GetAllEmployee();
                    alert(msg.data);
                    $scope.divEmployee = false;
                }, function () {
                    alert('Error in adding record');
                });
            }
        }


        $scope.deleteEmployee = function (employee) {
            alert(employee.employeeId);
            debugger;
            var getData = EmployeeService.DeleteEmp(employee.employeeId);
            getData.then(function (msg) {
                GetAllEmployee();
                alert('Employee Deleted');
            }, function () {
                alert('Error in Deleting Record');
            });
        }



        function ClearFields() {
            $scope.employeeId = "";
            $scope.employeeCode = "";
            $scope.firstName = "";
            $scope.lastName = "";
        }



    }]);
})();

