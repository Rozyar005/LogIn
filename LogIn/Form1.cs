using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LogIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string a= textBox1.Text;
            string b= textBox2.Text;
            if (a == "admin")
            {
                if (b == "1234")
                {
                   // MessageBox.Show("LogIn Successfull");
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Failed Try Again");
                  

                }
            }*/



            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rozyar\Desktop\LogIn\LogIn\LogIn\haha.mdf;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();

            string Username = textBox1.Text;
            string Password = textBox2.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM tbllog WHERE Username = '" + Username + "' AND Password = '" + Password + "'";
            cmd.CommandType = CommandType.Text;
            // In here do not forget the @ because it is parametre 
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);

            // Executing the SQL Command
            // Adapter for fetching data from the database
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Storing Query Results in a DataTable
            DataTable dt = new DataTable();

            // Fetch and store
            da.Fill(dt);

            // If dt.Rows.Count == 1, it means exactly matching record was found -> Valid user credentials.
            // If dt.Rows.Count == 0, no user was found -> Invalid credentials.
            if (dt.Rows.Count == 1)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }

           /* int result = (int)cmd.ExecuteScalar();

            if (result > 0)
            {
                MessageBox.Show("Authentication successful!");
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();

            }*/
            else
            {
                MessageBox.Show("Invalid username or password.");
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
