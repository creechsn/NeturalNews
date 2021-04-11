using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace NeutralNews.Models
{
    public class ClimateSocialIssuesData
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

        public List<ClimateSocialIssuesData> GetClimateSocialIssuesDatas(string connectionString)
        {
            List<ClimateSocialIssuesData> ClimateSocialIssuesArticles = new List<ClimateSocialIssuesData>();
            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT * FROM Reliability_Data where SourceName LIKE '%acid rain%' OR SourceName LIKE '%air pollution%' OR SourceName LIKE '%anti-consumerist%' OR SourceName LIKE '%biocapacity%' OR SourceName LIKE '%biodegradable%' OR SourceName LIKE '%bioldegrade%' OR SourceName LIKE '%biological control%' OR SourceName LIKE '%biomaterial%' OR SourceName LIKE '%biome%' OR SourceName LIKE '%biopiracy%' OR SourceName LIKE '%bioregion%' OR SourceName LIKE '%biotic%' OR SourceName LIKE '%biotic index%' OR SourceName LIKE '%blue flag%' OR SourceName LIKE '%carbon capture%' OR SourceName LIKE '%carbon credits%' OR SourceName LIKE '%carbon debt%' OR SourceName LIKE '%carbon emissions%' OR SourceName LIKE '%carbon footprint%' OR SourceName LIKE '%carbon offset%' OR SourceName LIKE '%carbon sink%' OR SourceName LIKE '%carbon tax%' OR SourceName LIKE '%carbon trading%' OR SourceName LIKE '%carbon-neutral%' OR SourceName LIKE '%carbon-zero%' OR SourceName LIKE '%clean air%' OR SourceName LIKE '%cleantech%' OR SourceName LIKE '%climate%' OR SourceName LIKE '%climate breakdown %' OR SourceName LIKE '%climate change%' OR SourceName LIKE '%climate crisis%' OR SourceName LIKE '%climate denier%' OR SourceName LIKE '%climate emeregency%' OR SourceName LIKE '%climate friendly%' OR SourceName LIKE '%climate migrant%' OR SourceName LIKE '%climate refugee%' OR SourceName LIKE '%climate strike%' OR SourceName LIKE '%compostable%' OR SourceName LIKE '%conservancy%' OR SourceName LIKE '%conservation%' OR SourceName LIKE '%deforest%' OR SourceName LIKE '%deforestation%' OR SourceName LIKE '%depopulate%' OR SourceName LIKE '%disposable%' OR SourceName LIKE '%dumping%' OR SourceName LIKE '%eco-%' OR SourceName LIKE '%ecocide%' OR SourceName LIKE '%ecological%' OR SourceName LIKE '%ecology%' OR SourceName LIKE '%ecotourism%' OR SourceName LIKE '%energy efficient%' OR SourceName LIKE '%envioronmentalist %' OR SourceName LIKE '%environmental %' OR SourceName LIKE '%environmentalism%' OR SourceName LIKE '%fallout%' OR SourceName LIKE '%food insecurity%' OR SourceName LIKE '%food security%' OR SourceName LIKE '%freeganism%' OR SourceName LIKE '%fuel efficient%' OR SourceName LIKE '%geoengineering%' OR SourceName LIKE '%global warming%' OR SourceName LIKE '%globalization%' OR SourceName LIKE '%green wash%' OR SourceName LIKE '%greenhouse effect%' OR SourceName LIKE '%greenhouse gas%' OR SourceName LIKE '%litter%' OR SourceName LIKE '%low emission zone%' OR SourceName LIKE '%mass extinction%' OR SourceName LIKE '%natural resources%' OR SourceName LIKE '%non-renewable%' OR SourceName LIKE '%overpopulated%' OR SourceName LIKE '%ozone%' OR SourceName LIKE '%plastic footprint%' OR SourceName LIKE '%pollute%' OR SourceName LIKE '%pollution%' OR SourceName LIKE '%preservation%' OR SourceName LIKE '%preservationist %' OR SourceName LIKE '%recyclable%' OR SourceName LIKE '%recycle%' OR SourceName LIKE '%recycled%' OR SourceName LIKE '%reduce %' OR SourceName LIKE '%renewable%' OR SourceName LIKE '%single-use%' OR SourceName LIKE '%smog%' OR SourceName LIKE '%solar energy%' OR SourceName LIKE '%sustainability%' OR SourceName LIKE '%sustainable%' OR SourceName LIKE '%tipping point%' OR SourceName LIKE '%tree hugger%' OR SourceName LIKE '%unleaded%' OR SourceName LIKE '%unsustainable%' OR SourceName LIKE '%unsustainably%' OR SourceName LIKE '%upcycle%' OR SourceName LIKE '%upcycling%' OR SourceName LIKE '%water column%' OR SourceName LIKE '%zero waste%' ";
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    var SocialArticle = new ClimateSocialIssuesData();

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
                    ClimateSocialIssuesArticles.Add(SocialArticle);
                }
            }
            return ClimateSocialIssuesArticles;
        }

    }
}
