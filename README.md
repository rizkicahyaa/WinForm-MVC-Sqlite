# 📚 CRUD Mahasiswa - WinForms + SQLite (MVC)

Proyek ini adalah aplikasi desktop sederhana berbasis **C# WinForms** dengan implementasi **CRUD (Create, Read, Update, Delete)** data mahasiswa menggunakan **SQLite** sebagai database.  
Struktur kode menggunakan pola **MVC (Model-View-Controller)** agar lebih terstruktur dan mudah dikembangkan.

---

## ✨ Fitur
- ➕ Tambah data mahasiswa (NIM, Nama, Jurusan)
- ✏️ Edit/Perbaiki data mahasiswa
  - NIM terkunci saat mode Edit (tidak bisa diubah)
- ❌ Hapus data mahasiswa dengan konfirmasi "Iya/Tidak"
- 📋 Tampilkan data mahasiswa ke dalam panel/list
- 💾 Database SQLite lokal (portable, tanpa server)

---

## ⚙️ Cara Menjalankan
1. Clone/download project ini.
   ```
   git clone https://github.com/rizkicahyaa/WinForm-MVC-Sqlite.git
3. Buka menggunakan **Visual Studio**.
4. Install dependency SQLite:
   ```powershell
   Install-Package System.Data.SQLite.Core
