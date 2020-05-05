using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TP_2
{
    public partial class Consutlation : UserControl
    {
        BindingSource bs = new BindingSource();
        
        SqlConnection cnx = new SqlConnection(@"Data Source=.;Initial Catalog=Ecole;Integrated Security=True");
        SqlDataAdapter daModule;
        SqlDataAdapter daNote;

        DataSet ds = new DataSet();

        public Consutlation()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Consutlation_Load(object sender, EventArgs e)
        {
            daModule = new SqlDataAdapter("liste_Mod_1", cnx);
            daModule.Fill(ds, "Modules");
            comboBox1.DataSource = ds.Tables["Modules"];
            comboBox1.DisplayMember = "Nom_Mod";
            comboBox1.ValueMember = "Num_Mod";

            ds.Tables.Add(new DataTable("Notes"));
            
            comboBox1.SelectionChangeCommitted += ComboBox1_SelectionChangeCommitted;


        }

        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ds.Tables["Notes"].Rows.Count != 0) ds.Tables["Notes"].Clear();
            

            SqlCommand cmd = new SqlCommand("List_Notes", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Num_Mod", Int32.Parse(comboBox1.SelectedValue.ToString()));

            daNote = new SqlDataAdapter(cmd);
            daNote.Fill(ds, "Notes");
            dataGridView1.DataSource = ds.Tables["Notes"];

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
