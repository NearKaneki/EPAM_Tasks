using Task_3._3._3._PIZZA_TIME.Entities;

namespace Task_3._3._3._PIZZA_TIME.EventClasses
{
    public class OrderArgs:EventArgs
    {
        public string CustomerName { get; }
        public PizzaType TypePizza { get; }

        public OrderArgs(string customerName, PizzaType pizzaType)
        {
            CustomerName = customerName;
            this.TypePizza = pizzaType;
        }
    }
}
