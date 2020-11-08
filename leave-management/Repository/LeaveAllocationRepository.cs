using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocation = _db.LeaveAllocations.ToList();
            return leaveAllocation;
        }

        public LeaveAllocation FindNyId(int id)
        {
            var leaveAllocation = _db.LeaveAllocations.Find(id);
            return leaveAllocation;
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }
    }
}