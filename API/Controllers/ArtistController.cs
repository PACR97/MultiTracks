using API.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/artist")]
    public class ArtistController : ApiController
    {
        /// <summary>
        /// Search an artist by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Search")]
        public IHttpActionResult Search([FromUri] string name = "")
        {
            var sql = new SQL();
            sql.Parameters.Add(new System.Data.SqlClient.SqlParameter("@name", name));
            var result = sql.ExecuteStoredProcedureDT("GetArtistisFilterByName", true);
            return Ok(result);
        }


        /// <summary>
        /// Add new artist to Database
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Add")]
        public IHttpActionResult Add([FromBody] AddArtistDto artist)
        {
            if (artist == null) return BadRequest("Artist cannont be null");

            if (artist.Title == null || artist.Biography == null || artist.ImageUrl == null || artist.HeroUrl == null)
                return BadRequest("Some properties are null, please review it");

            var sql = new SQL();
            sql.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Title", artist.Title));
            sql.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Biography", artist.Biography));
            sql.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ImageURL", artist.ImageUrl));
            sql.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HeroURL", artist.HeroUrl));

            var result = sql.ExecuteStoredProcedure("CreateArtist", true);
            return Ok(new
            {
                Ok = result == 1,
                ArtistAdded = result == 1 ? artist : null
            });
        }

    }
}
