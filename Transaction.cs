public class Transaction
{
    public int Points { get; private set; }  // Poeng endring i transaksjonen (positiv eller negativ)
    public string Reason { get; private set; }  // Hvorfor transaksjonen skjedde
    public DateTime Date { get; private set; }  // Dato for transaksjonen

    public Transaction(int points, string reason)
    {
        Points = points;
        Reason = reason;
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{Date}: {Points} poeng for '{Reason}'";
    }
}