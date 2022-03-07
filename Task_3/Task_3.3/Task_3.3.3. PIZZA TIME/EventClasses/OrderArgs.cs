using Task_3._3._3._PIZZA_TIME.Entities;

namespace Task_3._3._3._PIZZA_TIME.EventClasses
{
    public class OrderArgs : EventArgs
    {
        public int ID { get; }
        public PizzaType TypePizza { get; }

        public OrderArgs(int ID, PizzaType pizzaType)
        {
            this.ID = ID;
            this.TypePizza = pizzaType;
        }
    }
}
