using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeutralNews.Models;
using Microsoft.AspNetCore.Http;
using System.Web.Http;
using System.Net.Http;
using Microsoft.IdentityModel.Protocols;
using System.Data;


namespace NeutralNews.Controllers
{
    public class SocialIssuesController : Controller
    {
        public IActionResult SocialIssues(string sortOrder)
        {
            // Create my data's order based on category chosen
            ViewData["BLM"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["LGBTQ"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["WomensRights"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ClimateChange"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["Healthcare"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["RefugeeCrisis"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["Trafficking"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            List<SocialIssuesData> SocialIssuesArticles = new List<SocialIssuesData>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                // grab data from database using the connection string in the web config file.
                SqlCommand cmd = new SqlCommand("SELECT * FROM Reference_Data", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    // these are the values we want to grab (bytes are large, can do this later/may be out of scope for this project's timeline)
                    var SocialArticle = new SocialIssuesData();

                    SocialArticle.ReferenceID = Convert.ToInt32(rdr["ReferenceID"]);
                    SocialArticle.ReferenceName = rdr["Name"].ToString();
                    SocialArticle.ReferenceURL = rdr["URL"].ToString();
                    SocialIssuesArticles.Add(SocialArticle);

                }
            }
            // use this to view values (can style this in a table on the Index page)
            return PartialView(SocialIssuesArticles);
        }
    }
}