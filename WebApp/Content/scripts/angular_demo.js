angular.module("KendoAutoComplete", ["kendo.directives"])
    .controller("MyCtrl", function (foodSvc, $scope) {
        $scope.foodNameChange = function () {
            $scope.foods = [];
            console.log("event :: change");
            foodSvc.getFoods($scope.food, 1)
                .then(function (payload) {
                    angular.forEach(payload, function (food) {
                        console.log(food);
                        $scope.foods.push(food.Long_Desc);
                    });
                });
            
            
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