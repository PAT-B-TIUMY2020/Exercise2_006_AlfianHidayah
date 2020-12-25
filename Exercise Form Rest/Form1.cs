using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_Form_Rest
{
    public partial class Form1 : Form
    {
        ClassData data = new ClassData();
        public Form1()
        {
            InitializeComponent();
        }
        public void TampilData()
        {
            var List = data.getAllData();
            dtmhs.DataSource = List;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtmhs.DataSource = data.getAllData();
            TampilData();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            textBox2.Enabled = true;

            btnCreate.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void dtmhs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dtmhs.Rows[e.RowIndex].Cells[1].Value);
            textBox2.Text = Convert.ToString(dtmhs.Rows[e.RowIndex].Cells[0].Value);
            textBox3.Text = Convert.ToString(dtmhs.Rows[e.RowIndex].Cells[2].Value);
            textBox4.Text = Convert.ToString(dtmhs.Rows[e.RowIndex].Cells[3].Value);

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnCreate.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string nim = textBox2.Text;
                List<Mahasiswa> mhs = new List<Mahasiswa>();
                mhs.Add(data.search(nim));
                Clear();
                dtmhs.DataSource = mhs;
            }
            else
            {
                dtmhs.DataSource = data.getAllData();
            }
        }

        private void btnJumlah_Click(object sender, EventArgs e)
        {
            var jmlh = data.Jumlahdata();
            label6.Text = jmlh;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.nama = textBox1.Text;
            mhs.nim = textBox2.Text;
            mhs.prodi = textBox3.Text;
            mhs.angkatan = textBox4.Text;

            ClassData classData = new ClassData();
            classData.updateDatabase(mhs);
            Clear();
            dtmhs.DataSource = classData.getAllData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClassData classData = new ClassData();
            classData.deleteMahasiswa(textBox2.Text);
            Clear();
            dtmhs.DataSource = classData.getAllData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text;
            string nim = textBox2.Text;
            string prodi = textBox3.Text;
            string angkatan = textBox4.Text;
            data.insertMahasiswa(nim, nama, prodi, angkatan);
            Clear();
            dtmhs.DataSource = data.getAllData();
        }
    }
}
