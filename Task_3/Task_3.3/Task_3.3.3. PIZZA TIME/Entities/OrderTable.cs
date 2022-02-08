using Task_3._3._3._PIZZA_TIME.EventClasses;

namespace Task_3._3._3._PIZZA_TIME.Entities
{
    public static class OrderTable
    {
        static private int _id = 0;
        static public event Action<int,PizzaType>? OnNewOrder;
        static public event Action? TakeOrder = () => { };

        public static void MakeOrder(string name, PizzaType typePizza)
        {
            Pizzeria.EndCooked += ReadyOrder;
            Console.WriteLine($"Order №{_id} by {name} is accepted ");
            OnNewOrder?.Invoke(_id, typePizza);
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
