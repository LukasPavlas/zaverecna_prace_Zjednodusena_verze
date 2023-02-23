using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Evidence_pojisteni
{
    internal class Seznam
    {
        private Databaze databaze = new Databaze("data.csv");

        private static string ZjistiJmeno()
        {
            Console.WriteLine("Zadejte jméno pojisteného:");
            string jmeno;
            while (string.IsNullOrEmpty(jmeno = Console.ReadLine()))
            {
                Console.WriteLine("Zajte text znovu");
            }
            return jmeno;
        }
        private static string ZjistiPrimeni()
        {
            Console.WriteLine("Zadejte přijmení:");
            string primeni;
            while (string.IsNullOrEmpty(primeni = Console.ReadLine()))
            {
                Console.WriteLine("Zajte text znovu");
            }
            return primeni;
        }
        private static int ZjistiVek()
        {
            Console.WriteLine("Zadejte Věk:");
            string strVek;
            int intVek;
            while (string.IsNullOrEmpty(strVek = Console.ReadLine()))
            {
                Console.WriteLine("Zajte text znovu");
            }
            if (int.TryParse(strVek,out intVek) && (strVek.Length <= 3))
            {
                return intVek;
            }
            else
            {
                Console.WriteLine("Špatný formát věku. Zkuste to znovu:");
                return ZjistiVek();
            }


        }
        private static string ZjistiTel()
        {
            Regex regex = new Regex(@"^\+420\s[1-9][0-9]{2}\s[0-9]{3}\s[0-9]{3}$");
            Console.WriteLine("Zadejte telefon v formátru +420 123 456 789:");
            string tel;
            while (string.IsNullOrEmpty(tel = Console.ReadLine()))
            {
                Console.WriteLine("Zajte text znovu");
            }
            if (!regex.IsMatch(tel))
            {
                Console.WriteLine("Telefonní číslo není platné.");
                return ZjistiTel();
            }
            return tel;
        }
        private static void ZjistiZaznam(List<Pojistenec> list)
        {
            if (list.Count() > 0)
            {
                Console.WriteLine("Jmeno\tPrimení\t\tVěk\tTelefon");
                Console.WriteLine("-----------------------------------------------\n");
                foreach (Pojistenec p in list)
                    Console.WriteLine(p + "\n");
            }
            else
                Console.WriteLine("Nebyly nalezeny žádné záznamy.");
            Console.ReadLine();
        }
        public void VypisZaznamy()
        {
            List<Pojistenec> zaznamy = databaze.VypisZaznamy();
            ZjistiZaznam(zaznamy);


        }
        public void HledejZaznamy()
        {
            string jmeno = ZjistiJmeno();
            string prmeni = ZjistiPrimeni();
            List<Pojistenec> zaznamy = databaze.NajdiZaznamy(jmeno, prmeni);
            ZjistiZaznam(zaznamy);


        }
        public void PridejZaznam()
        {
            Console.WriteLine();
            string jmeno = ZjistiJmeno();
            string primeni = ZjistiPrimeni();
            string tel = ZjistiTel();
            int vek = ZjistiVek();
            databaze.PridejZaznam(jmeno, primeni, vek, tel);
            Console.WriteLine("Data byla ulozena. pokracujte libovolnou klávesou...");
            Console.ReadLine();
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Evidence pojisteni");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            Console.WriteLine("Vyberte si akci");
            Console.WriteLine("1 - Přidat nového pojisteného");
            Console.WriteLine("2 - Vypsat všechny pojistené");
            Console.WriteLine("3 - Vyhledat pojisteneho");
            Console.WriteLine("4 - Konec");
            Console.WriteLine();
        }
        public void Uloz()
        {
            databaze.Uloz();
        }
        public void nacti()
        {
            databaze.Nacti();
        }
    }
}
