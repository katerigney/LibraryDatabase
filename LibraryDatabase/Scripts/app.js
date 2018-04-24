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

        $scope.checkOutBook = () => {
            console.log($scope.bookToLend, $scope.userEmail);
            //search based on user input (title ) to get ID
            $http({
                method: "GET",
                url: `/api/searchbooks?title=${$scope.bookToLend}`
            }).then(resp => {
                console.log(resp.data);
                $scope.currentBook = resp.data;
                console.log(currentBook)
                }).then(

            //then use ID to put (checkout)
            $http({
                method: "PUT",
                url: `api/CheckOutManagement/${currentBook.ID}`,
                data: { Email: "$scope.userEmail" }
            }).then(resp => {
                console.log(resp.data);
                $scope.checkOutReciept = resp.data;
            }))     
        }
    }]);

//for check in will still need book ID