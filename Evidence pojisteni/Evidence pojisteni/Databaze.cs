namespace Evidence_pojisteni
{
    internal class Databaze
    {
        private List<Pojistenec> zaznamy = new List<Pojistenec>();

        /// <summary>
        /// P/řidání pojistitele do seznamu
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="primeni"></param>
        /// <param name="vek"></param>
        /// <param name="telefon"></param>
        public void PridejZaznam(string jmeno, string primeni, int vek, string telefon)
        {
            zaznamy.Add(new Pojistenec(jmeno, primeni, vek, telefon));
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
            foreach (Pojistenec p in zaznamy)
            {
                if ((jmeno.Equals(p.Jmeno)) && (primeni.Equals(p.Primeni)))
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
            return zaznamy;
        }

    }
}
