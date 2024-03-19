namespace Task2
{
    public class ContainerShip
    {
        public ContainerShip(int maxSpeed, int maxContainerNumber, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainerNumber = maxContainerNumber;
            MaxWeight = maxWeight;
        }

        public List<Container> Containers { get; set; } = new List<Container>();
        public int MaxSpeed { get; }
        public int MaxContainerNumber { get; }
        public double MaxWeight { get; }

        public void AddContainer(Container container)
        {
            // Implementation
        }

        // Other methods - for loading cargo, removing container, etc.
    }


}
