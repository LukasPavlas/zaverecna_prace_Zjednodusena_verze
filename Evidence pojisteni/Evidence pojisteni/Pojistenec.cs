using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_pojisteni
{
    internal class Pojistenec
    {
        /// <summary>
        /// Jměno pojištěnce
        /// </summary>
        public string Jmeno { get; private set; }
        /// <summary>
        /// Příjmení pojištence
        /// </summary>
        public string Primeni { get; private set; }
        /// <summary>
        /// Věk pojištence
        /// </summary>
        public int Vek { get; private set; }
        /// <summary>
        /// Telefon pojištence
        /// </summary>
        public string Tel { get; private set; }

        public Pojistenec (string jmeno, string primeni, int vek, string tel)
        {
            Jmeno = jmeno;
            Primeni = primeni;
            Vek = vek;
            Tel = tel;
        }

        public override string ToString()
        {
            return Jmeno + "\t" + Primeni+ "\t\t" + Vek + "\t" + Tel;
        }

    }
}
