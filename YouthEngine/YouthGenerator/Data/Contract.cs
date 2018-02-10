using System;

namespace YouthGenerator.Data
{
    public class Contract
    {
        public int IdContract { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public double Wage { get; set; }
    }
}
