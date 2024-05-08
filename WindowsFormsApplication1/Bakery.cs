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

namespace WindowsFormsApplication1

   
{
    public partial class Bakery : Form
    {
        DataSet ds = new DataSet();SqlDataAdapter da;
        SqlConnection conn;
        public Bakery()
        {
            InitializeComponent();
        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }
        
        private void label17_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(5);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(3);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(4);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            
            if (produNameTbl.Text == "" || QuantityTbl.Text == "" || priceTbl.Text == "" || catcb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information!!!");
            }
            else
            {
                string strconnection = "data source=DESKTOP-KV08PKK; initial catalog=Bakery; integrated security=true";

                conn = new SqlConnection(strconnection);
                conn.Open();
              
                    try
{
SqlCommand cmd = new SqlCommand("Insert into productTb1 producttbl(productName,productCat,productpric,prodQty) values(@PN,@PC,@PP,@PQ)", conn);
                    cmd.Parameters.AddWithValue("@PN", produNameTbl.Text);
                    cmd.Parameters.AddWithValue("@PC", catcb.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@PP", priceTbl.Text);
                    cmd.Parameters.AddWithValue("@PQ", QuantityTbl.Text);
                    cmd.ExecuteNonQuery();
                    }                    catch(Exception EX) 
                    {

                        MessageBox.Show(EX.Message);
                    }

                    da = new SqlDataAdapter("select * from productTbl", conn);

                SqlCommandBuilder x = new SqlCommandBuilder(da);
                da.Fill(ds,"productTbl");

                productDVG.DataSource = ds.Tables["productTbl"];
            }
            }
        }
        }
    
