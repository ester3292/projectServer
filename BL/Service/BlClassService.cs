﻿using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;

namespace BL.Service
{
    public class BlClassService : IBlClass
    {
        IDal dal;
        public BlClassService(IDal dal)
        {
            this.dal = dal;
        }

        public void Create(BlClass myClass)
        {
            Class c = new Class()
            {
                Name = myClass.Name
            };
            dal.Class.Create(c);
        }
        public string GetClassNameById(int id)
        {
            var p = dal.Class.GetClassNameById(id);
            if (p != null)
            {
                return p.Name;
            }
            return "";
        }
    }
}
