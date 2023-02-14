using Evidence_pojisteni;

internal class Program
{
    private static void Main(string[] args)
    {
        Seznam seznam = new Seznam();
        
        char volba = '0';
        while (volba != '4')
        {
        Seznam.Menu();
            volba = Console.ReadKey(true).KeyChar;
            switch (volba)
            {
                case '1':
                    seznam.PridejZaznam();
                    break;
                case '2':
                    seznam.VypisZaznamy();
                    break;
                case '3':
                    seznam.HledejZaznamy();
                    break;
                case '4':
                    Console.WriteLine("Libovolnou klávesou ukončíte program...");
                    break;
                default:
                    Console.WriteLine("Neplatná volba, stiskněte libovolnou klávesu a opakujte volbu.");
                    break;
            }

        }
    }
}