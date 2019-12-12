namespace SimpleDITests
{
    public class Car
    {       
        public Car(IEngine engine)
        {
            Engine = engine;
        }
        public IEngine Engine { get; }         
    }
}
