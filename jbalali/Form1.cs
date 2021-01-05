using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jbalali
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var data = this.GetAllCategoryData();
            Console.Write(data);
            this.textBox1.Text = data.ToString();
            this.dataGridView1.DataSource = data;

        }

        public List<user_model> GetAllCategoryData()
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {

                if (db.State == ConnectionState.Closed)

                    db.Open();
                return db.Query<user_model>("SELECT * FROM users").ToList();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
