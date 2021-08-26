using CraiglistAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CraiglistAPI.Controllers
{
    public class NewPostController : ApiController
    {

        public HttpResponseMessage Get()
        {
            string query = "dbo.spNewAdd_GetAllAdds";

            DataTable table = new DataTable();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(NewPost post)
        {
            try
            {
                string query = "dbo.spNewAdd_AddNewPost";

                DataTable table = new DataTable();

                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ObjectPrice", post.ObjectPrice));
                    cmd.Parameters.Add(new SqlParameter("@ObjectDescription", post.ObjectDescription));
                    cmd.Parameters.Add(new SqlParameter("@ObjectType", post.ObjectType));
                    cmd.Parameters.Add(new SqlParameter("@SellersEmail", post.SellersEmail));
                    cmd.Parameters.Add(new SqlParameter("@SellersPhoneNumber", post.SellersPhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@SellersState", post.SellersState));
                    cmd.Parameters.Add(new SqlParameter("@PhotoFileName", post.PhotoFileName));

                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception)
            {

                return "Failed to add";
            }
        }

        public string Put(NewPost post)
        {
            try
            {
                string query = "dbo.spNewAdd_UpdatePost";

                DataTable table = new DataTable();

                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ObjectPrice", post.ObjectPrice));
                    cmd.Parameters.Add(new SqlParameter("@ObjectDescription", post.ObjectDescription));
                    cmd.Parameters.Add(new SqlParameter("@ObjectType", post.ObjectType));
                    cmd.Parameters.Add(new SqlParameter("@SellersEmail", post.SellersEmail));
                    cmd.Parameters.Add(new SqlParameter("@SellersPhoneNumber", post.SellersPhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@SellersState", post.SellersState));
                    cmd.Parameters.Add(new SqlParameter("@PhotoFileName", post.PhotoFileName));
                    cmd.Parameters.Add(new SqlParameter("@PostId", post.PostId));

                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception)
            {

                return "Failed to update";
            }
        }

        public string Delete(int postId)
        {
            try
            {
                string query = @"delete from dbo.NewAdd where PostId= ('" + postId + "')";

                DataTable table = new DataTable();

                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {

                return "Failed to delete";
            }
        }

        [Route("api/NewPost/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + fileName);

                postedFile.SaveAs(physicalPath);

                return fileName;

            }
            catch (Exception)
            {
                return "default.png";
            }
        }
    }
}
