namespace BL.Api
{
    public interface IBL
    {
        public IBlStudent Students { get; }
        public IBlTeacher Teachers { get; }
        public IBlMark Marks { get; }
        public IBlClass Classes { get; }
    }
}
