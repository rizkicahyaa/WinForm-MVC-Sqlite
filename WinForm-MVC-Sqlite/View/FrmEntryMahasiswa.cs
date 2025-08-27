using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using WinForm_MVC_Sqlite.Controller;
using WinForm_MVC_Sqlite.Model.Entity;

namespace WinForm_MVC_Sqlite.View
{
    public partial class FrmEntryMahasiswa : Form
    {
        
        public delegate void CreateUpdateEventHandler(Mahasiswa mhs);
        
        public event CreateUpdateEventHandler OnCreate;
        
        public event CreateUpdateEventHandler OnUpdate;
        
        private MahasiswaController controller;
        
        private bool isNewData = true;
        
        private Mahasiswa mhs;

        public FrmEntryMahasiswa()
        {
            InitializeComponent();
        }

        private void FrmEntryMahasiswa_Load(object sender, EventArgs e)
        {

        }
    }
}
