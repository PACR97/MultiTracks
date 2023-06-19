using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class artistDetails : System.Web.UI.Page
{
    DataTable DtSongs;
    DataTable DtAlbums;
    public DataTable DtArtist;
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();
        var artistIdQueryString = Request.QueryString["ArtistId"];
        if (artistIdQueryString == null)
        {
            Response.Redirect("default.aspx");
            return;
        }
        try
        {
            sql.Parameters.Add(new System.Data.SqlClient.SqlParameter("@artistId", artistIdQueryString));
            var result = sql.ExecuteStoredProcedureDS("GetArtistDetails", true);
            DtSongs = result.Tables[0];
            DtAlbums = result.Tables[1];
            DtArtist = result.Tables[2];

            rptSongs.DataSource = DtSongs;
            rptSongs.DataBind();

            rptAlbums.DataSource = DtAlbums;
            rptAlbums.DataBind();

            txtBiography.Text = DtArtist.Rows[0]["biography"].ToString();
            imgArtistHero.ImageUrl = DtArtist.Rows[0]["heroURL"].ToString();
            imgArtistHero.DescriptionUrl = DtArtist.Rows[0]["heroURL"].ToString();
            imgArtistHero.AlternateText = DtArtist.Rows[0]["title"].ToString();

            imgArtistProfile.ImageUrl = DtArtist.Rows[0]["imageURL"].ToString();
            imgArtistProfile.DescriptionUrl = DtArtist.Rows[0]["imageURL"].ToString();
            imgArtistProfile.AlternateText = DtArtist.Rows[0]["title"].ToString();
        }
        catch (Exception)
        {

            throw;
        }
    }
}