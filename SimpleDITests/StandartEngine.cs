namespace SimpleDITests
{
    public class StandartEngine : IEngine
    {
        public bool IsWorked { get; private set; }

        public void Start()
        {
            IsWorked = true;
        }

        public void Stop()
        {
            IsWorked = false;
        }
    }
}
