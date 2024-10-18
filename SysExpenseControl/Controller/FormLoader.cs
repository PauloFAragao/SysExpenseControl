using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysExpenseControl.Controller
{
    internal class FormLoader
    {
        public static Panel PanelBody { get; set; }

        private static Form _activeForm;

        // Método para abrir a form dentro do panel
        public static void OpenChildForm(Form childForm)
        {
            if (_activeForm != null)// verifica se tem alguma form aberta e fecha
            {
                if(_activeForm == childForm)// para não recarregar a form caso ela já esteja aberta
                    return;

                _activeForm.Close();
            }

            _activeForm = childForm;// atualizando a referencia local a form que vai ser aberta

            // abrindo a form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelBody.Controls.Add(childForm);
            PanelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
