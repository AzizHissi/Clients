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

namespace TP_2
{
    public partial class Form1 : Form
    {
        static SqlConnection cnx = new SqlConnection(@"Data Source=.;Initial Catalog=Ecole;Integrated Security=True");

        public static DataSet ds = new DataSet("Ecole");
        public static SqlDataAdapter daEtudiant;
        public static SqlDataAdapter daModule;
        public static SqlDataAdapter daNotes;
        public Form1()
        {
            InitializeComponent();
            etudiant1.BringToFront();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Etudiant
            daEtudiant = new SqlDataAdapter("select * from Etudiant", cnx);
            daEtudiant.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daEtudiant.Fill(ds, "Etudiant");

            ds.Tables["Etudiant"].Columns["Num_Etu"].DataType = Type.GetType("System.Int32");
            ds.Tables["Etudiant"].Columns["Num_Etu"].AllowDBNull = false;

            ds.Tables["Etudiant"].Columns["Nom_Etu"].DataType = Type.GetType("System.String");
            ds.Tables["Etudiant"].Columns["Nom_Etu"].MaxLength = 50;

            ds.Tables["Etudiant"].Columns["Prenom_Etu"].DataType = Type.GetType("System.String");
            ds.Tables["Etudiant"].Columns["Prenom_Etu"].MaxLength = 50;

            ds.Tables["Etudiant"].Columns["DateN_Etu"].DataType = Type.GetType("System.DateTime");

            ds.Tables["Etudiant"].PrimaryKey = new DataColumn[] { ds.Tables["Etudiant"].Columns["Num_Etu"] };

            //Module
            daModule = new SqlDataAdapter("select * from Module", cnx);
            daModule.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daModule.Fill(ds, "Module");
            ds.Tables["Module"].PrimaryKey = new DataColumn[] { ds.Tables["Module"].Columns["Num_Mod"] };


            ds.Tables["Module"].Columns["Num_Mod"].DataType = Type.GetType("System.Int32");
            ds.Tables["Module"].Columns["Num_Mod"].AllowDBNull = false;

            ds.Tables["Module"].Columns["Nom_Mod"].DataType = Type.GetType("System.String");
            ds.Tables["Module"].Columns["Nom_Mod"].MaxLength = 50;
            ds.Tables["Module"].Columns["Nom_Mod"].AllowDBNull = false;

            //Note
            daNotes = new SqlDataAdapter("select * from Notes", cnx);
            daNotes.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daNotes.Fill(ds, "Notes");

            ds.Tables["Notes"].Columns["Num_Etu"].DataType = Type.GetType("System.Int32");
            ds.Tables["Notes"].Columns["Num_Etu"].AllowDBNull = false;
            //ds.Tables["Notes"].Columns["Num_Etu"].Unique = true;

            ds.Tables["Notes"].Columns["Num_Mod"].DataType = Type.GetType("System.Int32");
            ds.Tables["Notes"].Columns["Num_Mod"].AllowDBNull = false;
            //ds.Tables["Notes"].Columns["Num_Mod"].Unique = true;

            ds.Tables["Notes"].Columns["Note"].DataType = Type.GetType("System.Double");

            //ds.Tables["Notes"].PrimaryKey = new DataColumn[] { ds.Tables["Notes"].Columns["Num_Etu"] };
            //ds.Tables["Notes"].PrimaryKey = new DataColumn[] { ds.Tables["Notes"].Columns["Num_Mod"] };
            ForeignKeyConstraint FKE = new ForeignKeyConstraint("FK_Etudiant_Notes",
                                     ds.Tables["Etudiant"].Columns["Num_Etu"], ds.Tables["Notes"].Columns["Num_Etu"]);
            ForeignKeyConstraint FKM = new ForeignKeyConstraint("FK_Module_Notes",
                                    ds.Tables["Module"].Columns["Num_Mod"], ds.Tables["Notes"].Columns["Num_Mod"]);
            FKM.UpdateRule = FKE.UpdateRule = Rule.Cascade;
            FKM.DeleteRule = FKE.DeleteRule = Rule.Cascade;
            ds.Tables["Notes"].Constraints.AddRange(new Constraint[] { FKE, FKM });
           

        }

      

        private void gestionDesÉtudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etudiant1.BringToFront();
        }

        private void gestionDesNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notes1.BringToFront();
        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consutlation1.BringToFront();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
           
            etudiant1.btn_exit_Click(sender , e);
            notes1.button5_Click(sender, e);
         
        }

        private void quiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraimant Quiter", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
