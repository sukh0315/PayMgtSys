using PayMgtSys.DB;
using PayrollManagementBiz.Interface;
using PayrollManagementBiz.VMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementBiz.Repository
{
    public class PayrollRepository : IPayrollInterface
    {
        PayrollManagementEntities _db = new PayrollManagementEntities();
        public List<PayrollVMModel> GetPayrollListFunc()//get payroll list method
        {
            var list = new List<PayrollVMModel>();
            try
            {
                list = (from a in _db.Payrolls
                        join b in _db.Employees on a.EmployeeID equals b.ID
                        select new PayrollVMModel
                        {
                            ID = a.ID,
                            EmployeeID = a.EmployeeID,
                            NoOfLeaves = a.NoOfLeaves,
                            GrossSalary = a.GrossSalary,
                            TotalDeduction = a.TotalDeduction,
                            NetPay = a.NetPay,
                            EmployeeName =b.Name
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<PayrollVMModel> GetPayrollByIDFunc(int id)//getting payroll by id
        {
            var record = new List<PayrollVMModel>();
            try
            {
                record = (from a in _db.Payrolls
                          where a.ID == id
                          select new PayrollVMModel
                          {
                              ID = a.ID,
                              EmployeeID = a.EmployeeID,
                              NoOfLeaves = a.NoOfLeaves,
                              GrossSalary = a.GrossSalary,
                              TotalDeduction = a.TotalDeduction,
                              NetPay = a.NetPay,
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }
        public PayrollVMModel AddAndUpdatePayrollFunc(PayrollVMModel model)//add update function
        {
            try
            {
                if (model.ID > 0)
                {
                    var rec = _db.Payrolls.OrderByDescending(x => x.ID).Where(x => x.ID == model.ID).FirstOrDefault();
                    rec.EmployeeID = model.EmployeeID;
                    rec.NoOfLeaves = model.NoOfLeaves;
                    rec.GrossSalary = model.GrossSalary;
                    rec.TotalDeduction = model.TotalDeduction;
                    rec.NetPay = model.NetPay;
                    _db.SaveChanges();

                }
                else
                {
                    Payroll _Payroll = new Payroll();
                    _Payroll.EmployeeID = model.EmployeeID;
                    _Payroll.NoOfLeaves = model.NoOfLeaves;
                    _Payroll.GrossSalary = model.GrossSalary;
                    _Payroll.TotalDeduction = model.TotalDeduction;
                    _Payroll.NetPay = model.NetPay;
                    _db.Payrolls.Add(_Payroll);
                    _db.SaveChanges();
                    model.ID = _Payroll.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }
        public bool DeletePayrollFunc(int id)//Delete method
        {
            bool isDeleted = false;
            try
            {
                var record = _db.Payrolls.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.Payrolls.Remove(record);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }
    }
}
