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
using static UniversityProject.Classes.DataManager;

namespace UniversityProject.Forms
{
    public partial class SelectGroupLecturerForm : Form
    {
        public SelectGroupLecturerForm()
        {
            InitializeComponent();            
            List<Faculty> faculties = GetFaculties();
            cbFaculties.DataSource = faculties;
            cbFaculties.DisplayMember = "Name";
            cbFaculties.ValueMember = "Id";
        }
    }
}
