﻿using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db) {
            _db = db;        
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindNyId(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType ;
        }

        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity) ;
            return Save();
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false ;
        }
    }
}
