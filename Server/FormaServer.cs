using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormaServer : Form
    {
        Server s;
        Timer t
        public FormaServer()
        {
            InitializeComponent();
        }

        private void FormaServer_Load(object sender, EventArgs e)
        {
            s = new Server();
            if (s.pokreniServer())
            {
                this.Text = "Server je pokrenut";
                
                t = new Timer();
                t.Interval = 2000;
                t.Tick += osvezi;
                t.Start();
            }
        }
        
        private void osvezi(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Broker.dajSesiju().vratiSveReci();
            dataGridView1.Columns[0].Width = 100;
        }
    }
}
