namespace Meeting4.AdvancedProgrammingPart2
{
    internal class Customer
    {
        public Customer(string name, string address, params Purchase[] purchases)
        {
            Name = name;
            Address = address;
            Purchases = purchases;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private string Name { get; }

        public Purchase[] Purchases { get; }

        public string Address { get; }

        public class Purchase
        {
            public Purchase(string description, int price)
            {
                Description = description;
                Price = price;
            }

            public string Description { get; }

            public int Price { get; }
        }
    }
}