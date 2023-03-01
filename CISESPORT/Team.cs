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
    
    public partial class Team : Form //ทีมที่มี Data Grid
    {
        List<TeamClass> team = new List<TeamClass>();

        public Team()
        {
            InitializeComponent();
        }

        
        private void newTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Team_Register team_Register = new Team_Register();
            team_Register.ShowDialog();
            if (team_Register.DialogResult == DialogResult.OK)
            {
                TeamClass team = team_Register.GetTeam();

                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(team.TeamName, team.Members[0].Name, team.Members[1].Name, team.Members[2].Name, team.Members[3].Name, team.Members[4].Name);
            }
        }

        private void RefresDategrid()
        {
            dataGridView1.Rows.Clear();
            foreach (TeamClass team in team)
            {

                dataGridView1.Rows.Add(team.TeamName, team.Members[0].Name, team.Members[1].Name, team.Members[2].Name, team.Members[3].Name, team.Members[4].Name);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Team";
            save.Filter = "Json|*.json";
            save.ShowDialog();
            if (save.FileName != "")
            {
                string json = JsonConvert.SerializeObject(team, Formatting.Indented);
                File.WriteAllText(save.FileName, json);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "Players";
            open.Filter = "Json|*.json";
            open.ShowDialog();
            if (open.FileName != "")
            {
                team = JsonConvert.DeserializeObject<List<TeamClass>>(File.ReadAllText(open.FileName));
                RefresDategrid();
            }
        }
    }
}
