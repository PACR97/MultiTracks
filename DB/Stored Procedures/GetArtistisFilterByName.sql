CREATE PROCEDURE [dbo].[GetArtistisFilterByName]
	@name varchar(100) = ''
AS
	SELECT * FROM dbo.Artist WHERE title LIKE CONCAT('%', @name, '%');
