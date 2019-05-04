using AthabascaAssesmentTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthabascaAssesmentTest.Services
{
    public class ClueRepo
    {

        public ClueData[] GetAllClues()
        {
            return new ClueData[]
            {
            new ClueData

            {
                //Id = 1,
               // Name = "Glenn Block"
            },
            new ClueData
            {
              //  Id = 2,
               // Name = "Dan Roth"
            }
            };
        }
    }
}