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

        public FrmEntryMahasiswa(string title, MahasiswaController controller) : this()
        {
            this.Text = title;
            this.controller = controller;
        }

        public FrmEntryMahasiswa(string title, Mahasiswa obj, MahasiswaController controller) : this()
        {
            this.Text = title;
            this.controller = controller;
            isNewData = false; 
            mhs = obj; 
            txtNim.Text = mhs.Nim;
            txtNama.Text = mhs.Nama;
            txtJurusan.Text = mhs.Jurusan;
        }

        private void FrmEntryMahasiswa_Load(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) mhs = new Mahasiswa();
            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Jurusan = txtJurusan.Text;
            int result = 0;

            if (isNewData) 
            {
                result = controller.Create(mhs);
                if (result > 0) 
                {
                    OnCreate(mhs);
                    txtNim.Clear();
                    txtNama.Clear();
                    txtJurusan.Clear();
                    txtNim.Focus();
                }
            }
            else
            {
                result = controller.Update(mhs);

                if (result > 0)
                {
                    OnUpdate(mhs);
                    this.Close();
                }
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
