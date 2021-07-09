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
    public class UsersController : ApiController
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

        public string Post(Users post)
        {
            try
            {
                string query = @"insert into dbo.Users values
                                (
                                '" + post.UserName + @"',
                                '" + post.UserPassword + @"',
                                '" + post.UserEmail + @"',
                                '" + post.UserPhoneNumber + @"',
                                '" + post.UserState + @"')";

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

        public string Put(Users post)
        {
            try
            {
                string query = @"update dbo.NewAdd set 
                                 UserName= ('" + post.UserName + @"'),
                                 UserPassword= ('" + post.UserPassword + @"'),
                                 UserEmail= ('" + post.UserEmail + @"'),
                                 UserPhoneNumber= ('" + post.UserPhoneNumber + @"'),
                                 UserState= ('" + post.UserState + @"')
                                 where UserId= " + post.UserId + @"";

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

        [Route("api/Users/Login")]
        public int UserExist(Users user)
        {
            try
            {
                string query = "select Count(UserName) from dbo.Users where UserName= ('" + user.UserName + "') and UserPassword= ('" + user.UserPassword + "')";
                DataTable table = new DataTable();

                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CraigslistAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
