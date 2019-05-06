using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthabascaAssesmentTest.Models
{
    public class ClueData
    {
        public int id { get; set; }

        public string answer { get; set; }

        public string question { get; set; }

        public int value { get; set; }

        public DateTime airdate { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }


        public int  category_id { get; set; }

        public string game_id { get; set; }


        public string invalid_count { get; set; }

       



    }
}