using Task_3._3._3._PIZZA_TIME.Entities;

OrderTable.NewOrder += Pizzeria.ReadyOrder;
Pizzeria.OnReady += OrderTable.ReadyOrder;
Client artem = new Client ("Artem");
artem.MakeOrder(PizzaType.Margarita);
artem.MakeOrder(PizzaType.Margarita);