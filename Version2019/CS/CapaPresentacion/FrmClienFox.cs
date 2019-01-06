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
    public partial class FrmClienFox : Form
    {
        //inicializo el índice
        private int n = 0;
        public FrmClienFox()
        {
            InitializeComponent();
        }

        //SqlConnection conexionF = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\EMASA\EmaSys\EmaSysDB.mdf; Integrated Security = True");
        SqlConnection conexionF = new SqlConnection(@"Data Source=DESKTOP-AKJEOB7\SQLEXPRESS; Initial Catalog=EmaSysDB; Integrated Security=true");
        private void FrmClienFox_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'emaSysDBDataSet.Clientes' Puede moverla o quitarla según sea necesario.
            //this.clientesTableAdapter.Fill(this.emaSysDBDataSet.Clientes);
            this.Top = 0;
            this.Left = 0;
            this.lblTotal.Text = "0";
        }

        private void btnMigrarClien_Click(object sender, EventArgs e)
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
                //Client es el nombre de la bd de Fox
                string consulta = "Select * from Client";
                //Creo una instancia tipo Adapter que es la que nos traerá devuelta los datos
                OleDbDataAdapter adapter = new OleDbDataAdapter(consulta, con);
                //Creo un DataSet para capturar los datos devueltos
                DataSet ds = new DataSet();
                //Lleno el DataSet con la información que trajo el DataAdapter
                adapter.Fill(ds);
                //cierro la conexión
                con.Close();

                //Indico al dataGridView que tome la información del DataSet
                this.dtgvMigrarClien.DataSource = ds.Tables[0];
                //Cuento Cantidad de Registros migrados de Fox
                lblTotal.Text = Convert.ToString(dtgvMigrarClien.Rows.Count);

            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Error: exp" + exp.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            SqlCommand agregar = new SqlCommand("INSERT INTO Clientes VALUES(@CliCodigo, @CliNombr, @CliDirec, @CliTelef, @CliFax, @CliLocal, @CliProvi, @CliCPost, @CliCIva, @CliAgper, @CliCuit, @CliIngbr, @CliProve, @CliPcobr, @CliCocom, @CliTecom, @CliCotec, @CliTetec, @CliCoadm, @CliTeadm, @CliOk)", conexionF);
            conexionF.Open();

            try
            {
                for (int i = 0; i < dtgvMigrarClien.Rows.Count; i++)
                {
                    //para q en cada ciclo agregar esté en blanco
                    agregar.Parameters.Clear();

                    //agregar.Parameters.AddWithValue("@ClienteID", dtgvMigrarClien.Rows[i].Cells[0].Value);
                    agregar.Parameters.AddWithValue("@CliCodigo", dtgvMigrarClien.Rows[i].Cells[0].Value);
                    agregar.Parameters.AddWithValue("@CliNombr", dtgvMigrarClien.Rows[i].Cells[1].Value);
                    agregar.Parameters.AddWithValue("@CliDirec", dtgvMigrarClien.Rows[i].Cells[2].Value);
                    agregar.Parameters.AddWithValue("@CliTelef", dtgvMigrarClien.Rows[i].Cells[3].Value);
                    agregar.Parameters.AddWithValue("@CliFax", dtgvMigrarClien.Rows[i].Cells[4].Value);
                    agregar.Parameters.AddWithValue("@CliLocal", dtgvMigrarClien.Rows[i].Cells[5].Value);
                    agregar.Parameters.AddWithValue("@CliProvi", dtgvMigrarClien.Rows[i].Cells[6].Value);
                    agregar.Parameters.AddWithValue("@CliCPost", dtgvMigrarClien.Rows[i].Cells[7].Value);
                    agregar.Parameters.AddWithValue("@CliCIva", dtgvMigrarClien.Rows[i].Cells[8].Value);
                    agregar.Parameters.AddWithValue("@CliAgper", dtgvMigrarClien.Rows[i].Cells[9].Value);
                    agregar.Parameters.AddWithValue("@CliCuit", dtgvMigrarClien.Rows[i].Cells[10].Value);
                    agregar.Parameters.AddWithValue("@CliIngbr", dtgvMigrarClien.Rows[i].Cells[11].Value);
                    agregar.Parameters.AddWithValue("@CliProve", dtgvMigrarClien.Rows[i].Cells[12].Value);
                    agregar.Parameters.AddWithValue("@CliPcobr", dtgvMigrarClien.Rows[i].Cells[13].Value);
                    agregar.Parameters.AddWithValue("@CliCocom", dtgvMigrarClien.Rows[i].Cells[14].Value);
                    agregar.Parameters.AddWithValue("@CliTecom", dtgvMigrarClien.Rows[i].Cells[15].Value);
                    agregar.Parameters.AddWithValue("@CliCotec", dtgvMigrarClien.Rows[i].Cells[16].Value);
                    agregar.Parameters.AddWithValue("@CliTetec", dtgvMigrarClien.Rows[i].Cells[17].Value);
                    agregar.Parameters.AddWithValue("@CliCoadm", dtgvMigrarClien.Rows[i].Cells[18].Value);
                    agregar.Parameters.AddWithValue("@CliTeadm", dtgvMigrarClien.Rows[i].Cells[19].Value);
                    agregar.Parameters.AddWithValue("@CliOk", dtgvMigrarClien.Rows[i].Cells[20].Value);

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
    }
}
