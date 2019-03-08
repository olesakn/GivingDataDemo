
app.controller('BooksController', function($scope, $location, $routeParams, BookService) {
    $scope.isLoading;
    $scope.books;
    $scope.numberOfResultsOptions;
    $scope.numberOfResults;
    $scope.keywords;

    $scope.viewBookDetails = viewBookDetails;
    $scope.getBooks = getBooks;

    construct();
    function construct() {
        $scope.books = [];                                                  // default to empty array
        $scope.numberOfResultsOptions = [5, 10, 20, 40];                    // list of select options
        
        $scope.keywords = $routeParams.keywords ? $routeParams.keywords : "National Parks";             // set from route else default
        $scope.numberOfResults = parseInt($routeParams.numberOfResults) ? parseInt($routeParams.numberOfResults) : 40;      // set from route else default

        getBooks();
    }
    
    function getBooks() {
        $scope.isLoading = true;

        // Persist params to url history
        if ($scope.keywords !== $routeParams.keywords || $scope.numberOfResults !== $scope.numberOfResults) {
            $location.path('/books/' + $scope.keywords + '/' + $scope.numberOfResults);
        }

        // Get list of books from the BookService 
        BookService.getBooks($scope.keywords, $scope.numberOfResults)
            .then(function (response) {
                $scope.books = response.data;
                $scope.isLoading = false;
            });
    }

    function viewBookDetails(book) {
        $location.path('/bookdetails/' + book.Id);
    }
    
});