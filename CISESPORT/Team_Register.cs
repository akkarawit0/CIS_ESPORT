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
using System.Windows.Forms.VisualStyles;

namespace CISESPORT
{
    public partial class Team_Register : Form //ลงทะเบียน
    {
        TeamClass team;
        List<PlayerClass> listplayer = new List<PlayerClass>();
        public Team_Register()
        {
            InitializeComponent();
            for(int i = 0; i < 5; i++)
            {
                PlayerClass player= new PlayerClass();
                player.Name = "";
                player.Lasname = "";
                player.StudenID = "";
                player.Majoy = "";
                player.Display = "";
                player.Mail = "";
                player.Phone = "";
                player.Age = 0;
                listplayer.Add(player);

            }
        }

        private void Add_Team_Click(object sender, EventArgs e)
        {
            string TeamName = tbNameTeam.Text;
            team = new TeamClass();
            team.TeamName = TeamName;
            team.Members = this.listplayer;
            this.team = team;
            this.DialogResult = DialogResult.OK;
        }

        private void EvenOnClick(object sender, EventArgs e)
        {
            Button kk = (Button)sender;
            if (kk.Name == "Find_1")
            {
                FilePlayer(0, tb1);
            }
            else if (kk.Name == "Find_2")
            {
                FilePlayer(1, tb2);
            }
            else if (kk.Name == "Find_3")
            {
                FilePlayer(2, tb3);
            }
            else if (kk.Name == "Find_4")
            {
                FilePlayer(3, tb4);
            }
            else if (kk.Name == "Find_5")
            {
                FilePlayer(4, tb5);
            }

        }
        private void FilePlayer(int index, TextBox textbox)
        {
            FilePlayerss filePlayerss = new FilePlayerss();
            filePlayerss.ShowDialog();
            if(filePlayerss.DialogResult == DialogResult.OK)
            {
                listplayer[index] = filePlayerss.GetPlayer();
                textbox.Text = filePlayerss.GetPlayer().Name;
            }
        }
        public TeamClass GetTeam()
        {
            return this.team;
        }
    }
}
