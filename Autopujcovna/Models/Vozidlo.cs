using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopujcovna
{
    public class Vozidlo
    {
        public string Znacka { get; set; }
        public string Model { get; set; }
        public int RokVyroby { get; set; }

        public Vozidlo(string znacka, string model, int rokVyroby)
        {
            Znacka = znacka;
            Model = model;
            RokVyroby = rokVyroby;
        }

        public override string ToString()  => $"{Znacka} {Model} - Rok výroby: {RokVyroby}";
        
    }
}
