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
namespace Server
{
    class Nit
    {
        private NetworkStream tok;
        BinaryFormatter formater;
        public Nit(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart ts = obradi;
            new Thread(ts).Start();
        }

        void obradi()
        {
            try
            {
                int operacija = 0;
                while (operacija != (int)Operacije.Kraj)
                {
                    // uzima iz toka
                    // a to je transfer klasa
                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;

                    switch (transfer.operacija)
                    {
                            // primer drugih
                            //case Operacije.Login:
                            //transfer.Rezultat = Broker.dajSesiju().login(transfer.TransferObjekat as Korisnik);
                            //formater.Serialize(tok, transfer);
                            //break;
                        case Operacije.Kraj: operacija = 1;
                            break;
                        default: break;
                    }
                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}
