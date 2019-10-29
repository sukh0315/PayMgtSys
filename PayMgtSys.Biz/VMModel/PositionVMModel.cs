using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementBiz.VMModel
{
    public class PositionVMModel//position viewmodel class
    {
        public int ID { get; set; }
        public string PositionName { get; set; }
        public decimal DailyRate { get; set; }
        public Nullable<decimal> MonthlyRate { get; set; }
    }
}
