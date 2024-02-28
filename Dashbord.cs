using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Of_Medical
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void addNewMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adding_Medicin adding_Medicin = new Adding_Medicin();   
            adding_Medicin.Show();
        }

        private void editeMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edite_Medicine edite_Medicine = new Edite_Medicine();
            edite_Medicine.Show();
        }

        private void detailsOfMedicinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewM viewM = new viewM();
            viewM.Show();
        }

        private void listOfMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ShowMed showMed = new ShowMed();
            showMed.Show();
        }

        private void addCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comadd comadd = new comadd();
            comadd.Show();
        }

        private void editeCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compEdit compEdit = new compEdit();
            compEdit.Show();
        }

        private void viewDetailsOfComayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewComp viewComp = new ViewComp();
            viewComp.Show();
        }

        private void listOfCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListOFComp listOFComp = new ListOFComp();
            listOFComp.Show();
        }

        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSales addSales = new AddSales();
            addSales.Show();
        }

        private void stockCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStock viewStock = new ViewStock();
            viewStock.Show();
        }

        private void listOfSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListOfSale listOfSale = new ListOfSale();
            listOfSale.Show();
        }

        private void reportOfMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepofAllmedicine repofAllmedicine = new RepofAllmedicine();
            repofAllmedicine.Show();
        }

        private void reportOfCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepofAllComp comp = new RepofAllComp();
            comp.Show();
        }

        private void reportOfSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepofAllStock repofAllStock = new RepofAllStock();
            repofAllStock.Show();
        }

        private void conformToLogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout logout = new Logout();
            logout.Show();
        }

        private void Dashbord_Load(object sender, EventArgs e)
        {

        }
    }
}
