using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuisnessLay;

namespace PresentationLayer
{
    public partial class FrmServiceDepartment : Form
    {
        DataHandler dh = new DataHandler();
        public FrmServiceDepartment()
        {
            InitializeComponent();
            setContext();
            setData();
        }

        public void setData()
        {
            Dictionary<string, string> details = this.dh.getEmployeeDetails(lstTechnicians.SelectedItem);
            if (details.Count > 0)
            {
                txtSkill.Text = details["skill"];
                txtClassfication.Text = details["classification"];
                txtEmployeeName.Text = details["firstName"];
            }
           
        }

        public void setContext()
        {
            BindingSource bsSource = new BindingSource();
            bsSource.DataSource = dh.getEmployees();
            lstTechnicians.DataSource = bsSource;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmWelcomeScreen welcomeScreen = new FrmWelcomeScreen();
            this.Hide();
            welcomeScreen.ShowDialog();
            this.Close();
        }

        private void lstTechnicians_SelectedIndexChanged(object sender, EventArgs e)
        {
            setData();
        }

        private void btnLockInTechnicians_Click(object sender, EventArgs e)
        {
            lstTechnicians.Enabled = !lstTechnicians.Enabled;
            txtEmployeeName.Enabled = !txtEmployeeName.Enabled;
            txtSkill.Enabled = !txtSkill.Enabled;
            txtClassfication.Enabled = !txtClassfication.Enabled;
        }

        private void btnLockInEquipment_Click(object sender, EventArgs e)
        {
            txtEquipment.Enabled = !txtEquipment.Enabled;
        }
    }
}
