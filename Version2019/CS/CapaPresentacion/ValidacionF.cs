using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Fal
using System.Windows.Forms;

namespace CapaPresentacion
{
    class ValidacionF
    {
        public void soloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                //IsNumeric devuelve 'true' para caracteres que no son dígitos
                //Condición que sólo permite ingresar datos numéricos - ver tmb IsDigit 
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                //Condición que permite usar la tecla backspace
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }                
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Sólo se admiten Números", "Validación de Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
            }
        }                
    }
}
