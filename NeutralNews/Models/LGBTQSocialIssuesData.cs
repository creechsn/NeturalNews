using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace NeutralNews.Models
{
    public class LGBTQSocialIssuesData
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

        public List<LGBTQSocialIssuesData> GetLGBTQSocialIssuesDatas(string connectionString)
        {
            List<LGBTQSocialIssuesData> LGBTQSocialIssuesArticles = new List<LGBTQSocialIssuesData>();
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT * FROM Reliability_Data where SourceName LIKE '%Ally%' OR SourceName LIKE '%Androgynous%' OR SourceName LIKE '%androphilic%' OR SourceName LIKE '%aromantic%' OR SourceName LIKE '%Asexual%' OR SourceName LIKE '%Biphobia%' OR SourceName LIKE '%Bisexual%' OR SourceName LIKE '%Cisgender%' OR SourceName LIKE '%cisnormativity%' OR SourceName LIKE '%Closeted%' OR SourceName LIKE '%Coming Out%' OR SourceName LIKE '%demiromantic%' OR SourceName LIKE '%demisexual%' OR SourceName LIKE '%Drag King%' OR SourceName LIKE '%Drag Queen%' OR SourceName LIKE '%femme%' OR SourceName LIKE '%Gay%' OR SourceName LIKE '%Gender Dysphoria%' OR SourceName LIKE '%Gender Expression%' OR SourceName LIKE '%Gender fluid%' OR SourceName LIKE '%Gender identity%' OR SourceName LIKE '%Gender Neutral%' OR SourceName LIKE '%Gender non-conforming%' OR SourceName LIKE '%Gender Reassignment Surgery%' OR SourceName LIKE '%Gender Role%' OR SourceName LIKE '%Gender transition%' OR SourceName LIKE '%Gender-expansive%' OR SourceName LIKE '%Genderqueer%' OR SourceName LIKE '%Heterosexual%' OR SourceName LIKE '%Homophobia%' OR SourceName LIKE '%Homosexual%' OR SourceName LIKE '%In the Life%' OR SourceName LIKE '%Intesex%' OR SourceName LIKE '%Kinsey Scale%' OR SourceName LIKE '%Lesbian%' OR SourceName LIKE '%LGBTQ%' OR SourceName LIKE '%LGBTQQIA%' OR SourceName LIKE '%metrosexual%' OR SourceName LIKE '%nonbinary%' OR SourceName LIKE '%Non-binary%' OR SourceName LIKE '%Omnisexual%' OR SourceName LIKE '%Outing%' OR SourceName LIKE '%Pansexual%' OR SourceName LIKE '%polyamory%' OR SourceName LIKE '%Queer%' OR SourceName LIKE '%Questioning%' OR SourceName LIKE '%Same-gender loving%' OR SourceName LIKE '%Sex assigned at birth%' OR SourceName LIKE '%Sexual Orientation%' OR SourceName LIKE '%Sexual Preference%' OR SourceName LIKE '%Sexual Reassignment Surgery%' OR SourceName LIKE '%sexuality%' OR SourceName LIKE '%skoliosexual%' OR SourceName LIKE '%Straight%' OR SourceName LIKE '%third genger%' OR SourceName LIKE '%trans%' OR SourceName LIKE '%Transgender%' OR SourceName LIKE '%transitioning%' OR SourceName LIKE '%transman%' OR SourceName LIKE '%Transphobia%' OR SourceName LIKE '%transwoman%' ";
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    var SocialArticle = new LGBTQSocialIssuesData();

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
                    LGBTQSocialIssuesArticles.Add(SocialArticle);
                }
            }
            return LGBTQSocialIssuesArticles;
        }

    }
}
