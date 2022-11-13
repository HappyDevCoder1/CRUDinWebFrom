using System.Data;
using System.Data.SqlClient;

namespace CRUDinWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //setting sql connection outside the button event so it can be used by other buttons events or methods
        SqlConnection conn = new
         SqlConnection("Data Source=muneebpc\\sqlexpress;Initial Catalog=ProgrammingtutorialDB;Integrated Security=True");


        //Insert Button
        private void button1_Click(object sender, EventArgs e)
        {

            //connection open
            conn.Open();

            //Inert query to insert data in database
            SqlCommand sql_command = new SqlCommand("insert Into ProductInfo_Tab values ('"
                   + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text +
                   "',getdate(),getdate())", conn);

            sql_command.ExecuteNonQuery();

            //show success message after insertion
            MessageBox.Show("Insert Success");

            //connection close
            conn.Close();

            //method to show grid data
            BindData();

        }

        //code to show data in Grid View
        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from ProductInfo_Tab", conn);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Show data whenever the application loads
            BindData();
        }

        //Update Button
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();

            //update query
            SqlCommand command = new
                SqlCommand("update ProductInfo_Tab set ItemName = '" + textBox2.Text + "',Design = '" + textBox3.Text +
                "',Color = '" + comboBox1.Text + "',UpdateDate = '" + DateTime.Parse(dateTimePicker1.Text) + "' where ProductID = '" +
                int.Parse(textBox1.Text) + "'", conn);

            command.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Successfully Updated");

            BindData();

        }

        //Delete Data
        private void button3_Click(object sender, EventArgs e)
        {
            //check if text field is empty or filled
            if (textBox1.Text != "")
            {
                //show message box whenever user is deleting a record
                if (MessageBox.Show("You want to delete?,this can't be undone!", "Delete Record",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();

                    //delete record query
                    SqlCommand command = new SqlCommand("Delete ProductInfo_Tab where ProductID = '" + int.Parse(textBox1.Text) + "'", conn);

                    command.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Successfully Deleted");

                    BindData();
                }

            }
            else
            {
                MessageBox.Show("Put Product ID");
            }

        }

        //Search By ID Button
        private void button4_Click(object sender, EventArgs e)
        {

            string Search_query = "select * from ProductInfo_Tab where ProductID = '" + int.Parse(textBox1.Text) + "'";

            SqlCommand command = new SqlCommand(Search_query, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

        }
    }
}