(() => {
    const app = angular.module("main");

    app.controller("upcommingCtrl", upcommingCtrl);

    function upcommingCtrl($scope, $http) {
        $http.get("/api/movies/upcomming").then((response) => {
            $scope.upcommingMovies = response.data.results;
        });
    }
})();