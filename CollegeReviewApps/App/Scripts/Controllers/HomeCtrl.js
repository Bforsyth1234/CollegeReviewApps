app.controller("HomeCtrl", function ($scope, $http, $location, $routeParams, colleges) {
    $scope.colleges = colleges;

    $scope.AddCollege = function (college) {

        var value = {

            name: $scope.college, Year: "test"
        }
        $http({ method: 'POST', url: '/api/College', data: value })

        .success(
        function () {


            $http({ method: 'GET', url: '/api/College' })

                .success(function (data, status) {
                    for (var x in data) {
                        colleges.push(data[x]);
                        $scope.GetColleges();
                    }
                    $scope.college = "";
                })

                .error(function (data, status) { console.log(status); });
        }
        )
            .error(
            function () {
                console.log("error")
            });
    }


    $scope.GetColleges = function () {

        $http({ method: 'GET', url: '/api/College' })

            .success(function (data, status) {
                while (colleges.length) {
                    colleges.pop();
                }
                for (var x in data) {
                    colleges.push(data[x]);

                }
            })

            .error(function (data, status) { console.log(status); });
    }


    $scope.PutCollege = function (college) {
        alert("put")
        console.log(college)
        var value = {
            name: college.Name, Year: "test", id: college.id,
        }
        console.log(value)
        $http({ method: 'PUT', url: '/api/College', data: value })

        .success(
        function () {


            $http({ method: 'GET', url: '/api/College' })

                .success(function (data, status) {
                    for (var x in data) {
                        colleges.push(data[x]);
                    }
                    $scope.college = "";
                    $scope.GetColleges();
                })

                .error(function (data, status) { console.log(status); });
        }
        )
            .error(
            function () {
                console.log("error")
            });
    }

    $scope.DeleteCollege = function (college) {

        var value = {
            name: college.Name, Year: "test", id: college.id,
        }

        $http({ method: 'DELETE', url: '/api/College', data: value })

        .success(
        //success
            $scope.GetColleges()
        //successend
        ).error()
};
    $scope.GetColleges();


    ///modal below
    angular.module('myModule', ['ui.bootstrap']);
    var ModalDemoCtrl = function ($scope, $modal, $log) {

        $scope.items = ['item1', 'item2', 'item3'];

        $scope.open = function (size) {

            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: ModalInstanceCtrl,
                size: size,
                resolve: {
                    items: function () {
                        return $scope.items;
                    }
                }
            });
            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };
    };
    //modal above

});