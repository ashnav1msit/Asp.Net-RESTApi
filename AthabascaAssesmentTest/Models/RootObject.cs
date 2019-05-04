using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthabascaAssesmentTest.Models
{
    public class Clue
    {
        public int id { get; set; }
        public string answer { get; set; }
        public string question { get; set; }
        public int? value { get; set; }
        public DateTime airdate { get; set; }
        public int category_id { get; set; }
        public object game_id { get; set; }
        public int? invalid_count { get; set; }
    }

    public class RootObject
    {
        public int id { get; set; }
        public string title { get; set; }
        public int clues_count { get; set; }
        public List<Clue> clues { get; set; }
    }


}
