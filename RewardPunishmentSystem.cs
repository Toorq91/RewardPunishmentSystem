public class RewardPunishmentSystem
{
    private List<User> users = new List<User>();  // Liste over alle brukere

    // Hovedmenyen for systemet
    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            ShowMenu();  // Vis menyen og brukere
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    GiveReward();
                    break;
                case "3":
                    GivePunishment();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ugyldig valg, prøv igjen.");
                    break;
            }
        }
    }

    // Viser menyen og alle brukere med poeng
    private void ShowMenu()
    {
        Console.WriteLine("Belønning og straffesystem\n");
        Console.WriteLine("1. Legg til bruker");
        Console.WriteLine("2. Gi belønning");
        Console.WriteLine("3. Gi straff");
        Console.WriteLine("4. Avslutt\n");
        ShowAllUsers();
        Console.Write("Velg et alternativ: ");
    }

    // Funksjon for å legge til en ny bruker
    private void AddUser()
    {
        Console.Write("Skriv inn brukerens navn: ");
        string name = Console.ReadLine();
        users.Add(new User(name));
        Console.WriteLine($"Bruker {name} er lagt til.");
    }

    // Funksjon for å gi en belønning til en bruker
    private void GiveReward()
    {
        User user = FindUser();
        if (user != null)
        {
            Console.Write("Hvor mange poeng vil du gi? ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("Hvorfor gir du belønning? ");
            string reason = Console.ReadLine();

            user.AddPoints(points, reason);
            Console.WriteLine($"{points} poeng er gitt til {user.Name} for '{reason}'. Ny saldo: {user.Points} poeng.");
        }
    }

    // Funksjon for å gi en straff til en bruker
    private void GivePunishment()
    {
        User user = FindUser();
        if (user != null)
        {
            Console.Write("Hvor mange poeng vil du trekke? ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("Hvorfor gir du straff? ");
            string reason = Console.ReadLine();

            user.AddPoints(-points, reason);
            Console.WriteLine($"{points} poeng er trukket fra {user.Name} for '{reason}'. Ny saldo: {user.Points} poeng.");
        }
    }

    // Viser alle brukere og deres poengsaldo, samt transaksjoner
    private void ShowAllUsers()
    {
        Console.WriteLine("Liste over brukere og deres poeng:");
        if (users.Count == 0)
        {
            Console.WriteLine("Ingen brukere registrert.\n");
        }
        else
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine(); // For linjeavstand
        }
    }

    // Hjelpemetode for å finne en bruker basert på navn
    private User FindUser()
    {
        Console.Write("Skriv inn brukerens navn: ");
        string name = Console.ReadLine();
        User user = users.Find(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (user == null)
        {
            Console.WriteLine($"Brukeren {name} ble ikke funnet.");
        }

        return user;
    }
}