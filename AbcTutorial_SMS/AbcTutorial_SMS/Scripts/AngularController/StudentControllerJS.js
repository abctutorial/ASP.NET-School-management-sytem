var MyApp = angular.module("ABCApp", []);

MyApp.controller("StudentController", function ($scope, $http) {

    $scope.btnSaveText = "Save";




    $http.get("/Student/ddlLoadBatch").then(function (d) {

        $scope.Batch = d.data;
    }, function (error) {
        alert("Faild");
    });





    $scope.LoadSectionByBatchID = function (BatchId) {

        $http.get("/Student/ddlLoadSectonbyBatchID?BatchId=" + BatchId).then(function (d) {

            $scope.Section = d.data;
        }, function (error) {
            alert("Faild");
        });
    };


    $scope.LoadStudentListByBatchID = function (BatchId) {

        $http.get("/Student/LoadData?BatchId=" + BatchId).then(function (d) {

            $scope.Student = d.data;
        }, function (error) {
            alert("Faild");
        });
    };


    $scope.SaveData = function () {

        if ($scope.btnSaveText == "Save") {
            $scope.btnSaveText = "Saving.....";
            $http({
                method: 'POST',
                url: '/Student/Save_Info',
                data: $scope.StudentDAO
            }).success(function (a) {
                $scope.btnSaveText = "Save";
                $scope.StudentDAO = null;
                alert("Operation Successful!! Student ID: 013");
            }).error(function () {
                alert("Faild");
            });
        } else {
            //$scope.btnSaveText = "Updating.....";
            //$http({
            //    method: 'POST',
            //    url: '/Course/Update_Info',
            //    data: $scope.CourseDAO
            //}).success(function (a) {
            //    $scope.btnSaveText = "Save";
            //    $scope.CourseDAO = null;
            //    alert(a);
            //}).error(function () {
            //    alert("Faild");
            //});
        }
    };





    //$http.get("/Student/LoadData").then(function (d) {

    //    $scope.Student = d.data;
    //}, function (error) {
    //    alert("Faild");
    //});



    $scope.DeleteMAsterData = function (StudentId) {

        $http.get("/Student/StatusChangeStudentByMAsterId?StudentId=" + StudentId).then(function (d) {

            alert(d.data);

            location.reload();
             

        },
            function (error) {
                alert("Faild");
            }
        );
    };



    $scope.GetOneRecord = function (MasterId) {
        $scope.btnSaveText = "Update";

        $http.get("/Student/GetMAsterDataByID?MasterId=" + MasterId).then(function (d) {


            $scope.StudentDAO = d.data[0];
        }, function (error) {
            alert("Faild");
        });
    };


});
