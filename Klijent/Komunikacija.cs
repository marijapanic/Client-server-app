using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
namespace Klijent
{
    public class Komunikacija
    {
        TcpClient klijent; // 
        NetworkStream tok; // tokomkoga ce komunicirati
        BinaryFormatter formater;   // pomocu koga ce komunicirati

        public bool poveziSe()
        {
            try
            {

                klijent = new TcpClient("127.0.0.1", 20000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void kraj()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.operacija = Operacije.Kraj;
            // slanje podataka
            formater.Serialize(tok,transfer);
        }
        /* primer metode
        public Korisnik login(Korisnik k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.Login;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as Korisnik;
        }
        */
    }
}
