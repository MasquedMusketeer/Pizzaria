class Pizza
{
    public string Nome { get; }
    public string[] Ingredientes { get; }
    public decimal Valor { get; }

    public Pizza(string nome, string[] ingredientes, decimal valor)
    {
        Nome = nome;
        Ingredientes = ingredientes;
        Valor = valor;
    }
}