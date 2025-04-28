using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace BL.Service
{
    public class BlMarkService:IBlMark
    {/// <summary>
     /// הזרקת תלויות
     /// </summary>
        readonly IDal dal;
        public BlMarkService(IDal dal)
        {
            this.dal = dal;
        }
        /// <summary>
        /// הוספת ציון לתלמיד
        /// </summary>
        /// <param name="mark"></param>
       public BlMarks Create(BlMarks mark)
        {
            MarksForStudent p = new()
            {
               Id = mark.Id,
               StudentId = mark.StudentId,  
               Subject = mark.Subject,
               Mark = mark.Mark,
               Notes = mark.Notes,
               TeacherId = mark.TeacherId,
               HalfA=mark.HalfA
            };
            dal.Marks.Create(p);
            return mark;
        }
        /// <summary>
        ///   עדכון ציון
        /// </summary>
        /// <param name="mark"></param>

        public int Update(BlMarks mark)
        {
            var m =dal.Marks.GetById(mark.Id);      
            m.Mark = mark.Mark;
            m.Subject = mark.Subject;
            m.Notes = mark.Notes;
            m.TeacherId = mark.TeacherId;
            m.StudentId = mark.StudentId;
            m.HalfA = mark.HalfA;
            return dal.Marks.Update(m);
        }
        public void Delete(BlMarks mark)
        {
            var m = dal.Marks.GetById(mark.Id);
            dal.Marks.Delete(m);
        }
        public BlMarks? GetById(int id)
        {
            var p = dal.Marks.GetById(id);
            if (p != null)
            {
                BlMarks t2 = new()
                { Id = p.Id, StudentId  = p.StudentId, Subject  = p.Subject, Mark  = p.Mark, Notes = p.Notes ?? "", TeacherId  = p.TeacherId ?? 0, HalfA = p.HalfA ?? 0 };
                return t2;
            }
            return null;
        }


    }
}
