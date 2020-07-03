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
using System.IO;
using System.Windows.Forms;


namespace WindowsFormsApp8
{

    public partial class Form1 : Form
    {
        int number = 0;
        public Form1()
        {
            InitializeComponent();
            
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.LabelEdit = false;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Gender", 50);
            listView1.Columns.Add("Birthday", 100);
            listView1.Columns.Add("Phone", 100);
            listView1.Columns.Add("Address", 250);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&textBox4.Text != "" &&richTextBox1.Text != "")
                SaveUser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listUsers();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            int.TryParse(listView1.FocusedItem.SubItems[0].Text, out number);
            if (number != 0)
            {
                UpdateUser();
            }
            else
                MessageBox.Show("沒有選取,不能更改");  
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }
        private void listUsers()
        {
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp;";
            string connectionString = "datasource=59.127.254.180;port=3306;username=teacher;password=0000;database=csharp;";
            string query = "SELECT * FROM user";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                listView1.Items.Clear();
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
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
        private void DeleteUser()
        {
            //textBox3.Text = listView1.SelectedItems[0].Text;
            int number = 0;
            int.TryParse(listView1.FocusedItem.SubItems[0].Text, out number);
            if (number != 0)
            {
                //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp;";
                string connectionString = "datasource=59.127.254.180;port=3306;username=teacher;password=0000;database=csharp;";
                string query = "DELETE FROM `user` WHERE id = " + number;

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                    MessageBox.Show("刪除成功!");
                    listUsers();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("沒有選取,不能刪除");
        }
        private void SaveUser()
        {
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp;";
            string connectionString = "datasource=59.127.254.180;port=3306;username=teacher;password=0000;database=csharp;";
            string query = "INSERT INTO user(`id`, `name`, `gender`, `birthday`, `phone`, `address`) VALUES (NULL, '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + richTextBox1.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("成功新增!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                richTextBox1.Text = "";
                listUsers();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateUser()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && richTextBox1.Text != "")
            {
                //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp;";
                string connectionString = "datasource=59.127.254.180;port=3306;username=teacher;password=0000;database=csharp;";
                string query = $"UPDATE `user` SET `name`='{textBox1.Text}',`gender`='{textBox2.Text}',`birthday`='{textBox3.Text}',`phone`='{textBox4.Text}',`address`='{richTextBox1.Text}' WHERE id = " + number;
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    listUsers();
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("有欄位沒有資料,無法更新!");
        }

        private void 聊天程式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            richTextBox1.Visible = false;
            listView1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
        }

        private void 程式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            richTextBox1.Visible = true;
            listView1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = false;
            button6.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false ;
            label10.Visible = false ;
            label11.Visible = false ;
            label12.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = StringEncrypt.aesEncryptBase64(textBox5.Text, textBox6.Text);
                textBox9.Text = textBox6.Text;
                textBox10.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static class StringEncrypt
        {
            public static string aesEncryptBase64(string SourceStr, string CryptoKey)
            {
                string encrypt = "";
                try
                {
                    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                    byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                    byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                    aes.Key = key;
                    aes.IV = iv;

                    byte[] dataByteArray = Encoding.UTF8.GetBytes(SourceStr);
                    using (MemoryStream ms = new MemoryStream())
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(ms.ToArray());
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
                return encrypt;
            }
            public static string aesDecryptBase64(string SourceStr, string CryptoKey)
            {
                string decrypt = "";
                try
                {
                    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                    byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                    byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                    aes.Key = key;
                    aes.IV = iv;

                    byte[] dataByteArray = Convert.FromBase64String(SourceStr);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(dataByteArray, 0, dataByteArray.Length);
                            cs.FlushFinalBlock();
                            decrypt = Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
                return decrypt;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox10.Text = StringEncrypt.aesDecryptBase64(textBox8.Text, textBox9.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

