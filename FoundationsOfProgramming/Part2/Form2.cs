using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part2
{
    public partial class Form2 : Form
    {
        internal Action<int> FindByChance;

        public Form2() {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            var userNumber = Convert.ToInt32(UserNumber.Text);
            FindByChance.Invoke(userNumber);
        }
    }
}
