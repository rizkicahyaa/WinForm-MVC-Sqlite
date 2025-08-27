using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_MVC_Sqlite.Model.Context;
using WinForm_MVC_Sqlite.Model.Entity;

namespace WinForm_MVC_Sqlite.Model.Repository
{
    public class MahasiswaRepository
    {
        private SQLiteConnection _conn;

        public MahasiswaRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Mahasiswa mhs)
        {
            int result = 0;
            string sql = @"insert into mahasiswa (nim, nama, jurusan) values (@nim, @nama, @jurusan)";
            
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nim", mhs.Nim);
                cmd.Parameters.AddWithValue("@nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@jurusan", mhs.Jurusan);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(Mahasiswa mhs)
        {
            int result = 0;

            string sql = @"update mahasiswa set nama = @nama, jurusan = @jurusan
                           where nim = @nim";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nim", mhs.Nim);
                cmd.Parameters.AddWithValue("@nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@jurusan", mhs.Jurusan);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Mahasiswa mhs)
        {
            int result = 0;

            string sql = @"delete from mahasiswa
                           where nim = @nim";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nim", mhs.Nim);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        public List<Mahasiswa> ReadAll()
        {
            List<Mahasiswa> list = new List<Mahasiswa>();

            try
            {
                string sql = @"select nim, nama, jurusan
                               from mahasiswa 
                               order by nama";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Mahasiswa mhs = new Mahasiswa();
                            mhs.Nim = dtr["nim"].ToString();
                            mhs.Nama = dtr["nama"].ToString();
                            mhs.Jurusan = dtr["jurusan"].ToString();

                            list.Add(mhs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return list;
        }

        public List<Mahasiswa> ReadByNama(string nama)
        {
            List<Mahasiswa> list = new List<Mahasiswa>();

            try
            {
                string sql = @"select nim, nama, jurusan
                               from mahasiswa 
                               where nama like @nama
                               order by nama";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", "%" + nama + "%");

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Mahasiswa mhs = new Mahasiswa();
                            mhs.Nim = dtr["nim"].ToString();
                            mhs.Nama = dtr["nama"].ToString();
                            mhs.Jurusan = dtr["jurusan"].ToString();

                            list.Add(mhs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }

            return list;
        }
    }
}
