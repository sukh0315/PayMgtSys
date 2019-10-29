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
    public class EmployeeRepository:IEmployeeInterface
    {
        PayrollManagementEntities _db = new PayrollManagementEntities();
        public List<EmployeeVMModel> GetEmployeeDataFunc()
        {
            var list = new List<EmployeeVMModel>();
            try
            {
                list = (from a in _db.Employees
                        join b in _db.Positions on a.PositionID equals b.ID
                        select new EmployeeVMModel
                        {
                            ID = a.ID,
                            PositionID = a.PositionID,
                            Name = a.Name,
                            FatherName = a.FatherName,
                            Address = a.Address,
                            PhoneNo = a.PhoneNo,
                            Email = a.Email,
                            DOB = a.DOB,
                            Gender = a.Gender,
                            PositionName = b.PositionName
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<EmployeeVMModel> GetEmployeeDataByIDFunc(int id)
        {
            var record = new List<EmployeeVMModel>();
            try
            {
                record = (from a in _db.Employees
                          where a.ID == id
                          select new EmployeeVMModel
                          {
                              ID = a.ID,
                              PositionID = a.PositionID,
                              Name = a.Name,
                              FatherName = a.FatherName,
                              Address = a.Address,
                              PhoneNo = a.PhoneNo,
                              Email = a.Email,
                              DOB = a.DOB,
                              Gender = a.Gender
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }
        public EmployeeVMModel AddAndUpdateEmployeeDataFunc(EmployeeVMModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    var rec = _db.Employees.OrderByDescending(x => x.ID).Where(x => x.ID == model.ID).FirstOrDefault();
                    rec.PositionID = model.PositionID;
                    rec.Name = model.Name;
                    rec.FatherName = model.FatherName;
                    rec.Address = model.Address;
                    rec.PhoneNo = model.PhoneNo;
                    rec.Email = model.Email;
                    rec.DOB = model.DOB;
                    rec.Gender = model.Gender;
                    _db.SaveChanges();

                }
                else
                {
                    Employee _Employee = new Employee();
                    _Employee.PositionID = model.PositionID;
                    _Employee.Name = model.Name;
                    _Employee.FatherName = model.FatherName;
                    _Employee.Address = model.Address;
                    _Employee.PhoneNo = model.PhoneNo;
                    _Employee.Email = model.Email;
                    _Employee.DOB = model.DOB;
                    _Employee.Gender = model.Gender;
                    _db.Employees.Add(_Employee);
                    _db.SaveChanges();
                    model.ID = _Employee.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }
        public bool DeleteEmployeeDataFunc(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = _db.Employees.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.Employees.Remove(record);
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
