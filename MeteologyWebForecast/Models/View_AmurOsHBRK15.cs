using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeteologyWebForecast.Models
{
    public class View_AmurOsHBRK15
    {
        public string Title;
        public string Comment;
        public class Bassein
        {
            public string Name;
            public decimal five01;
            public decimal five02;
            public decimal five03;
            public decimal five04;
            public decimal five05;
            public decimal five06;

            public string ShowFive(decimal five)
            {
                if (five == decimal.MaxValue)
                {
                    return "-";
                }
                else
                {
                    return five.ToString();
                }
            }

            public Bassein()
            {
                Name = "";
                five01 = 0;
                five02 = 0;
                five03 = 0;
                five04 = 0;
                five05 = 0;
                five06 = 0;
            }

        }

        public List<Bassein> Basseins;

        public View_AmurOsHBRK15()
        {
            Basseins = new List<Bassein>();
            Title = "";
            Comment = "";
        }
    }
}