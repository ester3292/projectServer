using Dal.Api;
using Dal.Models;
using Dal.Services;

namespace Dal
{
    public class DalManager : IDal
    {
        dbcontext data = new dbcontext();

        public DalManager()
        {
            Students = new DalStudentService(data);
            Teachers = new DalTeacherService(data);
            Marks = new DalMarkService(data);
            Class = new DalClassService(data);
        }

        public IDalStudent Students { get; }
        public IDalTeacher Teachers { get; }
        public IDalMarks Marks { get; }
        public IDallClass Class { get; }
    }
}
