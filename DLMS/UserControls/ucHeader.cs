using System;
using System.Drawing;
using System.Windows.Forms;

namespace DLMS
{
    public partial class UcHeader : UserControl
    {
        public UcHeader()
        {
            InitializeComponent();
        }

        public string GetText()
        { return lblHeader.Text; }

        public void SetText(string value)
        { lblHeader.Text = value; }

        public Image GetImage()
        { return pbHeader.Image; }

        public void SetImage(Image image)
        { pbHeader.Image = image; }

        public Color GetColor()
        { return lblHeader.ForeColor; }

        public void SetColor(Color color)
        { lblHeader.ForeColor = color; }

        public Color GetBackColor()
        { return lblHeader.BackColor; }

        public void SetBackColor(Color color)
        { this.BackColor = color; }

        private void UcHeader_Load(object sender, EventArgs e)
        {

        }
    }
}
