
USE olesakco_GivingDataDemo
GO

CREATE TABLE dbo.BookReviews
(
	BookReviewId int identity(1,1) primary key not null,
	GoogleBookId varchar(30) not null,
	ReviewText varchar(max) not null,
	Rating int not null,
	ReviewerName varchar(300),
	CreatedDate datetime not null default(getdate())
)