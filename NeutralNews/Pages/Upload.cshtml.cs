using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace NeutralNews.Pages
{
    public class UploadModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Insert a valid link to an article/website you would like to know the political leaning of.";
        }

        [BindProperty]
        public string inputURL { get; set; }

        public void OnPost()
        {
            //string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString
            //SqlConnection myConnection = new SqlConnection(conString);
            string myConnection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(myConnection))
            {


                con.Open();


                //trims down the url so it can be compared to our db
                Uri urlTrim = new Uri(inputURL);
                string host = urlTrim.Host;
                bool flag = false;


                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [Reference_Data]";
                cmd.Connection = con;

                //reads through the db and looks for a match to the user's input
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (read[1].ToString() == host)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == true)
                {
                    SqlCommand cmd2 = new SqlCommand("select ReferenceScore from Reference_Data where ([ReferenceURL] = @hostURL)", con);
                    cmd2.Parameters.AddWithValue("@hostURL", host);

                    //to-do show the user the political leaning
                }
                else
                {
                    //Appends the url to a log file, so that our team can manually add it
                    //todo appears to write over the first slot in the log file
                    using (StreamWriter writerURL = new StreamWriter("log.txt"))
                    {
                        writerURL.WriteLine(host);
                    }
                    Message = "Uh oh! Looks like we do not know the political leaning for the website you entered.";
                }
                con.Close();
            }
        }
    }
}