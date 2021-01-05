using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using System.Data;
using System.Data.SqlClient;
namespace Server
{
    public class Broker
    {
        SqlConnection konekcija;
        SqlCommand komanda;
        SqlTransaction transakcija;

        void konektujSe()
        {
            konekcija = new SqlConnection(@"");
            komanda = konekcija.CreateCommand();
        }

        Broker()
        {
            konektujSe();
        }

        static Broker instanca;
        public static Broker dajSesiju()
        {
            if (instanca == null)
                instanca = new Broker();
            return instanca;
        }
    }
}
