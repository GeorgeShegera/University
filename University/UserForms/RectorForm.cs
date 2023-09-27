using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityClassLib;

namespace UniversityProject.UserForms
{
    public partial class RectorForm : Form
    {
        private Rector Rector { get; set; }
        public RectorForm(Rector rector)
        {
            Rector = rector;
            InitializeComponent();
        }
    }
}
