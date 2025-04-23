namespace Dal.Api
{
    public interface IDal
    {
        public IDalStudent Students { get; }
        public IDalTeacher Teachers { get; }
        public IDalMarks Marks { get; }
        public IDallClass Class { get; }
    }
}
