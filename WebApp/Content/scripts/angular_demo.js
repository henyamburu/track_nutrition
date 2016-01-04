angular.module("KendoAutoComplete", ["kendo.directives"])
    .controller("MyCtrl", function (foodSvc, $scope) {
        $scope.countryNames = [
        "Albania",
        "Andorra",
        "Armenia",
        "Austria",
        "Azerbaijan",
        "Belarus",
        "Belgium",
        "Bosnia & Herzegovina",
        "Bulgaria",
        "Croatia",
        "Cyprus",
        "Czech Republic",
        "Denmark",
        "Estonia",
        "Finland",
        "France",
        "Georgia",
        "Germany",
        "Greece",
        "Hungary",
        "Iceland",
        "Ireland",
        "Italy",
        "Kosovo",
        "Latvia",
        "Liechtenstein",
        "Lithuania",
        "Luxembourg",
        "Macedonia",
        "Malta",
        "Moldova",
        "Monaco",
        "Montenegro",
        "Netherlands",
        "Norway",
        "Poland",
        "Portugal",
        "Romania",
        "Russia",
        "San Marino",
        "Serbia",
        "Slovakia",
        "Slovenia",
        "Spain",
        "Sweden",
        "Switzerland",
        "Turkey",
        "Ukraine",
        "United Kingdom",
        "Vatican City"
        ];
        $scope.countryNameChange = function () {
            console.log("event :: change");
            console.log(foodSvc.getFoods($scope.country, 1));
        }
    })
    .service("foodSvc", function Profile($http, $q) {
        return {
            getFoods: function (value, pageNum) {
                var deferred = $q.defer();
                $http.get('/api/NutritionTracker/foods?value=' + value + '&pageNumber=' + pageNum)
                    .success(function (data) {
                        deferred.resolve(data);
                    }).error(function (msg, code) {
                        deferred.reject(msg);
                        $log.error(msg, code);
                    });
                return deferred.promise;
            }
        }
    });