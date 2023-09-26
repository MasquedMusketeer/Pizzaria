class Pedido
{
    public string NameC { get; }
    public string Tel { get; }
    public List<Pizza> PizzasSelecionadas { get; } 
    public decimal Amount { get; }
    public bool FoiPago { get; set; }
    public string FormaPagamento { get; set; }
    public decimal ValorPago { get; set; }

    public Pedido(string nameC, string tel, List<Pizza> pizzasSelecionadas, decimal amount)
    {
        NameC = nameC;
        Tel = tel;
        PizzasSelecionadas = pizzasSelecionadas;
        Amount = amount;
        FoiPago = false;
        FormaPagamento = string.Empty;
        ValorPago = 0;
    }
}