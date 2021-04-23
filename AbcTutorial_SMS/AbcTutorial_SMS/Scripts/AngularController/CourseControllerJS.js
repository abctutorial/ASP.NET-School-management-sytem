var MyApp = angular.module("ABCApp", []);

MyApp.controller("CourseController", function ($scope, $http) {



    $scope.btnSaveTextCo = "Save";


    $scope.SaveData = function () {

        if ($scope.btnSaveTextCo == "Save") {
            $scope.btnSaveTextCo = "Saving.....";
            $http({
                method: 'POST',
                url: '/Course/Save_Info',
                data: $scope.CourseDAO
            }).success(function (a) {
                $scope.btnSaveTextCo = "Save";
                $scope.CourseDAO = null;
                alert(a);
            }).error(function () {
                alert("Faild");
            });
        } else {
            $scope.btnSaveTextCo = "Updating.....";
            $http({
                method: 'POST',
                url: '/Course/Update_Info',
                data: $scope.CourseDAO
            }).success(function (a) {
                $scope.btnSaveTextCo = "Save";
                $scope.CourseDAO = null;
                alert(a);
            }).error(function () {
                alert("Faild");
            });
        }
    };



    $http.get("/Course/ddlLoadBatch").then(function (d) {

        $scope.Batch = d.data;
    }, function (error) {
        alert("Faild");
    });


    $scope.LoadSectionByBatchID = function(BatchId) {

        $http.get("/Course/ddlLoadSectonbyBatchID?BatchId=" + BatchId).then(function(d) {

            $scope.Section = d.data;
        }, function(error) {
            alert("Faild");
        });
    };




    $http.get("/Course/LoadData").then(function (d) {

        $scope.Course = d.data;
    }, function (error) {
        alert("Faild");
    });




    $scope.DeleteMAsterData = function (CourseId) {

        $http.get("/Course/ReomveDataByMAsterId?CourseId=" + CourseId).then(function (d) {

            alert(d.data);
            $http.get("/Course/LoadData").then(function (d) {

                $scope.Course = d.data;
            }, function (error) {
                alert("Faild");
            });

        },
            function (error) {
                alert("Faild");
            }
        );
    };


    $scope.GetOneRecord = function (CourseId) {
     

        $http.get("/Course/GetMAsterDataByID?MasterId=" + CourseId).then(function (d) {
           
           
            
           
              $scope.CourseDAO = d.data[0];
              $scope.btnSaveTextCo = "Update";
              $http.get("/Course/ddlLoadSectonbyBatchID?BatchId=" + d.data[0].BatchId).then(function (d) {

                  $scope.Section = d.data;
              }, function (error) {
                  alert("Faild");
              });
        


        }, function (error) {
            alert("Faild");
        });
    };

});