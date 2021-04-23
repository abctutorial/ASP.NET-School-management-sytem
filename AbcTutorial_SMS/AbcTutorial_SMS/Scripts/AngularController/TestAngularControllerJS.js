var MyApp = angular.module("ABCApp", []);

MyApp.controller("TestAngularController", function($scope) {


    $scope.ShowData = function() {


        var Mes = "";
        Mes = $scope.txtMessage;

        alert(Mes);

        $scope.txtMessage = "";
    };
});