    namespace Evidence_pojisteni
{
    internal class Databaze
    {
        private string Soubor;
        private List<Pojistenec> Zaznamy;

        public Databaze (string soubor)
        {
            Zaznamy = new List<Pojistenec>();
            Soubor = soubor;
        }
        
        /// <summary>
        /// P/řidání pojistitele do seznamu
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="primeni"></param>
        /// <param name="vek"></param>
        /// <param name="telefon"></param>
        public void PridejZaznam(string jmeno, string primeni, int vek, string telefon)
        {
            Zaznamy.Add(new Pojistenec(jmeno, primeni, vek, telefon));
        }
        /// <summary>
        /// Vyhledání pojistitelů podle jména a příjmení
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="primeni"></param>
        /// <returns>Seznam pojistitelů podle jména a příjmení</returns>
        public List<Pojistenec> NajdiZaznamy(string jmeno, string primeni)
        {
            List<Pojistenec> nalezene = new List<Pojistenec>();
            foreach (Pojistenec p in Zaznamy)
            {
                if ((jmeno.Contains(p.Jmeno)) && (primeni.Contains(p.Primeni)))
                {
                    nalezene.Add(p);
                }
            }
            return nalezene;
        }
        /// <summary>
        /// Vypíše všdechny záznamy v seznamu
        /// </summary>
        /// <returns></returns>
        public List<Pojistenec> VypisZaznamy()
        {
            return Zaznamy; 
        }

        public void Uloz()
        {
            using (StreamWriter sw = new StreamWriter(Soubor))
            {
                foreach (Pojistenec p in Zaznamy)
                {
                    string[] hodnoty = { p.Jmeno, p.Primeni, p.Vek.ToString(), p.Tel };
                    string radek = String.Join(",", hodnoty);
                    sw.WriteLine(radek);
                }
                sw.Flush();
            }
        }
        public void Nacti()
        {
            if (File.Exists(Soubor))
            {
                if (!string.IsNullOrEmpty(File.ReadAllText(Soubor)))
                {
                    using (StreamReader sr = new StreamReader(Soubor))
                    {
                        string s;
                        while((s = sr.ReadLine()) != null)
                        {
                            string[] rozdeleno = s.Split(',');
                            string jmeno = rozdeleno[0];
                            string primeni = rozdeleno[1];
                            int vek =int.Parse(rozdeleno[2]);
                            string tel = rozdeleno[3];
                            PridejZaznam(jmeno, primeni, vek, tel);
                        }
                    }

                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(Soubor)) { }
            }


        }
    }
}
