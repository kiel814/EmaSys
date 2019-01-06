using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//agrego para poder usar las bases de datos de SQL
using System.Data.SqlClient;
//agrego OleDb para que lea el xls
using System.Data.OleDb;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class FrmProveFox : Form
    {
        //inicializo el índice
        private int n = 0;

        public FrmProveFox()
        {
            InitializeComponent();
        }

        //SqlConnection conexionF = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\EMASA\EmaSys\EmaSysDB.mdf; Integrated Security = True");
        SqlConnection conexionF = new SqlConnection(@"Data Source=DESKTOP-AKJEOB7\SQLEXPRESS; Initial Catalog=EmaSysDB; Integrated Security=true");

        private void FrmProveFox_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.lblTotal.Text = "0";
        }

        private void btnMigrarProve_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo Cadena de conexión e indico la ruta de la DBF
                string cadena = "Provider =Microsoft.Jet.OLEDB.4.0; Data Source=C:\\EMASA; Extended Properties = dBase IV; User ID=;Password=;";
                //Creo un objeto de conexión OleDB
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = cadena;
                //abro la conexión
                con.Open();

                //ahora excribo la consulta SQL
                //Prove es el nombre de la bd de Fox
                string consulta = "Select * from Provee";
                //Creo una instancia tipo Adapter que es la que nos traerá devuelta los datos
                OleDbDataAdapter adapter = new OleDbDataAdapter(consulta, con);
                //Creo un DataSet para capturar los datos devueltos
                DataSet ds = new DataSet();
                //Lleno el DataSet con la información que trajo el DataAdapter
                adapter.Fill(ds);
                //cierro la conexión
                con.Close();

                //Indico al dataGridView que tome la información del DataSet
                this.dtgvMigrarProv.DataSource = ds.Tables[0];
                //Cuento Cantidad de Registros migrados de Fox
                lblTotal.Text = Convert.ToString(dtgvMigrarProv.Rows.Count);

            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Error: exp" + exp.Message);
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            SqlCommand agregar = new SqlCommand("INSERT INTO Proveedores VALUES(@ProCodigo, @ProNombr, @ProNomch, @ProDirec, @ProTelef," +
                "                               @ProFax, @ProLocal, @ProProvi, @ProCPost, @ProCIva, @ProCuit, @ProRamo, @ProServi," +
                "                               @ProIngbr, @ProGanan, @ProNIngb, @ProActiv, @ProAgper, @ProGrupo, @ProFeins, @ProAciva," +
                "                               @ProCai, @ProFecai, @ProAduan, @ProCBanc, @ProDespa, @ProOk)", conexionF);
            conexionF.Open();

            try
            {
                for (int i = 0; i < dtgvMigrarProv.Rows.Count; i++)
                {
                    //para q en cada ciclo agregar esté en blanco
                    agregar.Parameters.Clear();

                    //agregar.Parameters.AddWithValue("@ProveedorID", dtgvMigrarProv.Rows[i].Cells[0].Value);
                    agregar.Parameters.AddWithValue("@ProCodigo", dtgvMigrarProv.Rows[i].Cells[0].Value);
                    agregar.Parameters.AddWithValue("@ProNombr", dtgvMigrarProv.Rows[i].Cells[1].Value);
                    agregar.Parameters.AddWithValue("@ProNomch", dtgvMigrarProv.Rows[i].Cells[2].Value);
                    agregar.Parameters.AddWithValue("@ProDirec", dtgvMigrarProv.Rows[i].Cells[3].Value);
                    agregar.Parameters.AddWithValue("@ProTelef", dtgvMigrarProv.Rows[i].Cells[4].Value);
                    agregar.Parameters.AddWithValue("@ProFax", dtgvMigrarProv.Rows[i].Cells[5].Value);
                    agregar.Parameters.AddWithValue("@ProLocal", dtgvMigrarProv.Rows[i].Cells[6].Value);
                    agregar.Parameters.AddWithValue("@ProProvi", dtgvMigrarProv.Rows[i].Cells[7].Value);
                    agregar.Parameters.AddWithValue("@ProCPost", dtgvMigrarProv.Rows[i].Cells[8].Value);
                    agregar.Parameters.AddWithValue("@ProCIva", dtgvMigrarProv.Rows[i].Cells[9].Value);
                    agregar.Parameters.AddWithValue("@ProCuit", dtgvMigrarProv.Rows[i].Cells[10].Value);
                    agregar.Parameters.AddWithValue("@ProRamo", dtgvMigrarProv.Rows[i].Cells[11].Value);
                    agregar.Parameters.AddWithValue("@ProServi", dtgvMigrarProv.Rows[i].Cells[12].Value);
                    agregar.Parameters.AddWithValue("@ProIngbr", dtgvMigrarProv.Rows[i].Cells[13].Value);
                    agregar.Parameters.AddWithValue("@ProGanan", dtgvMigrarProv.Rows[i].Cells[14].Value);
                    agregar.Parameters.AddWithValue("@ProNIngb", dtgvMigrarProv.Rows[i].Cells[15].Value);
                    agregar.Parameters.AddWithValue("@ProActiv", dtgvMigrarProv.Rows[i].Cells[16].Value);
                    agregar.Parameters.AddWithValue("@ProAgper", dtgvMigrarProv.Rows[i].Cells[17].Value);
                    agregar.Parameters.AddWithValue("@ProGrupo", dtgvMigrarProv.Rows[i].Cells[18].Value);
                    agregar.Parameters.AddWithValue("@ProFeins", dtgvMigrarProv.Rows[i].Cells[19].Value);
                    agregar.Parameters.AddWithValue("@ProAciva", dtgvMigrarProv.Rows[i].Cells[20].Value);
                    agregar.Parameters.AddWithValue("@ProCai", dtgvMigrarProv.Rows[i].Cells[21].Value);
                    agregar.Parameters.AddWithValue("@ProFecai", dtgvMigrarProv.Rows[i].Cells[22].Value);
                    agregar.Parameters.AddWithValue("@ProAduan", dtgvMigrarProv.Rows[i].Cells[23].Value);
                    agregar.Parameters.AddWithValue("@ProCBanc", dtgvMigrarProv.Rows[i].Cells[24].Value);
                    agregar.Parameters.AddWithValue("@ProDespa", dtgvMigrarProv.Rows[i].Cells[25].Value);
                    agregar.Parameters.AddWithValue("@ProOk", dtgvMigrarProv.Rows[i].Cells[26].Value);

                    agregar.ExecuteNonQuery();
                }
                MessageBox.Show("Datos Agregados");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos no agregados");
            }
            finally
            {
                conexionF.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
