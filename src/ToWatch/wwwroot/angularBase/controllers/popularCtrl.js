(() => {
    const app = angular.module("main");

    app.controller("popularCtrl", ["$rootScope", "$scope", "$http", "$window", "scrollService", function topRatedCtrl($rootScope, $scope, $http, $window, scrollService) {
        sessionStorage.activeTab = "popular";
        const url = "/api/movies/popular";
        $scope.isLoaded = false;
        let page = 1;

        $http({
            method: 'GET',
            url: url,
            params: { page }
        })
        .then((response) => {
            $scope.movies = response.data.results;
        })
        .finally(() => {
            $scope.isLoaded = true;
            page++;
        });

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
                        $scope.movies = $scope.movies.concat(response.data.results);
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