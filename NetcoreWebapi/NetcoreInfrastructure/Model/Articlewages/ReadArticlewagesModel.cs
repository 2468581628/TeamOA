using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Model.Articlewages
{
    public class ReadArticlewagesModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string YearMonth { get; set; }

        public Double AllMoney { get; set; }

        public Double Insurance { get; set; }

        public Double AccumulationFund { get; set; }

        public Double PracticalMoney { get; set; }
    }
}
