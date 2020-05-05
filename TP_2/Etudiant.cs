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
using Microsoft.VisualBasic;

namespace TP_2
{
    public partial class Etudiant : UserControl
    {
        BindingSource bs = new BindingSource();
        BindingSource bs1 = new BindingSource();
        SqlConnection cnx = new SqlConnection(@"Data Source=.;Initial Catalog=Ecole;Integrated Security=True");
        SqlDataAdapter da, daEtudiant;
        DataSet ds = new DataSet();
       public  float sumNnote, Moy;

        //, txt_Nom, txt_Prenom, dt_DateN;

        public Etudiant()
        {
            InitializeComponent();
         

        }

        private void Etudiant_Load(object sender, EventArgs e)
        {
            daEtudiant = new SqlDataAdapter("select * from Etudiant", cnx);
            daEtudiant.Fill(ds, "Etudiants");
            bs.DataSource = ds.Tables["Etudiants"];
            Enable_Binding();
            ds.Tables.Add(new DataTable("liste_Note"));
        }

        private void Enable_Binding()
        {
            txt_Num_Etu.DataBindings.Add("Text", bs, "Num_Etu");
            txt_Nom_Etu.DataBindings.Add("Text", bs, "Nom_Etu");
            txt_Prenom_Etu.DataBindings.Add("Text", bs, "Prenom_Etu");
            dt_DateN_Etu.DataBindings.Add("Value", bs, "DateN_Etu");
            bs.MoveFirst();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disable_Binding();
            if (MessageBox.Show("Voulez vous vider les champs?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VIDER(this);
            }
        }

        public void VIDER(Control f)
        {
           
            foreach (Control ct in f.Controls)
            {
                if (ct.GetType() == typeof(TextBox))
                {
                 
                    ct.Text = "";

                }
               
                if (ct.GetType() == typeof(DateTimePicker))
                {
                    
                    ct.ResetText();
                }
                if (ct.Controls.Count != 0)
                {
                    VIDER(ct);
                }
            }
        }
        public void Disable_Binding()
        {
            txt_Num_Etu.DataBindings.Clear();
            txt_Nom_Etu.DataBindings.Clear();
            txt_Prenom_Etu.DataBindings.Clear();
            dt_DateN_Etu.DataBindings.Clear();


        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            int Num_Etu;
            bool Founded = false;
            if (Int32.TryParse(Interaction.InputBox("Entrer le numero d'etudiant"),out Num_Etu))
            {
                for (int i = 0; i < ds.Tables["Etudiants"].Rows.Count; i++)
                {
                    if (ds.Tables["Etudiants"].Rows[i]["Num_Etu"].ToString() == Num_Etu + "")
                    {
                        bs.Position = i;
                        Founded = true;
                    }

                }
               if (!Founded)
                {

                    MessageBox.Show("Etudiant n'existe pas", "Information");
                }

            }
            else
            {
                MessageBox.Show("Entrer un numero valaid", "Erreur");
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            if (txt_Num_Etu.Text == "" || txt_Num_Etu.Text == "" || txt_Num_Etu.Text == "")
            {
                MessageBox.Show(" Merci de remplir les champs");
                return;
            }
           DataRow dr = ds.Tables["Etudiants"].NewRow();
            dr["Num_Etu"] = txt_Num_Etu.Text;
            dr["Nom_Etu"] = txt_Nom_Etu.Text;
            dr["Prenom_Etu"] = txt_Prenom_Etu.Text;
            dr["DateN_Etu"] = dt_DateN_Etu.Value;
            for (int i = 0; i < ds.Tables["Etudiants"].Rows.Count; i++)
            {
                if (txt_Num_Etu.Text == ds.Tables["Etudiants"].Rows[i][0].ToString())
                {
                    MessageBox.Show("Etudiant existe déja");
                    return;
                }
            }
            ds.Tables["Etudiants"].Rows.Add(dr);
            MessageBox.Show("Etudiant ajouter avec succes");
            bs.DataSource = ds.Tables["Etudiants"];
            Enable_Binding();
           
        }

        private void txt_Num_Etu_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Voulez-vous vraimant modifier","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool Founded = false;
                if (txt_Num_Etu.Text == "" || txt_Nom_Etu.Text == "" || txt_Prenom_Etu.Text == "")
                {
                    MessageBox.Show(" Merci de remplir les champs");
                    return;
                }

                for (int i = 0; i < ds.Tables["Etudiants"].Rows.Count; i++)
                {
                    if (txt_Num_Etu.Text == ds.Tables["Etudiants"].Rows[i][0].ToString())
                    {
                        Founded = true;
                        ds.Tables["Etudiants"].Rows[i]["Nom_Etu"] = txt_Nom_Etu.Text;
                        ds.Tables["Etudiants"].Rows[i]["Prenom_Etu"] = txt_Prenom_Etu.Text;
                        ds.Tables["Etudiants"].Rows[i]["DateN_Etu"] = dt_DateN_Etu.Value;
                    }
                }
                if (Founded)
                {
                    

                    MessageBox.Show("Donnee Modifier avec succes");
                    bs.DataSource = ds.Tables["Etudiants"];

                }

            }
           
            

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraimant supprimer", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ds.Tables["Etudiants"].Rows.RemoveAt(bs.Position);
                MessageBox.Show("Supprimer  avec succes");

            }
        }

        public void btn_exit_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder SCB = new SqlCommandBuilder(daEtudiant);
            daEtudiant.Update(ds, "Etudiants");
        }

        private void Etudiant_Leave(object sender, EventArgs e)
        {
            btn_exit_Click(sender, e);
        }

        private void btn_avg_Click(object sender, EventArgs e)
        {
            
            if (ds.Tables["liste_Note"].Rows.Count != 0) ds.Tables["liste_Note"].Clear();
            SqlCommand cmd = new SqlCommand("Note_M", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Num_Etu", Int32.Parse(txt_Num_Etu.Text));
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "liste_Note");

            sumNnote = 0; Moy = 0;
            if (ds.Tables["liste_Note"].Rows.Count == 0)
            {
                MessageBox.Show("Vérifier que toutes les notes sont déjà saisies.");
                return;
            }
                foreach (DataRow dr in ds.Tables["liste_Note"].Rows)
            {
                if(dr["Note"].ToString() == string.Empty)
                {
                    MessageBox.Show("Vérifier que toutes les notes sont déjà saisies.");
                    return;
                }
                sumNnote += float.Parse(dr["Note"].ToString());
                Moy = sumNnote / ds.Tables["liste_Note"].Rows.Count;
            }
            MessageBox.Show("La moyenne de l'etudiant : "+txt_Nom_Etu.Text + " " + txt_Prenom_Etu.Text + " Est : " + Moy,"Information",MessageBoxButtons.OK);
        }
    }
}
