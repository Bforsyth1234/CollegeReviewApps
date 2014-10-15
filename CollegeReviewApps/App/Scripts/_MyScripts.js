var app = angular.module('_MyScripts', ['ngRoute']);
app.factory("colleges", function () {
    return [];
})

app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'App/Views/HomeView.Html',
        controller: 'HomeCtrl',
        title: 'Home'

    })
    .otherwise({
        redirectTo:
            '/'
    })
})

app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'App/Views/ReviewView.Html',
        controller: 'HomeCtrl',
        title: 'Home'

    })
    .otherwise({
        redirectTo:
            '/'
    })
})

// ['ui.bootstrap']