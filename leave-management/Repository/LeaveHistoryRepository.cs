using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var leaveHistory = _db.LeaveHistories.ToList();
            return leaveHistory;
        }

        public LeaveHistory FindNyId(int id)
        {
            var leaveHistories = _db.LeaveHistories.Find(id);
            return leaveHistories ;
        }

        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

    }
}
