using PPPK_Vjezba_03.Dal;
using PPPK_Vjezba_03.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_Vjezba_03
{
    public partial class MainForm : Form
    {
        private readonly IRepo _repo;
        public MainForm()
        {
            InitializeComponent();
            _repo = RepoFactory.GetRepository();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CbDatabases.DataSource = new List<Database>(_repo.GetDatabases());
        }
        private void BtnRunQuery_Click(object sender, EventArgs e)
        {
            try
            {
                RunStatemant();               
            }
            catch (Exception ex)
            {
                TcWindow.SelectedIndex = 1;
                LblMessage.Text = ex.Message;
                LblMessage.ForeColor = Color.Red;
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        => Application.Exit();

        private void BtnDeleteAll_Click(object sender, EventArgs e)
        => TbQueryInput.Clear();     
        
        private void RunStatemant()
        {
            string userInputQuery = TbQueryInput.Text.ToUpper();
            if (userInputQuery.Contains(SQLStatement.SELECT.ToString()))
            {
                DgResults.DataSource = _repo.RunQuery(userInputQuery, (Database)CbDatabases.SelectedItem)
                    .Tables[((Database)CbDatabases.SelectedItem).Name].DefaultView;
                LblMessage.Text = "Execution Succesful";
                LblMessage.ForeColor = Color.Black;
                TcWindow.SelectedIndex = 0;
            }
            else
            {
                int rowAffected = _repo.RunNonQuery(userInputQuery, (Database)CbDatabases.SelectedItem);
                LblMessage.Text = rowAffected != -1 ? $"{rowAffected} rows affected" : "Commands completed successfully.";
                LblMessage.ForeColor = Color.Black;
                TcWindow.SelectedIndex = 1;
            }
        }
    }
}
