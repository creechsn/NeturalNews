using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using NeutralNews.Models;
using System.Net.Http;
using Microsoft.IdentityModel.Protocols;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace NeutralNews
{
    public class DataController : Controller
    {
        public ActionResult Index()
        {
            List<ArticleData> articlesList = new List<ArticleData>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Source_Data", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var article = new ArticleData();
                   
                    article.ReliabilityID = Convert.ToInt32(rdr["EmployeeId"]);
                    article.SourceName = rdr["Name"].ToString();
                    article.SourceURL = rdr["URL"].ToString();
                    article.score = Convert.ToInt32(rdr["score"]);
                }
            }
            return View(articlesList);
        }
    }
}
