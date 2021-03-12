using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeutralNews.Models
{
    public class ArticleData
    {
        public int ReliabilityID { get; set; }

        public string SourceName { get; set; }

        public string SourceURL { get; set; }

        public int score { get; set; }

        public byte isArticle { get; set; }

        public byte isAudio { get; set; }

        public byte isVideo { get; set; }
    }
}
