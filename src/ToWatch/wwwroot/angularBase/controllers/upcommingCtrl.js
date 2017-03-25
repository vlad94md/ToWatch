(() => {
    const app = angular.module("main");

    app.controller("upcommingCtrl", upcommingCtrl);

    function upcommingCtrl($scope, $http, $window) {
        $scope.isLoaded = false;
        $scope.page = 2;
        $http.get("/api/movies/upcomming").then((response) => {
            $scope.movies = response.data.results;
        }).finally(() => {
            $scope.isLoaded = true;

            //$location.hash("bottom");
            //$anchorScroll();
        });
    }
})();