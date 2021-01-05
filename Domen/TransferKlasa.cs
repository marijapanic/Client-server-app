using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    // sve moraju biti seriajabilne
    // da bi mogle da se posalju kroz tok

    public enum Operacije { Kraj  = 1};
    [Serializable]
    public class TransferKlasa
    {
        // prikazi, izracunaj itd...
        // sta zelimo da uradimo od operacija
        public Operacije operacija;

        // prenositi podatke od klijenta do servera
        public object transferObjekat;
        // rezultat sta vrati server
        public object rezultat;
    }
}
