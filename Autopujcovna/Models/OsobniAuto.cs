using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopujcovna
{
    /// <summary>
    /// Třída reprezentující osobní automobil, který je spravován v systému.
    /// </summary>
    public class OsobniAuto : Vozidlo
    {
        /// <summary>
        /// SPZ vozidla.
        /// </summary>
        public string Spz { get; set; }
        /// <summary>
        /// Tarif půjčovného za den.
        /// </summary>
        public double TarifPujcovneho {  get; set; }
        /// <summary>
        /// Stav vozidla (Volné, Půjčené, Rezervované).
        /// </summary>
        public StavVypujckyVozidla Stav { get; set; }

        /// <summary>
        /// Konstruktor pro vytvoření nového osobního auta.
        /// </summary>
        /// <param name="znacka">Značka vozidla.</param>
        /// <param name="model">Model vozidla.</param>
        /// <param name="rokVyroby">Rok výroby vozidla.</param>
        /// <param name="spz">SPZ vozidla.</param>
        /// <param name="tarifPujcovneho">Cena půjčovného za den.</param>
        public OsobniAuto(string znacka, string model, int rokVyroby, string spz, double tarifPujcovneho)
            : base(znacka, model, rokVyroby)
        {
            Spz = spz;
            TarifPujcovneho = tarifPujcovneho;
            Stav = StavVypujckyVozidla.Volne;
        }

        public override string ToString() => $"{base.ToString()} - SPZ: {Spz} - Stav: {Stav}\n Tarif: {TarifPujcovneho} Kc (den)";

        /// <summary>
        /// Metoda pro rezervaci vozidla.
        /// </summary>
        public void Rezervovat()
        {
            if (Stav == StavVypujckyVozidla.Volne)
            {
                Stav = StavVypujckyVozidla.Rezervovane;
                Console.WriteLine($"Vozidlo {Znacka} {Model} - SPZ: {Spz} bylo uspěšně rezervované.");
            }
            else
            {
                Console.WriteLine($"Vozidlo {Znacka} {Model} - SPZ: {Spz} není k dispozici pro rezervaci!");
            }
        }

        /// <summary>
        /// Metoda pro zapůjčení vozidla.
        /// </summary>
        public void Pujcit()
        {
            if (Stav == StavVypujckyVozidla.Volne || Stav == StavVypujckyVozidla.Rezervovane)
            {
                Stav = StavVypujckyVozidla.Pujcene;
                Console.WriteLine($"Vozidlo {Znacka} {Model} - SPZ: {Spz} bylo uspěšně zapůjčeno.");
            }
            else
            {
                Console.WriteLine($"Vozidlo {Znacka} {Model} - SPZ: {Spz} není k dispozici pro výpůjčku!");
            }
        }

        /// <summary>
        /// Metoda pro vrácení vozidla.
        /// </summary>
        public void Vrátit()
        {
            if (Stav == StavVypujckyVozidla.Pujcene || Stav == StavVypujckyVozidla.Rezervovane)
            {
                Stav = StavVypujckyVozidla.Volne;
                Console.WriteLine($"Vozidlo {Znacka} {Model} - SPZ: {Spz} bylo uspěšně vráceno a je opět k dispozici.");
            }
            else
            {
                Console.WriteLine($"Vozidlo {Znacka} {Model} - SPZ: {Spz} není zapůjčeno.");
            }
        }
    }
}
