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
    [RoutePrefix("api/song")]
    public class SongController : ApiController
    {
        /// <summary>
        /// Return a list of songs paginated
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("list")]
        public IHttpActionResult List([FromUri] Pagination pagination)
        {
            var sql = new SQL();
            sql.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PageSize", pagination.PageSize));
            sql.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Page", pagination.Page));
            var result = sql.ExecuteStoredProcedureDS("GetSongsPaged", true);

            //List of songs
            var records = result.Tables[0];

            //Pagination info returned from DB, contains total of records and Quantity of pages
            var paginationInfo = result.Tables[1];

            return Ok(new
            {
                paginationInfo = new
                {
                    Pages = paginationInfo.Rows[0]["Pages"],
                    TotalRecords = paginationInfo.Rows[0]["TotalRecords"],
                    CurrentPage = pagination.Page,
                    RecordsPerPage = pagination.PageSize
                },
                data = records
            });
        }
    }
}
