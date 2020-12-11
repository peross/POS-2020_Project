using DbFramework;
using POSApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSApp.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(IsFormValid())
            {
                DbSQLServer db = new DbSQLServer(AppSetting.ConnectionString());

                bool isLoginDetailsCorrect = Convert.ToBoolean(db.GetScalarValue("sp_CheckLoginDetails", GetPrameters()));

                if (isLoginDetailsCorrect)
                {
                    this.Hide();
                    frmDashboard frm = new frmDashboard();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Netačno korisničko ime ili šifra.\nPokušajte opet.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private DbParameter[] GetPrameters()
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter param1 = new DbParameter();
            param1.Parameter = "@Username";
            param1.Value = txtUsername.Text;
            parameters.Add(param1);

            DbParameter param2 = new DbParameter();
            param2.Parameter = "@Password";
            param2.Value = txtPassword.Text;
            parameters.Add(param2);

            return parameters.ToArray();
        }

        private bool IsFormValid()
        {
            if(txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Morate da unesete korisničko ime.", "Greška", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsername.Clear();
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Morate da unesete šifru.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
