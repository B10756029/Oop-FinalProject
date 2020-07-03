using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        bool login = false;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Form3 f3 = new Form3();
            f2.Close();
            this.Visible = false;
            f3.Visible = true;
            //this.Hide();
            //f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listUsers();
            if (login)
            {
                Form1 f1 = new Form1();
                Form2 f2 = new Form2();
                f2.Close();
                this.Visible = false;
                f1.Visible = true;
            }
        }
        private void listUsers()
        {
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp;";
            string connectionString = "datasource=59.127.254.180;port=3306;username=teacher;password=0000;database=csharp;";
            string query = "SELECT * FROM account";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(1) == textBox1.Text)
                        {
                            if (reader.GetString(2) == HMACSHA256(textBox2.Text, "AOIJQWOJEOPQWJOPFOMQWORMIOQWJ"))
                            {
                                login = true;
                                databaseConnection.Close();
                                break;
                            }
                            else
                            {
                                databaseConnection.Close();
                                break;
                            }
                        }                  
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string HMACSHA256(string message, string key)
        {
            var encoding = new UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacSHA256 = new HMACSHA256(keyByte))
            {
                byte[] hashMessage = hmacSHA256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
            }
        }
    }
}
