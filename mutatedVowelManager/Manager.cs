using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mutatedVowelManager
{
    public partial class Manager : Form
    {
        private SQLHelper SH;
        private mutatedVowelHandler mvh;
        public Manager()
        {
            InitializeComponent();
            //Gets sqlhelper singleinstance
            SH = SQLHelper.Instance;
            mvh = new mutatedVowelHandler();

            fillDGV();
        }


        //Fills the Datagridview with all contacts of the phonebook.
        private void fillDGV()
        {
            DataTable dtContactData = SH.SelectTable("SELECT last_name FROM tbl_phonebook");
            dgvPhonebook.DataSource = dtContactData;
            dgvPhonebook.Columns[0].HeaderText = "Nachname";
        }

        //Fills the Datagridview with all contacts of the given dataTable given as Inputparameter.
        private void fillDGV(DataTable dtInput)
        {
            dgvPhonebook.DataSource = dtInput;
            dgvPhonebook.Columns[0].HeaderText = "Nachname";
        }

        //Clears datagridview
        private void ClearDGV()
        {
            dgvPhonebook.DataSource = new DataTable();
        }

        //Select all names that match a possibiltity
        private void btSearch_Click(object sender, EventArgs e)
        {
            List<string> Possibilities = new List<string>();
            DataTable dtContainer = new DataTable();
            ClearDGV();

            if (tbSearch.Text != null || tbSearch.Text == "")
            {
                Possibilities = mvh.getAllPossibilities(tbSearch.Text);
            }



            fillDGV(SH.SelectTableFromArrayParameter("SELECT last_name FROM tbl_phonebook WHERE last_name IN ({0})", Possibilities));


        }


        //Converts all translations to mulatedvowels in the given text and stores it in textbox
        private void btPossi_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != null || tbSearch.Text == "")
            {
                tbSearch.Text = mvh.ConvertMutatedVowelsToAbbroviation(tbSearch.Text);
            }
        }

        //Displays all different spellings of the given Text in a listbox
        private void btPossibilities_Click(object sender, EventArgs e)
        {
            List<string> Possibilities = new List<string>();
            DataTable dt = new DataTable();

            if (tbSearch.Text != null || tbSearch.Text == "")
            {
                Possibilities = mvh.getAllPossibilities(tbSearch.Text);
            }

            lbPossibilities.DataSource = Possibilities;
        }
        
    }
}
