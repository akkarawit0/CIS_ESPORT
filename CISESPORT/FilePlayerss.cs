using CISESPORT.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CISESPORT
{
    public partial class FilePlayerss : Form
    {
        PlayerClass player;
        public FilePlayerss()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            foreach (PlayerClass player_s in Players.Instance.players)
            {
                dataGridView1.Rows.Add(player_s.Name, player_s.Lasname, player_s.StudenID, player_s.Majoy, player_s.Display, player_s.Mail, player_s.Phone, player_s.Age);
            }
        }

        public PlayerClass GetPlayer()
        {
            return player;
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            PlayerClass pc = Players.Instance.players[dataGridView1.CurrentRow.Index];
            player = pc;
            this.DialogResult = DialogResult.OK;
        }
    }
}
