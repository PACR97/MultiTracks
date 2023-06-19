CREATE PROCEDURE [dbo].[GetArtistDetails]
	@artistId int
AS
	SELECT TOP 3
	Song.title SongName, 
	Song.bpm, 
	Song.multitracks, 
	Song.customMix, 
	Song.rehearsalMix, 
	Song.songSpecificPatches, 
	Song.chart, 
	Song.proPresenter,
	Album.title AlbumName,
	Album.imageURL AlbumImage
FROM dbo.Song 
inner join dbo.Album on Song.albumID = Album.albumID
WHERE Song.artistID = @artistId and Album.artistID = @artistId

SELECT 
	Album.title, Album.imageURL 
FROM dbo.Album
WHERE Album.artistID = @artistId

SELECT 
	title, biography, imageURL, heroURL 
FROM dbo.Artist
WHERE Artist.artistID = @artistId
