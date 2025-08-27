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
    public partial class FrmMahasiswa : Form
    {
        private List<Mahasiswa> listOfMahasiswa = new List<Mahasiswa>();

        private MahasiswaController controller;

        public FrmMahasiswa()
        {
            InitializeComponent();

            controller = new MahasiswaController();

            InisialisasiListView();
            LoadDataMahasiswa();
        }

        private void InisialisasiListView()
        {
            lvwMahasiswa.View = System.Windows.Forms.View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 350, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Jurusan", 150, HorizontalAlignment.Center);
        }

        private void LoadDataMahasiswa()
        {
            lvwMahasiswa.Items.Clear();
            
            listOfMahasiswa = controller.ReadAll();
            
            foreach (var mhs in listOfMahasiswa)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Jurusan);
                lvwMahasiswa.Items.Add(item);
            }
        }

        private void OnCreateEventHandler(Mahasiswa mhs)
        {
            listOfMahasiswa.Add(mhs);
            int noUrut = lvwMahasiswa.Items.Count + 1;
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(mhs.Nim);
            item.SubItems.Add(mhs.Nama);
            item.SubItems.Add(mhs.Jurusan);
            lvwMahasiswa.Items.Add(item);
        }
        
        private void OnUpdateEventHandler(Mahasiswa mhs)
        {
            int index = lvwMahasiswa.SelectedIndices[0];
            ListViewItem itemRow = lvwMahasiswa.Items[index];
            itemRow.SubItems[1].Text = mhs.Nim;
            itemRow.SubItems[2].Text = mhs.Nama;
            itemRow.SubItems[3].Text = mhs.Jurusan;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FrmEntryMahasiswa frmEntry = new FrmEntryMahasiswa("Tambah Data Mahasiswa", controller);
            frmEntry.OnCreate += OnCreateEventHandler;
            frmEntry.ShowDialog();
        }

        private void btnPerbaiki_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                Mahasiswa mhs = listOfMahasiswa[lvwMahasiswa.SelectedIndices[0]];
                FrmEntryMahasiswa frmEntry = new FrmEntryMahasiswa("Edit Data Mahasiswa", mhs, controller);
                
                frmEntry.OnUpdate += OnUpdateEventHandler;
                frmEntry.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus ? ", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    Mahasiswa mhs = listOfMahasiswa[lvwMahasiswa.SelectedIndices[0]];
                    var result = controller.Delete(mhs);
                    if (result > 0) LoadDataMahasiswa();
                }
            }
            else 
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
