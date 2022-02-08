using Task_3._3._3._PIZZA_TIME.Entities;

//как подписать пицерию к ивенту заказного стола?
OrderTable.NewOrder += Pizzeria.ConfirmOrder;

Client artem = new Client("Artem");

artem.MakeOrder(PizzaType.Margarita);