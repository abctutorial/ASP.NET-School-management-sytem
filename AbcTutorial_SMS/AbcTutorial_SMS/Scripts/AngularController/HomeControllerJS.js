var MyApp = angular.module("ABCApp", []);

MyApp.controller("HomeController", function ($scope, $http) {
    $scope.btnLogin = "Sign In";

    $scope.LoginData = function () {


        $scope.btnLogin = "Signing.....";
        $http({
            method: 'POST',
            url: '/Home/GetLoginInfo',
            data: $scope.UserDAO
        }).success(function (a) {
            window.location.href = "Index"
        }).error(function () {

            $scope.btnLogin = "Sign In";
            $scope.UserDAO = null;
            alert("Faild to Login");

        });




    };
});