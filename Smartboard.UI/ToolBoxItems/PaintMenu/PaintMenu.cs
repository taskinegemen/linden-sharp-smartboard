using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Smartboard.UI.ToolBoxItems.PaintMenu
{
    public partial class PaintMenu : XtraUserControl
    {
        public Pen Pen;
        public SolidBrush SolidBrush;

        public PaintType PaintType;

        public bool EraseMode = false;

        public ThicknessWrapper Thickness;

        private int oldOpacityValue = 0;

        public PaintMenu()
        {
            InitializeComponent();
            int res = (int)((this.trackBarControlOpacity.Value / 10.0) * 255);
            this.colorEdit1.Color = Color.FromArgb(res, Color.Black);
        }

        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void simpleButtonEraser_Click(object sender, EventArgs e)
        {
            if (this.EraseMode)
            {
                int res = (int)((this.oldOpacityValue / 10.0) * 255);
                this.SolidBrush.Color = Color.FromArgb(res, this.colorEdit1.Color);

                this.EraseMode = false;
            }
            else
            {
                this.SolidBrush.Color = Color.FromArgb(255, Color.White);
                this.oldOpacityValue = this.trackBarControlOpacity.Value;

                this.EraseMode = true;
            }
        }

        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int res = (int)((this.trackBarControlOpacity.Value / 10.0) * 255);

            if (this.Pen != null)
            {
                this.Pen.Color = Color.FromArgb(res, this.colorEdit1.Color);
            }
            if (this.SolidBrush != null)
            {
                this.SolidBrush.Color = Color.FromArgb(res, this.colorEdit1.Color);
            }
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Pen != null)
            {
                this.Pen.Width = this.trackBarControl1.Value;
            }

            if (this.Thickness != null)
            {
                this.Thickness.Thickness = this.trackBarControl1.Value;
            }
        }

        private void trackBarControlOpacity_EditValueChanged(object sender, EventArgs e)
        {
            if (this.SolidBrush != null)
            {
                int res = (int) ((this.trackBarControlOpacity.Value / 10.0) * 255);

                this.SolidBrush.Color =
                    Color.FromArgb(res, this.colorEdit1.Color);
            }
        }
    }

    public enum PaintType
    {
        Brush
        //Pen
    }

    public class ThicknessWrapper
    {
        public int Thickness = 3;
    }
}
