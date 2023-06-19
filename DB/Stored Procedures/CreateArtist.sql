CREATE PROCEDURE [dbo].[CreateArtist]
	@Title varchar(100),
	@Biography varchar(max),
	@ImageURL varchar(500),
	@HeroURL varchar(500)


AS
	INSERT INTO dbo.Artist
	(dateCreation, title, biography, imageURL, heroURL)
	VALUES
	(GETDATE(), @Title, @Biography, @ImageURL, @HeroURL)

	RETURN @@ROWCOUNT;
