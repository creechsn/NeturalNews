using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;


namespace NeutralNews.Pages
{
    public class UploadModel : PageModel
    {
        readonly IConfiguration _configuration;

        public string connectionString;

        public UploadModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            
        }

        [BindProperty]
        public string inputURL { get; set; }
        public string Message => (string)TempData[nameof(Message)];

        public ActionResult OnPost([FromForm]string Message)
        {
            List<UploadModel> referenceParameterList = new List<UploadModel>();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            //trims down the url so it can be compared to our DB
            Uri urlTrim = new Uri(inputURL);
            string host = urlTrim.Host;
            bool flag = false;
            string score;
            string readURL = "";

            //SQL commands for finding the users inputted URL in the DB
            SqlCommand cmd = new SqlCommand("select * from [Reference_Data]", con);
            SqlCommand cmd2 = new SqlCommand("select ReferenceURL from Reference_Data where ([ReferenceURL] like @HOSTURL)", con);
            cmd2.Parameters.AddWithValue("@HOSTURL", "%" + host + "%");

            cmd.CommandText = "select * from [Reference_Data]";
            cmd.Connection = con;
            
            if (cmd2.ExecuteScalar() as string != null)
            {
                readURL = cmd2.ExecuteScalar().ToString();
            }

            //reads through the db and looks for a match to the user's input
            SqlDataReader read = cmd.ExecuteReader(); 
            while (read.Read())
            {
                if (read[2].ToString() == readURL)
                {
                    flag = true;
                    break;
                }
            }

            if (flag == true)
            {
                //grabs the score from the previous if and compares to the scores used to identify political leaning
                score = read[3].ToString();

                if (score == "-2")
                {
                    TempData["Message"] = "We gathered the information about your URL and this site typically leans right politically";
                }
                else if (score == "-1")
                {
                    TempData["Message"] = "We gathered the information about your URL and this site typically leans slightly right politically";
                }
                else if (score == "0")
                {
                    TempData["Message"] = "We gathered the information about your URL and this site is typically neutral politically";   
                }
                else if (score == "1")
                {
                    TempData["Message"] = "We gathered the information about your URL and this site typically leans slightly left politically";
                }
                else if (score == "2")
                {
                    TempData["Message"] = "We gathered the information about your URL and this site typically leans left politically";
                }
            }
            if (flag == false)
            {
                TempData["Message"] = "Uh oh! Looks like we do not know the political leaning for the website you entered. It is under our team's advisement. Check back later!";

                //Appends the url to a log file, so that our team can manually add it
                using (StreamWriter writerURL = new StreamWriter("log.txt", true))
                {
                    writerURL.WriteLine(host);
                }
            }
            con.Close();
            return RedirectToPage("Upload");
        }
     }
}
