
app.service('BookService', function($http) {
    return {

        getBooks: function (keywords, numberOfResults) {
            return $http.get('/api/books?keywords=' + keywords + '&maxRecords=' + numberOfResults);
        },
        getBook: function (bookId) {
            return $http.get('/api/books?id=' + bookId);
        },
        getBookReviews: function (bookId) {
            return $http.get('/api/bookReviews?id=' + bookId);
        },
        addBookReview: function (bookReview) {
            return $http.put('/api/bookReviews', bookReview);
        }
    };
});