using Task_3._3._3._PIZZA_TIME.EventClasses;

namespace Task_3._3._3._PIZZA_TIME.Entities
{
    static public class Pizzeria
    {
        static public event Action PizzaIsCooked = () => { };

        static public void ConfirmOrder(object sender,OrderArgs orderArgs )
        {
            Console.WriteLine("Pizzeria took an order");
            Cooking(orderArgs.TypePizza);
        }

        static public void Cooking(PizzaType pizzaType) 
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            GiveOrder(pizzaType);
        }
        
        static public void GiveOrder(PizzaType pizzaType)
        {
            Console.WriteLine($"Pizza {pizzaType} is cooked");
            PizzaIsCooked?.Invoke();
        }
    }
}
