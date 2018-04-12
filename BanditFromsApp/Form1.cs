using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanditFromsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Arena games = new Arena(int.Parse(txtBanditCount.Text));
            games.Initiate();
            games.RunGame(int.Parse(txtIteration.Text));
            txtStatus.Text = "Finnished";
        }
    }
}
