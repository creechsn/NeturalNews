using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NeutralNews.Models
{
    public class ArticleData
    {
        public int ReferenceID { set; get; }
        [DisplayName("ReferenceName")]
        public string ReferenceName { set; get; }
        [DisplayName("ReferenceURL")]
        public string ReferenceURL { set; get; }
        [DisplayName("ReferenceScore")]
        public string ReferenceScore { set; get; }
        [DisplayName("LeaningBias")]
        public string BiasLeaning { set; get; }

        public List<ArticleData> GetArticleData(string connectionString)
        {
            List<ArticleData> ArticlesData = new List<ArticleData>();

            SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT * FROM Reference_Data ORDER BY RAND()";

            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    var Articles = new ArticleData();

                    Articles.ReferenceID = Convert.ToInt32(dr["ReferenceID"]);
                    Articles.ReferenceName = dr["ReferenceName"].ToString();
                    Articles.ReferenceURL = dr["ReferenceURL"].ToString();
                    Articles.ReferenceScore = dr["ReferenceScore"].ToString();

                    if (Articles.ReferenceScore == "0")
                    {
                        Articles.BiasLeaning = "Neutral";
                    }
                    else if (Articles.ReferenceScore == "1")
                    {
                        Articles.BiasLeaning = "slightLeft";
                    }
                    else if (Articles.ReferenceScore == "2")
                    {
                        Articles.BiasLeaning = "FarLeft";
                    }
                    else if (Articles.ReferenceScore == "-1")
                    {
                        Articles.BiasLeaning = "slightRight";
                    }
                    else if (Articles.ReferenceScore == "-2")
                    {
                        Articles.BiasLeaning = "FarRight";
                    }
                    ArticlesData.Add(Articles);
                }
            }
            return ArticlesData;

        }
    }
}
