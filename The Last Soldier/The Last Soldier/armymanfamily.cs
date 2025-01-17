﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace The_Last_Soldier
{
    public partial class Armymanfamily : Form
    {
        SqlConnection scon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\OBJECT ORIENTED PROGRAMMING 2\Project\DataBase\ArmyManInfo.mdf;Integrated Security=True;Connect Timeout=30");
        public Armymanfamily()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void armymanf_bttn_2_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void Armymanfamily_Load(object sender, EventArgs e)
        {
            label2.Text = Login.username;
            label3.Text = Login.id;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login rl = new Login();
            MessageBox.Show("Logged Out");
            this.Close();
            rl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                MessageBox.Show("Please Enter Your ID");
            }
            else
            {
                display();
            }
        }
        
        public void display()
        {
            scon.Open();
            SqlCommand cmd = scon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Name, Location, Status, Mission FROM ARMY WHERE ID = '" + textBox1.Text.Trim() + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            scon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }
    }
}
