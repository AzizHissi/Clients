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
    public partial class Notes : UserControl
    {
        BindingSource bs = new BindingSource();
        BindingSource bs1 = new BindingSource();
        SqlConnection cnx = new SqlConnection(@"Data Source=.;Initial Catalog=Ecole;Integrated Security=True");
        SqlDataAdapter da;
        SqlDataAdapter daNote;
        DataSet ds = new DataSet();
       


        public Notes()
        {
            InitializeComponent();
            

        }

        private void Notes_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("list_Etu", cnx);
            da.Fill(ds, "Etudiants");
            bs.DataSource = ds.Tables["Etudiants"];
            comboBox1.DataSource = bs;
            comboBox1.DisplayMember = "Num_Etu";
            comboBox1.ValueMember = "Num_Etu";
            txt_nom_prenom.DataBindings.Add("Text", bs, "Nom_Complet");
            bs.MoveFirst();
            comboBox1.SelectionChangeCommitted += ComboBox1_SelectionChangeCommitted;       

            daNote = new SqlDataAdapter("select * from notes", cnx);
            daNote.Fill(ds, "Notes");
            ds.Tables.Add(new DataTable("liste_Mod"));
        }

        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            if (ds.Tables["liste_Mod"].Rows.Count != 0) ds.Tables["liste_Mod"].Clear();
            txt_Note.DataBindings.Clear();

            SqlCommand cmd = new SqlCommand("liste_Mod", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Num_Etu", Int32.Parse(comboBox1.SelectedValue.ToString()));

            da = new SqlDataAdapter(cmd);

            da.Fill(ds, "liste_Mod");

            bs1.DataSource = ds.Tables["liste_Mod"];
            comboBox2.DataSource = bs1;
            comboBox2.DisplayMember = "Nom_Mod";
            comboBox2.ValueMember = "Num_Mod";
            txt_Note.DataBindings.Add("Text", bs1, "Note");
            dataGridView1.DataSource = null;

        }

     

       

      

      




        public void VIDER(Control f)
        {

            foreach (Control ct in f.Controls)
            {
                if (ct.GetType() == typeof(TextBox)) ct.Text = "";


               
                
                if (ct.Controls.Count != 0) VIDER(ct);
               
            }
        }
       
        private void btn_new_Click(object sender, EventArgs e)
        {
          
          
                
                if (ds.Tables["liste_Mod"].Rows.Count != 0) ds.Tables["liste_Mod"].Clear();
                txt_Note.DataBindings.Clear();
                da = new SqlDataAdapter("liste_Mod_1", cnx);
                da.Fill(ds, "liste_Mod");
                comboBox2.DataSource = ds.Tables["liste_Mod"];

                VIDER(this);
          
           
           
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
           
           if (txt_Note.Text == "" || comboBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show(" Merci de remplir les champs");
                return;
            }
            DataRow dr = ds.Tables["Notes"].NewRow();
            dr["Num_Etu"] = comboBox1.SelectedValue.ToString();
            dr["Num_Mod"] = comboBox1.SelectedValue;
            dr["Note"] = txt_Note.Text;

            for (int i = 0; i < ds.Tables["Notes"].Rows.Count; i++)
            {
                if (comboBox1.SelectedValue.ToString() == ds.Tables["Notes"].Rows[i][0].ToString() 
                    && comboBox1.SelectedValue.ToString() == ds.Tables["Notes"].Rows[i][1].ToString()
                     && ds.Tables["Notes"].Rows[i][2].ToString()!=null)
                {
                    MessageBox.Show("Note déja saisie");
                    return;
                }
            }
            ds.Tables["Notes"].Rows.Add(dr);
            MessageBox.Show("Enregister  avec succes");
           


        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bs1;
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (txt_Note.Text == "" || comboBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show(" Merci de remplir les champs");
                return;
            }
           

            for (int i = 0; i < ds.Tables["Notes"].Rows.Count; i++)
            {
                if (comboBox1.SelectedValue.ToString() == ds.Tables["Notes"].Rows[i][0].ToString()
                    && comboBox1.SelectedValue.ToString() == ds.Tables["Notes"].Rows[i][1].ToString())
                {
                    ds.Tables["Notes"].Rows[i]["Note"] = txt_Note.Text;
                    MessageBox.Show("Enregister  avec succes");
                    return;
                }
            }
           
            
          

        }

         public void button5_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder SCB = new SqlCommandBuilder(daNote);
            daNote.Update(ds, "Notes");
        }

        private void Notes_Leave(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }
    }
}
