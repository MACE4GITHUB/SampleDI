namespace SimpleDITests
{
    public interface IEngine
    {
        bool IsWorked { get; }
        void Start();
        void Stop();
    }
}
