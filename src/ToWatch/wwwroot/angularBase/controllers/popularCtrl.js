(() => {
    const app = angular.module("main");

    app.controller("popularCtrl", popularCtrl);

    function popularCtrl($scope, $http) {
        $scope.isLoaded = false;

        $http.get("/api/movies/popular").then((response) => {
            $scope.movies = response.data.results;
        }).finally(() => {
            $scope.isLoaded = true;
        });
    }
})();