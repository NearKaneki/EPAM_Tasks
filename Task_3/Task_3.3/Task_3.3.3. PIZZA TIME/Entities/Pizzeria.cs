using Task_3._3._3._PIZZA_TIME.EventClasses;

namespace Task_3._3._3._PIZZA_TIME.Entities
{
    static public class Pizzeria
    {
        static public event EventHandler<OrderArgs>? EndCooked;

        static public void ConfirmOrder(object sender, OrderArgs orderArgs)
        {
            Cooking(orderArgs.ID, orderArgs.TypePizza);
        }

        static public void Cooking(int ID, PizzaType pizzaType)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            GiveOrder(ID, pizzaType);
        }

        static public void GiveOrder(int ID, PizzaType pizzaType)
        {
            EndCooked?.Invoke(null, new OrderArgs(ID, pizzaType));
        }
    }
}
