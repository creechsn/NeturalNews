using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace NeutralNews.Models
{
    public class HumanSocialIssuesData
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

       
        public List<HumanSocialIssuesData> GetHumanSocialIssuesDatas(string connectionString)
        {
            List<HumanSocialIssuesData> HumanSocialIssuesArticles = new List<HumanSocialIssuesData>();
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT * FROM Reliability_Data where SourceName LIKE '%3P Paradigm%' OR SourceName LIKE '%4p Paradigm%' OR SourceName LIKE '%child laundering%' OR SourceName LIKE '%child prostitution%' OR SourceName LIKE '%child soldiering%' OR SourceName LIKE '%coercion%' OR SourceName LIKE '%commercial sex act%' OR SourceName LIKE '%commercial sexual exploitation%' OR SourceName LIKE '%Debt Bondage%' OR SourceName LIKE '%Domestic Minor Sex Trafficking%' OR SourceName LIKE '%domestic violence%' OR SourceName LIKE '%force%' OR SourceName LIKE '%forced labor%' OR SourceName LIKE '%forced marriage%' OR SourceName LIKE '%Forcible Pandering%' OR SourceName LIKE '%fraud%' OR SourceName LIKE '%human smuggling%' OR SourceName LIKE '%human trafficking %' OR SourceName LIKE '%involuntary servitude%' OR SourceName LIKE '%labor traffikcing%' OR SourceName LIKE '%Peonage Bondage%' OR SourceName LIKE '%people smuggling%' OR SourceName LIKE '%Pimp%' OR SourceName LIKE '%prostitution%' OR SourceName LIKE '%Severe Forms of Trafficking in Persons%' OR SourceName LIKE '%sex trafficking%' OR SourceName LIKE '%sex work%' OR SourceName LIKE '%sex worker%' OR SourceName LIKE '%sex worker rights %' OR SourceName LIKE '%sexual slave %' OR SourceName LIKE '%sexual slavery%' OR SourceName LIKE '%stockholm syndrome %' OR SourceName LIKE '%Victim Services%' OR SourceName LIKE '%victims of trafficking%' ";
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    var SocialArticle = new HumanSocialIssuesData();

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
                    HumanSocialIssuesArticles.Add(SocialArticle);
                }
            }
            return HumanSocialIssuesArticles;
        }
    }
}
