(function () {
    'use strict';
    angular.module("employeeapp").factory('EmployeeService', ['$http', function ($http) {
        var EmployeeService = {};
        EmployeeService.getEmployees = function () {
            debugger;
            return $http.get("/Home/GetDetails");
        };


        EmployeeService.DeleteEmp = function (employeeId) {

            var response = $http({
                method: "post",
                url: "/Home/DeleteEmployee",
                params: {
                    employeeId: JSON.stringify(employeeId)
                }
            });
            return response;
        };


        // get Employee By Id
        EmployeeService.getEmployee = function (employeeID) {
            var response = $http({
                method: "post",
                url: "/Home/getEmployeeByNo",
                params: {
                    id: JSON.stringify(employeeID)
                }
            });
            return response;
        }

        // Update Employee
        EmployeeService.updateEmp = function (employee) {
            var response = $http({
                method: "post",
                url: "/Home/UpdateEmployee",
                params: {
                    employeeID: JSON.stringify(employee.EmployeeId),
                    employeeCode: JSON.stringify(employee.EmployeeCode),
                    firstName: JSON.stringify(employee.FirstName),
                    lastName: JSON.stringify(employee.LastName),
                },
            });
            return response;
        }

        EmployeeService.AddEmp = function (employee) {
            console.log(employee);
            var response = $http({
                method: "post",
                url: "/Home/AddEmployee",
                params: {
                    employeeCode: JSON.stringify(employee.EmployeeCode),
                    firstName: JSON.stringify(employee.FirstName),
                    lastName: JSON.stringify(employee.LastName),
                },
            });
            return response;
        }

        return EmployeeService;
    }


    ]);
})();
