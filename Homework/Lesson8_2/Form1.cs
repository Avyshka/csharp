using System.Windows.Forms;

namespace Lesson8_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtText.DataBindings.Add("Text", nudSelector, "Value");
        }
    }
}
