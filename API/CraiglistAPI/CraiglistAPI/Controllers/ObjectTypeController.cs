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
    public class ObjectTypeController : ApiController
    {
        [Route("api/NewPost/GetAllTypes")]
        public HttpResponseMessage GetAllTypes()
        {
            string query = "select TypeName from dbo.ObjectTypes";

            DataTable table = new DataTable();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
            using (var cmd = new SqlCommand("dbo.SPObjectTypes_GetTypeName", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                //cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
