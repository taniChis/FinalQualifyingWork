using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ДП
{
    
    public partial class Loading : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(
           int nLeftRect,
           int nTopRect,
           int RightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
           );
        public Loading()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,25,25));
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            circularProgressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (circularProgressBar1.Value < circularProgressBar1.Maximum)
            {
                circularProgressBar1.Value += 1;
            }

            if (circularProgressBar1.Value == circularProgressBar1.Maximum)
            {
                circularProgressBar1.Enabled = false;
                this.Close();
            }
        }
    }
}
