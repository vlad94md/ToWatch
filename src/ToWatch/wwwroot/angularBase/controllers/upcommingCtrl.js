(() => {
    const app = angular.module("main");

    app.controller("upcommingCtrl", ["$rootScope", "$scope", "$http", "$window", "scrollService", "movieService", "tralala", function upcommingCtrl($rootScope, $scope, $http, $window, scrollService, movieService, tralala) {
        sessionStorage.activeTab = "comming soon";
        const url = "/api/movies/upcomming";

        $scope.isLoaded = false;
        let page = 1;
        let movieObj = {
        }
        tralala.getMovies(url, page++);
        //$http({
        //    method: 'GET',
        //    url: url,
        //    params: { page }
        //})
        //.then((response) => {
        //    $scope.movies = response.data.results;
        //})
        //.finally(() => {
        //    $scope.isLoaded = true;
        //    page++;
        //    movieService.movies = $scope.movies;
        //});

       

        let req = {};
        $(window).on('scroll', () => {
            if ($rootScope.scrollPercent > 95) {
                if (angular.equals({}, req)) {
                    $scope.isLoaded = false;
                    req = { x: 123 };
                    $http({
                        method: 'GET',
                        url: url,
                        params: { page }
                    })
                    .then((response) => {
                        $rootScope.movies = $rootScope.movies.concat(response.data.results);
                    })
                    .finally(() => {
                        $scope.isLoaded = true;
                        page++;
                        req = {};
                    });
                }
            }
        });
    }]);
})();