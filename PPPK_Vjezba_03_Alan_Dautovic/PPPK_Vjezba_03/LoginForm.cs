using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_Vjezba_03.Dal
{
    public partial class LoginForm : Form
    {
        private readonly IRepo _repo;
        public LoginForm()
        {
            InitializeComponent();
            _repo = RepoFactory.GetRepository();
        }
  
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _repo.LogIn(TbServer.Text.Trim(), TbUsername.Text.Trim(), TbPassword.Text.Trim());
                new MainForm().Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        
    }
}
