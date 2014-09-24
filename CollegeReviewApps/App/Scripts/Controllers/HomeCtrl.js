app.controller("HomeCtrl", function ($scope, $http, $location, $routeParams, colleges) {
    $scope.colleges = colleges;
    $scope.AddCollege = function (college) {
        $http({ method: 'POST', url: '/api/College', data:{name:$scope.College.Name} })
        
        //.success(
        //function () {
        //    $scope.GetColleges();
        //})
        //    .error(
        //    function () {
        //        console.log("error")
        //    });
    }
    $scope.GetColleges = function () {

        $http({ method: 'GET', url: '/api/College' })

            .success(function (data, status) {
                for (var x in data) {
                    colleges.push(data[x]);
                }
            })

            .error(function (data, status) { console.log(status); });
    }
    $scope.GetColleges();

});