using BL.Api;
using BL.Service;
using Dal;
using Dal.Api;

namespace BL
{
    public class BlManager :IBL
    {
        // תלמידות
        public IBlStudent Students { get; }
        //מורות
        public IBlTeacher Teachers { get; }
        //ציונים
        public IBlMark Marks { get; }
        //כיתות
        public IBlClass Classes { get; }

        public BlManager()
        {
            IDal dal = new DalManager(); // מנהל דל
            Students = new BlStudentService(dal);
            Teachers = new BlTeacherService(dal);
            Marks = new BlMarkService(dal);
            Classes = new BlClassService(dal);
        }
    }
}