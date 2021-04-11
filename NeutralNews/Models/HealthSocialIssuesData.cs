using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace NeutralNews.Models
{
    public class HealthSocialIssuesData
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

        public List<HealthSocialIssuesData> GetHealthSocialIssuesDatas(string connectionString)
        {
            List<HealthSocialIssuesData> HealthSocialIssuesArticles = new List<HealthSocialIssuesData>();
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT * FROM Reliability_Data where SourceName LIKE '%affordable care act%'  OR SourceName LIKE '%covid%' OR SourceName LIKE '%age rating%' OR SourceName LIKE '%age band rating%' OR SourceName LIKE '%bending the cost curve%' OR SourceName LIKE '%cadillac health plans%' OR SourceName LIKE '%cadillac tax%' OR SourceName LIKE '%childrens health insurance program%' OR SourceName LIKE '%COBRA%' OR SourceName LIKE '%consolidated Omnibus Budget Reconciliation act%' OR SourceName LIKE '%cooperatives%' OR SourceName LIKE '%donut hole%' OR SourceName LIKE '%doughnut hole%' OR SourceName LIKE '%exchanges%' OR SourceName LIKE '%Family and Medical Leave Act%' OR SourceName LIKE '%Health insurance exchange%' OR SourceName LIKE '%health care cooperative%' OR SourceName LIKE '%Individual mandate penalty%' OR SourceName LIKE '%insurance mandates%' OR SourceName LIKE '%medicaid%' OR SourceName LIKE '%medicaid buy-in%' OR SourceName LIKE '%medicaid expansion%' OR SourceName LIKE '%medicare%' OR SourceName LIKE '%Medicare%' OR SourceName LIKE '%Medicare for All%' OR SourceName LIKE '%medicare part D%' OR SourceName LIKE '%opt in%' OR SourceName LIKE '%opt out%' OR SourceName LIKE '%pre existing condition%' OR SourceName LIKE '%preminum tax credit%' OR SourceName LIKE '%public option%' OR SourceName LIKE '%risk corridor%' OR SourceName LIKE '%self insured health plan%' OR SourceName LIKE '%self insured plan%' OR SourceName LIKE '%single payer%' OR SourceName LIKE '%single payer%' OR SourceName LIKE '%socialized healthcare%' OR SourceName LIKE '%socialized medicine%' OR SourceName LIKE '%trigger%' OR SourceName LIKE '%two tier%' OR SourceName LIKE '%two tier health system%' OR SourceName LIKE '%UCR%' OR SourceName LIKE '%underinsured%' OR SourceName LIKE '%universal coverage%'  ";
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    var SocialArticle = new HealthSocialIssuesData();

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
                    HealthSocialIssuesArticles.Add(SocialArticle);
                }
            }
            return HealthSocialIssuesArticles;
        }

    }
}
