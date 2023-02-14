namespace Evidence_pojisteni
{
    internal class Seznam
    {
        private Databaze databaze = new Databaze();

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
            string vek;
            while (string.IsNullOrEmpty(vek = Console.ReadLine()))
            {
                Console.WriteLine("Zajte text znovu");
            }
            return int.Parse(vek);
        }
        private static string ZjistiTel()
        {
            Console.WriteLine("Zadejte telefon:");
            string tel;
            while (string.IsNullOrEmpty(tel = Console.ReadLine()))
            {
                Console.WriteLine("Zajte text znovu");
            }
            return tel;
        }
        public void VypisZaznamy()
        {
            List<Pojistenec> zaznamy = databaze.VypisZaznamy();
            if (zaznamy.Count() > 0)
            {
                Console.Write("Jmeno | Primení | Vek | Telefon");
                Console.WriteLine();
                Console.WriteLine();
                foreach (Pojistenec p in zaznamy)
                    Console.WriteLine(p);
            }
            else
                Console.WriteLine("Nebyly nalezeny žádné záznamy.");
            Console.ReadLine();

        }
        public void HledejZaznamy()
        {
            string jmeno = ZjistiJmeno();
            string prmeni = ZjistiPrimeni();
            List<Pojistenec> zaznamy = databaze.NajdiZaznamy(jmeno, prmeni);
            if (zaznamy.Count() > 0)
            {
                Console.Write("Jmeno | Primení | Vek | Telefon");
                Console.WriteLine();
                Console.WriteLine();
                foreach (Pojistenec p in zaznamy)
                    Console.WriteLine(p);
            }
            else
                Console.WriteLine("Nebyly nalezeny žádné záznamy.");
            Console.ReadLine();

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
    }
}
