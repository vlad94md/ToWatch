(() => {
    let app = angular.module("main", ["ngRoute"]);
    
    app.run(["$rootScope", "scrollService", "$cacheFactory", ($rootScope, scrollService, $cacheFactory) => {
        $rootScope.movies = [];
        $cacheFactory("appCache", { capacity: 10 });

        $(window).on('scroll', () => {
            $rootScope.scrollPercent = scrollService.getScrollPercentage();
        })
    }]);

    app.config(['$routeProvider', '$locationProvider', function AppConfig($routeProvider, $locationProvider) {

        $routeProvider
        .when("/toprated", {
            templateUrl: "/angularBase/views/moviesView.html",
            controller: "topRatedCtrl"
        })
        .when("/popular", {
            templateUrl: "/angularBase/views/moviesView.html",
            controller: "popularCtrl"
        })
        .when("/", {
            templateUrl: "/angularBase/views/moviesView.html",
            controller: "upcommingCtrl"
        });

        // enable html5Mode for pushstate ('#'-less URLs)
        $locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('!');
    }]);

    //app.controller("tabController", function tabController($scope){
    //    $scope.pums = () => {
    //        const tabList = document.getElementsByClassName("nav-tabs")[0];
    //        const listItems = [].slice.call(tabList.children);

    //        listItems.forEach((item, index) => {
    //            item.onclick = () => {
    //                console.log("1233");
    //            }
    //        });
    //    }
    //});

    app.factory("scrollService", () => {
        function getWindowHeight() {
            return window.innerHeight ||
                   document.documentElement.clientHeight ||
                   document.body.clientHeight || 0;
        }
        function getWindowYscroll() {
            return window.pageYOffset ||
                   document.body.scrollTop ||
                   document.documentElement.scrollTop || 0;
        }
        function getDocHeight() {
            return Math.max(
                document.body.scrollHeight || 0,
                document.documentElement.scrollHeight || 0,
                document.body.offsetHeight || 0,
                document.documentElement.offsetHeight || 0,
                document.body.clientHeight || 0,
                document.documentElement.clientHeight || 0
            );
        }

        return {
            getScrollPercentage() {
                return ((getWindowYscroll() + getWindowHeight()) / getDocHeight()) * 100;
            }
        }
    });

    app.factory('cacheService', ($cacheFactory) => {
        return {
            getCacheInstance() {
                return $cacheFactory.get("appCache");
            }
        }
    });

    app.factory('tabService', () => {
        return {
            setActiveTab(tabName) {

                const tabList = document.getElementsByClassName("nav-tabs")[0];
                const listItems = [].slice.call(tabList.children);
                listItems.forEach((item, index) => {
                    item.onclick = () => {
                        if (item.innerText.toLowerCase() == (tabName || sessionStorage.activeTab)) {
                            item.className = "active";
                        }
                    }
                });

                sessionStorage.activeTab = tabName;
            }
        }
    })

    app.factory('movieService', () => {
        return {
            test: "123"
        };
    });

    app.factory('tralala', ($http, $rootScope) => {
        let isLoaded = false;

        function getMovies(url, page) {
            isLoaded = false;

            $http({
                method: 'GET',
                url: url,
                params: { page }
            })
            .then((response) => {
                $rootScope.movies = $rootScope.movies.concat(response.data.results);
            })
            .finally(() => {
                isLoaded = true;
            });
        }

        return {
            isLoaded,
            getMovies
        };
    });
})();
