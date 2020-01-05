using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Model.Cost
{
    public class CostModel
    {
        public string COSTTYPE { get; set; }

        public double COSTCOUNT { get; set; }

        public string FILENAME { get; set; }

        public string NEWFILENAME { get; set; }

        public DateTime DATETIME { get; set; }

        public string STATUS { get; set; }

        public int USER_ID { get; set; }

        public int ID { get; set; }
    }
}
