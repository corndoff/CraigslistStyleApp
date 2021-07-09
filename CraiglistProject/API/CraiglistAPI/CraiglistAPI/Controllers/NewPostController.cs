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
            string query = @"select * from dbo.NewAdd";

            DataTable table = new DataTable();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(NewPost post)
        {
            try
            {
                string query = @"insert into dbo.NewAdd values
                                (
                                '" + post.ObjectPrice + @"',
                                '" + post.ObjectDescription + @"',
                                '" + post.ObjectType + @"',
                                '" + post.SellersEmail + @"',
                                '" + post.SellersPhoneNumber + @"',
                                '" + post.SellersState + @"',
                                '" + post.PhotoFileName + @"')";

                DataTable table = new DataTable();

                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
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
                string query = @"update dbo.NewAdd set 
                                 ObjectPrice= ('" + post.ObjectPrice + @"'),
                                 ObjectDescription= ('" + post.ObjectDescription + @"'),
                                 ObjectType= ('" + post.ObjectType + @"'),
                                 SellersEmail= ('" + post.SellersEmail + @"'),
                                 SellersPhoneNumber= ('" + post.SellersPhoneNumber + @"'),
                                 SellersState= ('" + post.SellersState + @"'),
                                 PhotoFileName= ('" + post.PhotoFileName + @"')
                                 where PostId= " + post.PostId + @"";

                DataTable table = new DataTable();

                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
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
