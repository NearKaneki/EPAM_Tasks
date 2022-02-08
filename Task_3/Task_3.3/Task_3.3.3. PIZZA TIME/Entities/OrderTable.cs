using Task_3._3._3._PIZZA_TIME.EventClasses;

namespace Task_3._3._3._PIZZA_TIME.Entities
{   
    public static class OrderTable
    {
        static public event EventHandler<OrderArgs>? NewOrder;

        public static void MakeOrder(Client client, PizzaType TypePizza)
        {
            NewOrder?.Invoke(client, new OrderArgs(client.Name, TypePizza));
        }

        public static void ReadyOrder()
        {
            Console.WriteLine("Ready order");
        }
    }
}
