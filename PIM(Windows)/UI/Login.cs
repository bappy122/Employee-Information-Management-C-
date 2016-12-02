using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Windows.Forms;
using PIM_Windows_.DL;
using PIM_Windows_.UI;

namespace PIM_Windows_.IL
{
    public partial class Login : Form
    {
        public Login()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.textBoxPass.PasswordChar = '*';
            this.MaximizeBox = false;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBoxUser.Text.Equals("") && !textBoxPass.Text.Equals(""))
                {
                    SqlConnection con = new SqlConnection(@"server=ASUS\SQLEXPRESS; database=PIM; integrated security=true");
                    con.Open();
                    string query = String.Format("select * from LoginDetails where employeeID='{0}' AND password='{1}'", this.textBoxUser.Text, this.textBoxPass.Text);
                    SqlCommand cmd = new SqlCommand(query,con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    int count = 0;
                    while (dr.Read())
                    {
                        count++;
                    }

                    if (count == 1)
                    {
                        //MessageBox.Show("Employee ID and Password Matched....!");
                        string accountType;
                        string query2 = String.Format("select * from LoginDetails where employeeID='{0}'",textBoxUser.Text);
                        DataSet ds = DataAccess.GetDataSet(query2);
                        accountType = ds.Tables[0].Rows[0]["accountType"].ToString();
                        MyProfileOptions.userID = ds.Tables[0].Rows[0]["employeeID"].ToString();
                        if (accountType.Equals("admin"))
                        {
                            Home h = new Home();
                            h.Show();
                            this.Hide();
                        }
                        else if (accountType.Equals("user"))
                        {
                            MyProfile ob = new MyProfile();
                            ob.Show();
                            this.Hide();
                        }
                        else
                        {
                            SysAdmin ob = new SysAdmin();
                            ob.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Employee ID and Password Did not Matched....!");

                    }

                }
                else
                {
                    MessageBox.Show("You must Enter Username and Password...!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

/*
            if (textBoxUser.Text.Equals("admin") && textBoxPass.Text.Equals("admin"))
            {
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            else if (textBoxUser.Text.Equals("user") && textBoxPass.Text.Equals("user"))
            {
                MyProfile ob = new MyProfile();
                ob.Show();
                this.Hide();
            }
            else if (textBoxUser.Text.Equals("1") && textBoxPass.Text.Equals("1"))
            {
                SysAdmin ob = new SysAdmin();
                ob.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(@"Username & Password Did not match! ", @"Error");
            }*/
        }

        private void textBoxPass_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void enterKey(object sender, KeyEventArgs e)
        {
            EventArgs ee = new EventArgs();
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, ee);
            }
            
        }
    }
}
