using PermessInternational.Areas.Global.Interface;
using PermessInternational.Areas.Global.Models;
using PermessInternational.PermessContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Global.Service
{
    public class SystemUserService : ISystemUser
    {
        private readonly PermessDbContext _context;
        public SystemUserService(PermessDbContext context)
        {
            _context = context;
        }
        public void AddUser(int userId, int concernId, SystemUser systemUser)
        {
            systemUser.ConcernID = concernId;
            systemUser.CreatorId = userId;
            systemUser.CreationDate = DateTime.Now;
            _context.SystemUsers.Add(systemUser);
        }

        public IEnumerable<SystemUser> Users(int concernId)
        {
            return _context.SystemUsers.Where(m => m.ConcernID == concernId && m.IsDelete == 0);
        }
    }
}