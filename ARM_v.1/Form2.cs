using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ARM_v._1
{

     enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form2 : Form
    {

        DataBase dataBase = new DataBase();
        int selectedRow;

        public Form2()
        {
            InitializeComponent();
        }


        private void CreatedColumns()
        {
            dataGridView1.Columns.Add("ID_Klient", "id");
            dataGridView1.Columns.Add("Fio", "ФИО");
            dataGridView1.Columns.Add("Number", "Телефон");
            dataGridView1.Columns.Add("Pass", "Пасспорт");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), RowState.ModifiedNew);
        }


        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from Klient";
            SqlCommand Command = new SqlCommand(queryString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = Command.ExecuteReader();
            while(reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            CreatedColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
