using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopujcovna
{
    /// <summary>
    /// Třída pro reprezentaci výpůjčky vozidla.
    /// </summary>
    public class Vypujcka
    {
        /// <summary>
        /// Vozidlo, které bylo půjčeno.
        /// </summary>
        public OsobniAuto Vozidlo {  get; private set; }
        /// <summary>
        /// Datum začátku výpůjčky.
        /// </summary>
        public DateTime ZacatekVypujcky {  get; private set; }
        /// <summary>
        /// Datum konce výpůjčky.
        /// </summary>
        public DateTime KonecVypujcky { get; private set; }
        /// <summary>
        /// Celková cena výpůjčky.
        /// </summary>
        public double CelkovaCenaVypujcky { get; private set; }

        /// <summary>
        /// Konstruktor pro vytvoření nové výpůjčky vozidla.
        /// </summary>
        /// <param name="vozidlo">Zapůjčené vozidlo.</param>
        /// <param name="zacatekVypujcky">Datum začátku výpůjčky vozidla.</param>
        /// <param name="konecVypujcky">Datum konce výpůjčky vozidla.</param>
        public Vypujcka(OsobniAuto vozidlo, DateTime zacatekVypujcky, DateTime konecVypujcky)
        {
            if (zacatekVypujcky < DateTime.Now.Date)
            {
                throw new ArgumentException("Začátek výpůjčky nesmí být v minulosti.");
            }

            if (zacatekVypujcky >= konecVypujcky)
            {
                throw new ArgumentException("Začátek výpůjčky nesmí být po jejím konci.");
            }

            if (vozidlo.Stav != StavVypujckyVozidla.Volne)
            {
                throw new ArgumentException("Vozidlo momentálně není k dispozici pro výpůjčku.");
            }

            Vozidlo = vozidlo;
            ZacatekVypujcky = zacatekVypujcky;
            KonecVypujcky = konecVypujcky;
            CelkovaCenaVypujcky = VypocitejCenuVypujcky();
            vozidlo.Stav = StavVypujckyVozidla.Pujcene;
        }

        /// <summary>
        /// Ukončení výpůjčky vozidla.
        /// </summary>
        /// <param name="vozidlo">Objekt vozidla, které má být vráceno.</param>
        public void UkoncitVypujcku(OsobniAuto vozidlo)
        {
            if(vozidlo.Stav != StavVypujckyVozidla.Pujcene)
            {
                throw new InvalidOperationException("Vozidlo není půjčené, nelze ukončit výpujčku!");
            }
            else
            {
                vozidlo.Stav = StavVypujckyVozidla.Volne;
                Console.WriteLine($"Výpůjčka vozidla {vozidlo.Spz} byla ukončena.");
            }
        }

        /// <summary>
        /// Výpočet ceny výpůjčky.
        /// </summary>
        /// <returns>Celková cena výpůjčky v Kč.</returns>
        private double VypocitejCenuVypujcky()
        {
            int pocetDni = (KonecVypujcky.Date - ZacatekVypujcky.Date).Days;
            return pocetDni * Vozidlo.TarifPujcovneho;
        }

        /// <summary>
        /// Textový výstup výpůjčky.
        /// </summary>
        /// <returns>Textová reprezentace výpůjčky.</returns>
        public override string ToString()
        {
            return $"Vozidlo: {Vozidlo.Spz}\nOd: {ZacatekVypujcky}\nDo: {KonecVypujcky}\nCena: {CelkovaCenaVypujcky} Kč";
        }
    }
}
