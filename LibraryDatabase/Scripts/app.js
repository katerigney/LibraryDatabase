angular.
    module("libraryApp", [])
    .controller("mainController", ["$scope", "$http", ($scope, $http) => {

        $scope.getAllBooks = () => {
            $http({
                method: "GET",
                url: "/api/books"
            }).then(resp => {
                console.log(resp.data);
                $scope.allBooks = resp.data;
                })
        }
        
        $scope.getAvailableBooks = () => {
            $http({
                method: "GET",
                url: "/api/availablebooks"
            }).then(resp => {
                console.log(resp.data);
                $scope.availableBooks = resp.data;
            })
        }

        //$scope.checkOutBook = (ID, userEmail) => {
        //    $http({
        //        method: "PUT",
        //        url: 'api/CheckOutManagement/${ID}/',
        //        data: JSON.stringify(email:'${userEmail}')
        //    }).then(resp => {
        //        console.log(resp.data);
        //        $scope.checkOutReciept = resp.data;
        //    })
        //}
        
    }]);