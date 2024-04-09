namespace Task4.models
{
    public class Animal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Category { get; set; }
        public double Weight { get; set; }
        public string FurColor { get; set; }


    }
}
