using CraiglistAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CraiglistAPI.Controllers
{
    public class StatesController : ApiController
    {
        [Route("api/NewPost/GetAllStates")]
        public HttpResponseMessage GetState()
        {
            string query = "select StateName from dbo.States";

            DataTable table = new DataTable();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
            using (var cmd = new SqlCommand("dbo.spStates_GetAllStateNames", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
