using Task_3._3._3._PIZZA_TIME.EventClasses;

namespace Task_3._3._3._PIZZA_TIME.Entities
{
    public static class OrderTable
    {
        static private int _id = 0;
        static public event EventHandler<OrderArgs>? NewOrder;
        static public event Action? TakeOrder = () => { };

        public static void MakeOrder(Client client, PizzaType TypePizza)
        {
            Pizzeria.EndCooked += ReadyOrder;
            Console.WriteLine($"Order №{_id} by {client.Name} is accepted ");
            NewOrder?.Invoke(null, new OrderArgs(_id, TypePizza));
            ++_id;
        }

        public static void ReadyOrder(object sender, OrderArgs orderArgs)
        {
            Pizzeria.EndCooked -= ReadyOrder;
            Console.WriteLine($"Order №{orderArgs.ID} is ready");
            TakeOrder?.Invoke();
        }
    }
}
