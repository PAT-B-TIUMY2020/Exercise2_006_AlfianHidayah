using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace Exercise2_006_AlfianHidayah
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TI_UMY : ITI_UMY
    {
        public string CreateMahasiswa(Mahasiswa mhs)
        {
            string msg = "Gagal";
            SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-3M69Q4U;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=Pbun2018");
            string query = String.Format("Insert into dbo.Mahasiswa values ('{0}', '{1}', '{2}', '{3}')", mhs.nama, mhs.nim, mhs.prodi, mhs.angkatan);
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);

            try
            {
                sqlcon.Open();

                Console.WriteLine(query);

                sqlcom.ExecuteNonQuery();

                sqlcon.Close();

                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "Gagal";
            }
            return msg;
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            List<Mahasiswa> mahas = new List<Mahasiswa>();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3M69Q4U;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=Pbun2018");
            string query = "select Nama, NIM, Prodi, Angkatan from dbo.Mahasiswa";

            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nama = reader.GetString(0);
                    mhs.nim = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);

                    mahas.Add(mhs);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mahas;
        }

        public Mahasiswa GetMahasiswaByNIM(string nim)
        {
            Mahasiswa mhs = new Mahasiswa();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3M69Q4U;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=Pbun2018");
            string query = String.Format("Select Nama, NIM, Prodi, Angkatan from dbo.Mahasiswa where NIM = '{0}'", nim);
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    mhs.nama = reader.GetString(0);
                    mhs.nim = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mhs;
        }
        public string UpdateMahasiswaByNIM(Mahasiswa mhs)
        {
            string msg = "Gagal";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3M69Q4U;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=Pbun2018");
            string query = string.Format("Update dbo.Mahasiswa set Nama = '{0}', Prodi = '{1}', Angkatan = '{2}' where NIM = '{3}'", mhs.nama, mhs.prodi, mhs.angkatan, mhs.nim);
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return msg;
        }

        public string DeleteMahasiswa(string nim)
        {
            Mahasiswa mhs = new Mahasiswa();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3M69Q4U;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=Pbun2018");
            string query = string.Format("DELETE from dbo.Mahasiswa where NIM = '{0}'", nim);
            SqlCommand cmd = new SqlCommand(query, con);
            int result = 0;
            string a = "Gagal";

            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                a = ex.ToString();
            }

            if (result != 0)
            {
                a = "Sukses";
            }
            return a;
        }
    }
}
