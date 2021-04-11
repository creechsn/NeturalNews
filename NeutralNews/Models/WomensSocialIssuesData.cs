using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace NeutralNews.Models
{
    public class WomensSocialIssuesData
    {
        public int ReliabilityID { set; get; }
        [DisplayName("SourceName")]
        public string SourceName { set; get; }
        [DisplayName("SourceURL")]
        public string SourceURL { set; get; }
        [DisplayName("score")]
        public string score { set; get; }
        [DisplayName("LeaningBias")]
        public string BiasLeaning { set; get; }

        public List<WomensSocialIssuesData> GetWomensSocialIssuesDatas(string connectionString)
        {
            List<WomensSocialIssuesData> WomensSocialIssuesArticles = new List<WomensSocialIssuesData>();
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT * FROM Reliability_Data where SourceName LIKE '%abortion%' OR SourceName LIKE '%affirmative action measures%' OR SourceName LIKE '%assisting spouses%' OR SourceName LIKE '%asylum-seeking women and girls%' OR SourceName LIKE '%Benevolent Sexism%' OR SourceName LIKE '%Cisgender%' OR SourceName LIKE '%commodity feminism %' OR SourceName LIKE '%date rape%' OR SourceName LIKE '%equity feminism%' OR SourceName LIKE '%female%' OR SourceName LIKE '%femicide%' OR SourceName LIKE '%femininities%' OR SourceName LIKE '%forced abortion%' OR SourceName LIKE '%forced marriage%' OR SourceName LIKE '%forced pregnancy%' OR SourceName LIKE '%forced prostitution%' OR SourceName LIKE '%forced sterilization%' OR SourceName LIKE '%gender bias%' OR SourceName LIKE '%gender equality%' OR SourceName LIKE '%gender evaluation%' OR SourceName LIKE '%gender gap%' OR SourceName LIKE '%gender identity%' OR SourceName LIKE '%gender inequality%' OR SourceName LIKE '%gender roles%' OR SourceName LIKE '%gender stereotypes%' OR SourceName LIKE '%gender violence%' OR SourceName LIKE '%glass ceiling%' OR SourceName LIKE '%Hostile Sexism%' OR SourceName LIKE '%Internalized Sexism%' OR SourceName LIKE '%intersectional feminism%' OR SourceName LIKE '%LGBTQ%' OR SourceName LIKE '%Male gaze%' OR SourceName LIKE '%marital rape%' OR SourceName LIKE '%marital status%' OR SourceName LIKE '%maternity leave%' OR SourceName LIKE '%Misandry%' OR SourceName LIKE '%Misogynoir%' OR SourceName LIKE '%Misogyny%' OR SourceName LIKE '%No means no%' OR SourceName LIKE '%no means no%' OR SourceName LIKE '%Patriarchy%' OR SourceName LIKE '%pay gap%' OR SourceName LIKE '%rape%' OR SourceName LIKE '%rape culture%' OR SourceName LIKE '%reproductive health%' OR SourceName LIKE '%reproductive rights%' OR SourceName LIKE '%sex positive%' OR SourceName LIKE '%sex worker exclusionary radical feminists%' OR SourceName LIKE '%Sexism%' OR SourceName LIKE '%sexual violence %' OR SourceName LIKE '%SWERF%' OR SourceName LIKE '%TERF%' OR SourceName LIKE '%Title IX%' OR SourceName LIKE '%Trans exlusionary radical feminists%' OR SourceName LIKE '%transfeminism%' OR SourceName LIKE '%Transgender%' OR SourceName LIKE '%Transmisogyny%' OR SourceName LIKE '%Transphobia%' OR SourceName LIKE '%triple burden%' OR SourceName LIKE '%womanism%' OR SourceName LIKE '%Women of color%' OR SourceName LIKE '%Yes means yes%' ";
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    var SocialArticle = new WomensSocialIssuesData();

                    SocialArticle.ReliabilityID = Convert.ToInt32(dr["ReliabilityID"]);
                    SocialArticle.SourceName = dr["SourceName"].ToString();
                    SocialArticle.SourceURL = dr["SourceURL"].ToString();
                    SocialArticle.score = dr["score"].ToString();

                    if (SocialArticle.score == "0")
                    {
                        SocialArticle.BiasLeaning = "Neutral";
                    }
                    else if (SocialArticle.score == "1")
                    {
                        SocialArticle.BiasLeaning = "slightLeft";
                    }
                    else if (SocialArticle.score == "2")
                    {
                        SocialArticle.BiasLeaning = "FarLeft";
                    }
                    else if (SocialArticle.score == "-1")
                    {
                        SocialArticle.BiasLeaning = "slightRight";
                    }
                    else if (SocialArticle.score == "-2")
                    {
                        SocialArticle.BiasLeaning = "FarRight";
                    }
                    WomensSocialIssuesArticles.Add(SocialArticle);
                }
            }
            return WomensSocialIssuesArticles;
        }

    }
}
