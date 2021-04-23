var MyApp = angular.module("ABCApp", []);

MyApp.controller("BatchController", function($scope, $http) {
    $scope.btnSaveTextBatch = "Save";

    $scope.SaveData = function () {

        if ($scope.btnSaveTextBatch == "Save") {
            $scope.btnSaveTextBatch = "Saving.....";
            $http({
                method: 'POST',
                url: '/Batch/Save_Info',
                data: $scope.BatchDAO
            }).success(function(a) {
                $scope.btnSaveTextBatch = "Save";
                $scope.BatchDAO = null;
                alert(a);
            }).error(function() {
                alert("Faild");
            });
        } else {
            $scope.btnSaveTextBatch = "Updating.....";
            $http({
                method: 'POST',
                url: '/Batch/Update_Info',
                data: $scope.BatchDAO
            }).success(function(a) {
                $scope.btnSaveTextBatch = "Save";
                $scope.BatchDAO = null;
                alert(a);
            }).error(function() {
                alert("Faild");
            });

        }


       

    };


    $http.get("/Batch/LoadData").then(function(d) {

        $scope.Batch = d.data;
    }, function(error) {
        alert("Faild");
    });



    $scope.DeleteMAsterData = function (BatchId) {

        $http.get("/Batch/ReomveDataByMAsterId?BatchId=" + BatchId).then(function (d) {

            alert(d.data);
            $http.get("/Batch/LoadData").then(function (d) {

                $scope.Batch = d.data;
            }, function (error) {
                alert("Faild");
            });

        },
            function(error) {
                alert("Faild");
            }
        );
    };


    $scope.GetOneRecord = function(MasterId) {
        $scope.btnSaveTextBatch = "Update";

        $http.get("/Batch/GetMAsterDataByID?MasterId=" + MasterId).then(function (d) {


            $scope.BatchDAO = d.data[0];
        }, function(error) {
            alert("Faild");
        });
    };


});
