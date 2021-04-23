var MyApp = angular.module("ABCApp", []);

MyApp.controller("SectionController", function ($scope, $http) {
    $scope.btnSaveText = "Save";

    $http.get("/Section/ddlLoadBatch").then(function (d) {

        $scope.Batch = d.data;
    }, function (error) {
        alert("Faild");
    });

    $scope.SaveData = function() {

        if ($scope.btnSaveText == "Save") {
            $scope.btnSaveText = "Saving.....";
            $http({
                method: 'POST',
                url: '/Section/Save_Info',
                data: $scope.SectionDAO
            }).success(function(a) {
                $scope.btnSaveText = "Save";
                $scope.SectionDAO = null;
                alert(a);
            }).error(function() {
                alert("Faild");
            });
        } else {
            $scope.btnSaveText = "Updating.....";
            $http({
                method: 'POST',
                url: '/Section/Update_Info',
                data: $scope.SectionDAO
            }).success(function (a) {
                $scope.btnSaveText = "Save";
                $scope.SectionDAO = null;
                alert(a);
            }).error(function () {
                alert("Faild");
            });
        }
    };





    $http.get("/Section/LoadData").then(function (d) {

        $scope.Section = d.data;
    }, function (error) {
        alert("Faild");
    });




    $scope.GetOneRecord = function (MasterId) {
      


        if (MasterId != "0") {
            $http.get("/Section/GetMAsterDataByID?MasterId=" + MasterId).then(function (d) {
           
                $scope.CourseDAO = d.data[0];
                alert('sssssssssssss');

            }, function (error) {
            alert("Faild");
        });
        }
    };


    $scope.DeleteMAsterData = function (SectionId) {

        $http.get("/Section/ReomveDataByMAsterId?SectionId=" + SectionId).then(function (d) {

            alert(d.data);
            $http.get("/Section/LoadData").then(function (d) {

                $scope.Section = d.data;
            }, function (error) {
                alert("Faild");
            });

        },
            function (error) {
                alert("Faild");
            }
        );
    };


});