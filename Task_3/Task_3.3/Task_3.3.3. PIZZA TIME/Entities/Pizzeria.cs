using Task_3._3._3._PIZZA_TIME.EventClasses;

namespace Task_3._3._3._PIZZA_TIME.Entities
{
    static public class Pizzeria
    {
        static public event EventHandler<OrderArgs>? EndCooked;

        static public void ConfirmOrder(int id,PizzaType pizzaType)
        {
            Cooking(id, pizzaType);
        }

        static private void Cooking(int id, PizzaType pizzaType)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            GiveOrder(id, pizzaType);
        }

        static private void GiveOrder(int id, PizzaType pizzaType)
        {
            EndCooked?.Invoke(null, new OrderArgs(id, pizzaType));
        }
    }
}
