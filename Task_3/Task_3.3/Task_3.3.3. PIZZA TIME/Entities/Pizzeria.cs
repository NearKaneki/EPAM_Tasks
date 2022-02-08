using Task_3._3._3._PIZZA_TIME.EventClasses;

namespace Task_3._3._3._PIZZA_TIME.Entities
{
    static public class Pizzeria
    {
        public static event Action OnReady = () => { };

        static public void ReadyOrder(object sender,OrderArgs orderArgs )
        {
            
            OnReady?.Invoke();
        }
    }
}
