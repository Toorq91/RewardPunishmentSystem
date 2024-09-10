public class User
{
    public string Name { get; private set; }  // Brukerens navn
    public int Points { get; private set; } = 0;  // Brukerens poengsaldo
    public List<Transaction> Transactions { get; private set; }  // Transaksjonshistorikk

    public User(string name)
    {
        Name = name;
        Transactions = new List<Transaction>();
    }

    // Legger til poeng og lagrer en ny transaksjon
    public void AddPoints(int points, string reason)
    {
        Points += points;
        Transactions.Add(new Transaction(points, reason));
    }

    // Viser brukeren som en streng med poengsaldo og transaksjoner
    public override string ToString()
    {
        string result = $"Navn: {Name}, Poeng: {Points}\nTransaksjoner:\n";
        if (Transactions.Count == 0)
        {
            result += "  Ingen transaksjoner.";
        }
        else
        {
            foreach (var transaction in Transactions)
            {
                result += $"  {transaction}\n";
            }
        }
        return result;
    }
}