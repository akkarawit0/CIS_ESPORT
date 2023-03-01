using CISESPORT.Class;

namespace CISESPORT
{
    public partial class Player_Register : Form
    {
        PlayerClass player;
        public Player_Register()
        {
            InitializeComponent();
        }

        private void Add_Player_Click(object sender, EventArgs e)
        {
            string Name = tbName.Text;
            string Lasname = tbLasname.Text;
            string StudenID = tbStudenID.Text;
            string Majoy = tbMajoy.Text;
            string Display = tbDisplay.Text;
            string Mail = tbMail.Text;
            string Phone = tbPhone.Text;
            int Age = int.Parse(tbAge.Text);

            player = new PlayerClass()
            {
                Name = Name,
                Lasname = Lasname,
                StudenID = StudenID,
                Majoy = Majoy,
                Display = Display,
                Mail = Mail,
                Phone = Phone,
                Age = Age
            };
            this.DialogResult= DialogResult.OK;


        }
        public  PlayerClass getPlayer()
        {
            return player;
        }

    }
}