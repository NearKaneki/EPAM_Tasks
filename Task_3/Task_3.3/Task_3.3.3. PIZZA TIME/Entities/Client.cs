namespace Task_3._3._3._PIZZA_TIME.Entities
{
    public class Client
    {

        public string Name { get; init; }

        public Client(string name)
        {
            Name = name;
        }

        public void MakeOrder(PizzaType pizzaType)
        {
            OrderTable.NewOrder();
        }

        public void PickUpOrder()
        {

        }
    }
}
