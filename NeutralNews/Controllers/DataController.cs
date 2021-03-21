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
using System.Net;
using System.Net.Mail;

namespace NeutralNews
{
    public class DataController : Controller
    {
        // -------------------------------------------------------------------------------------------------------------------
        // -------------- Grab Article Data to display on Index page. ---------
        // -------------------------------------------------------------------------------------------------------------------
        public ActionResult Index()
        {
            List<ArticleData> articlesList = new List<ArticleData>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                // grab data from database using the connection string in the web config file.
                SqlCommand cmd = new SqlCommand("SELECT * FROM Source_Data", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    // these are the values we want to grab (bytes are large, can do this later/may be out of scope for this project's timeline)
                    var article = new ArticleData();

                    article.ReliabilityID = Convert.ToInt32(rdr["ReliabilityID"]);
                    article.SourceName = rdr["Name"].ToString();
                    article.SourceURL = rdr["URL"].ToString();
                    article.score = Convert.ToInt32(rdr["score"]);
                }
            }
            // use this to view values (can style this in a table on the Index page)
            return View(articlesList);
        }
    }  

}
