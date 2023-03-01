using CISESPORT.Class;
using Newtonsoft.Json;
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
    public partial class Players : Form
    {
        public static Players Instance;          
        public List<PlayerClass> players = new List<PlayerClass>();
        public Players()
        {
            InitializeComponent();
            Instance = this;
        }

        private void newPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            Player_Register player_Register = new Player_Register();
            player_Register.ShowDialog();
            if(player_Register.DialogResult== DialogResult.OK )
            {
                players.Add(player_Register.getPlayer());
                RefresDategrid();
            }

        }
        private void RefresDategrid()
        {
            dataGridView1.Rows.Clear();
            foreach(PlayerClass player_s in players)
            {
                dataGridView1.Rows.Add(player_s.Name,player_s.Lasname, player_s.StudenID, player_s.Majoy, player_s.Display, player_s.Mail, player_s.Phone, player_s.Age);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Player";
            save.Filter = "Json|*.json";
            save.ShowDialog();
            if(save.FileName != "")
            {
                string json = JsonConvert.SerializeObject(players, Formatting.Indented);
                File.WriteAllText(save.FileName, json);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open= new OpenFileDialog();
            open.FileName = "Players";
            open.Filter = "Json|*.json";
            open.ShowDialog();
            if(open.FileName != "")
            {
                players = JsonConvert.DeserializeObject<List<PlayerClass>>(File.ReadAllText(open.FileName));
                RefresDategrid();
            }

        }

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Team team = new Team();
            team.ShowDialog();

        }
    }
}
