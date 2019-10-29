using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementBiz.VMModel
{
    public class PayrollVMModel//payroll viewmodel class
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public decimal NoOfLeaves { get; set; }
        public Nullable<decimal> GrossSalary { get; set; }
        public Nullable<decimal> TotalDeduction { get; set; }
        public Nullable<decimal> NetPay { get; set; }
        public string EmployeeName { get; set; }
    }
}
