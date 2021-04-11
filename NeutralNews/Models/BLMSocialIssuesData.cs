using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace NeutralNews.Models
{
    public class BLMSocialIssuesData
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

       
        public List<BLMSocialIssuesData> GetBLMSocialIssuesDatas(string connectionString)
        {
            List<BLMSocialIssuesData> BLMSocialIssuesArticles = new List<BLMSocialIssuesData>();
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT * FROM Reliability_Data where SourceName LIKE '%Accountability%'OR SourceName LIKE '%Ally%'OR SourceName LIKE '%Anti-Black%'OR SourceName LIKE '%Anti-Racism%'OR SourceName LIKE '%Anti-Racist%'OR SourceName LIKE '%Anti-Racist Ideas%'OR SourceName LIKE '%Assimilationist%'OR SourceName LIKE '%Bigotry%'OR SourceName LIKE '%Black Lives Matter%'OR SourceName LIKE '%Caucusing (Affinity Groups)%'OR SourceName LIKE '%Collusion%'OR SourceName LIKE '%Colonization%'OR SourceName LIKE '%Critical Race Theory%'OR SourceName LIKE '%Cultural Appropriation%'OR SourceName LIKE '%Cultural Misappropriation%'OR SourceName LIKE '%Cultural Racism%'OR SourceName LIKE '%Culture%'OR SourceName LIKE '%Decolonization%'OR SourceName LIKE '%Diaspora%'OR SourceName LIKE '%Discrimination%'OR SourceName LIKE '%Diversity%'OR SourceName LIKE '%Ethnicity%'OR SourceName LIKE '%Implicit Bias%'OR SourceName LIKE '%Inclusion%'OR SourceName LIKE '%Indigeneity%'OR SourceName LIKE '%Individual Racism%'OR SourceName LIKE '%Institutional Racism%'OR SourceName LIKE '%Internalized Racism%'OR SourceName LIKE '%Interpersonal Racism%'OR SourceName LIKE '%Intersectionality%'OR SourceName LIKE '%Microaggression%'OR SourceName LIKE '%Model Minority%'OR SourceName LIKE '%Movement Building%'OR SourceName LIKE '%Multicultural Competency%'OR SourceName LIKE '%Oppression%'OR SourceName LIKE '%People of Color%'OR SourceName LIKE '%Power%'OR SourceName LIKE '%Prejudice%'OR SourceName LIKE '%Privilege%'OR SourceName LIKE '%Race%'OR SourceName LIKE '%Racial and Ethnic Identity%'OR SourceName LIKE '%Racial Equity%'OR SourceName LIKE '%Racial Healing%'OR SourceName LIKE '%Racial Identity Development Theory%'OR SourceName LIKE '%Racial Inequity%'OR SourceName LIKE '%Racial Justice%'OR SourceName LIKE '%Racial Reconciliation%'OR SourceName LIKE '%Racialization%'OR SourceName LIKE '%Racism%'OR SourceName LIKE '%Racist%'OR SourceName LIKE '%Racist Ideas%'OR SourceName LIKE '%Racist Policies%'OR SourceName LIKE '%Reparations%'OR SourceName LIKE '%Restorative Justice%'OR SourceName LIKE '%Settler Colonialism%'OR SourceName LIKE '%Structural Racialization%'OR SourceName LIKE '%Structural Racism%'OR SourceName LIKE '%Targeted Universalism%'OR SourceName LIKE '%White Fragility%'OR SourceName LIKE '%White Privilege%'OR SourceName LIKE '%White Supremacy%'OR SourceName LIKE '%White Supremacy Culture%'OR SourceName LIKE '%Whiteness%' ";
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    var SocialArticle = new BLMSocialIssuesData();

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
                    BLMSocialIssuesArticles.Add(SocialArticle);
                }
            }
            return BLMSocialIssuesArticles;
        }
    }
}
