using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopDuplication.Demo
{
    public partial class FormDemo : Form
    {
        private DesktopDuplicator desktopDuplicator;

        public FormDemo()
        {
            InitializeComponent();

            try
            {
                desktopDuplicator = new DesktopDuplicator(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormDemo_Shown(object sender, EventArgs e)
        {
            int qtde = 0;
            while (true)
            {
                qtde++;
                Application.DoEvents();

                DesktopFrame frame = null;
                try
                {
                    frame = desktopDuplicator.GetLatestFrame(qtde);
                }
                catch
                {
                    desktopDuplicator = new DesktopDuplicator(0);
                    continue;
                }

                if (frame != null)
                {
                    LabelCursor.Location = frame.CursorLocation;
                    LabelCursor.Visible = frame.CursorVisible;
                 
                    this.BackgroundImage = frame.DesktopImage;
                }
            }
        }
    }
}
