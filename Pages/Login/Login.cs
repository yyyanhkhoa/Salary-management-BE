
using Salary_management.Infrastructure.Repositories;

namespace Salary_management
{   
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            checkLogin(usernameTextBox.Text, passwordTextBox.Text);            
           
        }

        // Kiem tra login
        private void checkLogin(string username , string password)
        {
			var authRepo = new AuthRepository();
            if (!authRepo.CheckUserExist(username, password))
				MessageBox.Show("Incorrect Information");
            
			else
            {
                Management mng = new Management();
                this.Hide();
                mng.Show();
            }
        }
    }
}