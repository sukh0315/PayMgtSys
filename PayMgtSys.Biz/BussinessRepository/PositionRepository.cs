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
    public class PositionRepository:IPositionInterface
    {
        PayrollManagementEntities _db = new PayrollManagementEntities();
        public List<PositionVMModel> GetPositionListFunc()
        {
            var list = new List<PositionVMModel>();
            try
            {
                list = (from a in _db.Positions
                        select new PositionVMModel
                        {
                            ID = a.ID,
                            PositionName = a.PositionName,
                            DailyRate = a.DailyRate,
                            MonthlyRate = a.MonthlyRate,
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<PositionVMModel> GetPositionByIDFunc(int id)
        {
            var record = new List<PositionVMModel>();
            try
            {
                record = (from a in _db.Positions
                          where a.ID == id
                          select new PositionVMModel
                          {
                              ID = a.ID,
                              PositionName = a.PositionName,
                              DailyRate = a.DailyRate,
                              MonthlyRate = a.MonthlyRate,
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }
        public PositionVMModel AddAndUpdatePositionFunc(PositionVMModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    var rec = _db.Positions.OrderByDescending(x => x.ID).Where(x => x.ID == model.ID).FirstOrDefault();
                    rec.PositionName = model.PositionName;
                    rec.DailyRate = model.DailyRate;
                    rec.MonthlyRate = model.MonthlyRate;
                    _db.SaveChanges();

                }
                else
                {
                    Position _Position = new Position();
                    _Position.PositionName = model.PositionName;
                    _Position.DailyRate = model.DailyRate;
                    _Position.MonthlyRate = model.MonthlyRate;
                    _db.Positions.Add(_Position);
                    _db.SaveChanges();
                    model.ID = _Position.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }
        public bool DeletePositionFunc(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = _db.Positions.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.Positions.Remove(record);
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
