using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int maxSize = 10; 
        Pizza[] pizzas = new Pizza[maxSize];
        int pizzaCount = 0; 

        List<Pedido> pedidos = new List<Pedido>();

        while (true)
        {
            Console.WriteLine("-|-              Menu:              -|-");
            Console.WriteLine("          ( 1 ) Add pizza");
            Console.WriteLine("          ( 2 ) List pizzas");
            Console.WriteLine("          ( 3 ) Place new order");
            Console.WriteLine("          ( 4 ) Wish List");
            Console.WriteLine("          ( 5 ) pick up order");
            Console.WriteLine("          ( 6 ) Exit");
            Console.WriteLine("-|-        Choose an option:        -|-");

            int escolha;
            if (!int.TryParse(Console.ReadLine(), out escolha))
            {
                Console.WriteLine("Invalid option. Try again.");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    if (pizzaCount < maxSize)
                    {
                                Console.WriteLine("Add pizza");
                                Console.Write("Enter the name of the pizza: ");
                        string nome = Console.ReadLine();
                        Console.Write("Enter the pizza ingredients (separated by commas): ");
                        string[] ingredientes = Console.ReadLine().Split(',');

                        Console.Write("Enter the price of the pizza: ");
                        decimal valor;
                        if (!decimal.TryParse(Console.ReadLine(), out valor))
                        {
                            Console.WriteLine("Invalid value. Try again.");
                            break;
                        }

                        Pizza novaPizza = new Pizza(nome, ingredientes, valor);
                        pizzas[pizzaCount] = novaPizza;
                        pizzaCount++;

                        Console.WriteLine("Pizza created successfully!");
                            }
                    else
                    {
                                Console.WriteLine("Maximum pizza limit reached.");
                            }
                    break;

                case 2:
                        Console.WriteLine("pizza list");
                        for (int i = 0; i < pizzaCount; i++)
                    {
                        Console.WriteLine($"{i + 1}. {pizzas[i].Nome} - Valor: {pizzas[i].Valor:C}");
                    }
                        break;

                case 3:
                        Console.WriteLine("new request");
                        Console.Write("Who is the customer? ");
                    string nomeCliente = Console.ReadLine();
                    Console.Write("What is the customer's phone number? ");
                    string telefone = Console.ReadLine();

                    List<Pizza> pizzasPedido = new List<Pizza>();
                    decimal totalPedido = 0;

                    do
                    {
                        Console.WriteLine("Choose a pizza to add (enter number):");
                        for (int i = 0; i < pizzaCount; i++)
                        {
                            Console.WriteLine($"{i + 1}. {pizzas[i].Nome} - Valor: {pizzas[i].Valor:C}");
                        }

                        if (int.TryParse(Console.ReadLine(), out int pizzaIndex) && pizzaIndex >= 1 && pizzaIndex <= pizzaCount)
                        {
                            Pizza pizzaSelecionada = pizzas[pizzaIndex - 1];
                            pizzasPedido.Add(pizzaSelecionada);
                            totalPedido += pizzaSelecionada.Valor;

                            Console.Write("Do you want to add another pizza? (1 - YES | 2 - NO):");
                        }
                        else
                        {
                            Console.WriteLine("Invalid pizza. Try again.");
                        }
                    } while (Console.ReadLine() == "1");

                    Pedido novoPedido = new Pedido(nomeCliente, telefone, pizzasPedido, totalPedido);
                    pedidos.Add(novoPedido);

                        Console.WriteLine($"ORDER CREATED - Total: {novoPedido.Amount:C}");
                        break;

                case 4:
                        Console.WriteLine("Wish list");
    
                    for (int i = 0; i < pedidos.Count; i++)
                    {
                        var pedido = pedidos[i];
                        Console.WriteLine($"Client: {pedido.NameC} - telephone: {pedido.Tel}");
                        Console.WriteLine("Order Pizzas:");
                        foreach (var pizzaPedido in pedido.PizzasSelecionadas)
                        {
                            Console.WriteLine($"{pizzaPedido.Nome} - Value: {pizzaPedido.Valor:C}");
                        }
                        Console.WriteLine($"Total: {pedido.Amount:C}");

                        if (pedido.FoiPago)
                        {
                            Console.WriteLine("How much remains to pay: $00.00");
                            Console.WriteLine("Paid: YES");
                        }
                        else
                        {
                            Console.WriteLine($"How much is left to pay: {pedido.Amount - pedido.ValorPago:C}");
                            Console.WriteLine("Paid: NO");
                        }
                    }
                        break;

                case 5:
                        Console.WriteLine("Order payment");
                        Console.WriteLine("Wish list:");
                    for (int i = 0; i < pedidos.Count; i++)
                    {
                        var pedido = pedidos[i];
                        Console.WriteLine($"{i + 1}. Client: {pedido.NameC} - Lack: {pedido.Amount - pedido.ValorPago:C}");
                    }

                    Console.Write("What is the order number: ");
                    if (int.TryParse(Console.ReadLine(), out int pedidoIndex) && pedidoIndex >= 1 && pedidoIndex <= pedidos.Count)
                    {
                        var pedidoEscolhido = pedidos[pedidoIndex - 1];

                        Console.WriteLine(" ");
                        Console.WriteLine("-|-           CHOOSE A WAY TO PAY          -|-");
                        Console.WriteLine("                ( 1 ) - Money");
                        Console.WriteLine("              ( 2 ) - Debit card");
                        Console.WriteLine("              ( 3 ) - Meal ticket");
                        Console.Write("-|-       Enter the payment method number       -|-");
                        Console.WriteLine(" ");

                        if (int.TryParse(Console.ReadLine(), out int formaPagamento) && formaPagamento >= 1 && formaPagamento <= 3)
                        {
                            pedidoEscolhido.FormaPagamento = GetFormaPagamentoString(formaPagamento);

                            Console.Write("Payment amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal valorRecebido))
                            {
                                pedidoEscolhido.ValorPago = valorRecebido;
                                pedidoEscolhido.FoiPago = true;
                                Console.WriteLine(" ");
                                Console.WriteLine($"TOTAL PAID: {pedidoEscolhido.ValorPago:C} - {pedidoEscolhido.FormaPagamento}");
                                Console.WriteLine($"LACK: {pedidoEscolhido.Amount - pedidoEscolhido.ValorPago:C}");
                                Console.WriteLine($"CHANGE: {pedidoEscolhido.ValorPago - pedidoEscolhido.Amount:C}");
                            }
                            else
                            {
                                                Console.WriteLine("Invalid value.");
                                            }
                        }
                        else
                        {
                                        Console.WriteLine("OInvalid payment method option.");
                                    }
                    }
                    else
                    {
                                Console.WriteLine("Invalid order number.");
                            }
                    break;

                case 6:
                        Console.WriteLine("Leaving the program.");
                        return;

                default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
            }
        }
    }

    private static string GetFormaPagamentoString(int formaPagamento)
    {
        switch (formaPagamento)
        {
            case 1:
                return "Money";
            case 2:
                return "Debit card";
            case 3:
                return "Meal ticket";
            default:
                return "Unknown";
        }
    }
}





   
