CREATE PROCEDURE [dbo].[GetSongsPaged]
	@PageSize int,
	@Page int
AS
	SELECT * FROM dbo.Song
	ORDER BY Song.title
	OFFSET(@Page - 1) * @PageSize ROWS 
	FETCH NEXT @PageSize ROWS ONLY

	SELECT CEILING(COUNT(*) / @PageSize) Pages, COUNT(*) TotalRecords FROM dbo.Song

