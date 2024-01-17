using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Formula1_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            //textBox4.KeyPress += textBox4_KeyPress;
            //textBox4.TextChanged += textBox4_TextChanged;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cambio la visualizzazione della gridview e della tabcontrol
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabControl1.SelectedIndex = 0;

            //avvio la connessione
            String ConnectionString = "server=127.0.0.1;uid=RaoulBova;pwd=12345;database=formula1";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();

            String sql1 = "select * from piloti;";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1);
            DataTable dati = new DataTable();
            MyAdapter.Fill(dati);

            dataGridView1.DataSource = dati;

            conn.Close();

            //carico i filtri nella combobox1
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            int NumeroIndici = 0;
            foreach (DataGridViewColumn colonna in dataGridView1.Columns)
            {
                string nomeColonna = colonna.HeaderText;
                comboBox1.Items.Add(nomeColonna);
                NumeroIndici++;
            }
            comboBox1.Items.Add("Mostra tutto");
            comboBox1.SelectedIndex = NumeroIndici;

            radioButton3.Checked = true;
            radioButton5.Checked = true;


            ConnectionString = "server=127.0.0.1;uid=RaoulBova;pwd=12345;database=formula1";
            conn = new MySqlConnection(ConnectionString);
            conn.Open();

            sql1 = "select * from team;";
            cmd1 = new MySqlCommand(sql1, conn);

            MyAdapter = new MySqlDataAdapter(cmd1);
            dati = new DataTable();
            MyAdapter.Fill(dati);

            dataGridView2.DataSource = dati;

            conn.Close();

            //carico i filtri nella combobox2
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            NumeroIndici = 0;
            foreach (DataGridViewColumn colonna in dataGridView2.Columns)
            {
                string nomeColonna = colonna.HeaderText;
                comboBox2.Items.Add(nomeColonna);
                NumeroIndici++;
            }
            comboBox2.Items.Add("Mostra tutto");
            comboBox2.SelectedIndex = NumeroIndici;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text_changed1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {   

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            int SchedaSelezionata = tabControl1.SelectedIndex;

            if (SchedaSelezionata == 0)
            {
                //avvio la connessione
                String ConnectionString = "server=127.0.0.1;uid=RaoulBova;pwd=12345;database=formula1";
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                conn.Open();

                String sql1 = "select * from piloti;";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1);
                DataTable dati = new DataTable();
                MyAdapter.Fill(dati);

                dataGridView1.DataSource = dati;

                conn.Close();

                //carico i filtri nella combobox1
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                int NumeroIndici = 0;
                foreach (DataGridViewColumn colonna in dataGridView1.Columns)
                {
                    string nomeColonna = colonna.HeaderText;
                    comboBox1.Items.Add(nomeColonna);
                    NumeroIndici++;
                }
                comboBox1.Items.Add("Mostra tutto");
                comboBox1.SelectedIndex = NumeroIndici;
            }

            if (SchedaSelezionata == 1)
            {
                //avvio la connessione
                String ConnectionString = "server=127.0.0.1;uid=RaoulBova;pwd=12345;database=formula1";
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                conn.Open();

                String sql1 = "select * from team;";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1);
                DataTable dati = new DataTable();
                MyAdapter.Fill(dati);

                dataGridView2.DataSource = dati;

                conn.Close();

                //carico i filtri nella combobox2
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                int NumeroIndici = 0;
                foreach (DataGridViewColumn colonna in dataGridView2.Columns)
                {
                    string nomeColonna = colonna.HeaderText;
                    comboBox2.Items.Add(nomeColonna);
                    NumeroIndici++;
                }
                comboBox2.Items.Add("Mostra tutto");
                comboBox2.SelectedIndex = NumeroIndici;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            text_changed2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text_changed1();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            text_changed2();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //filtro per team
            text_changed1();

        }

        /*
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //filtro per anno
            // Se il testo è più lungo di 4 cifre, non fa nulla
            if (textBox4.Text.Length > 10)
            {
                textBox4.Text = textBox4.Text.Substring(0, 10);
                textBox4.SelectionStart = textBox4.Text.Length; // Imposta il cursore alla fine del testo
            }

            text_changed();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '/')
            {
                e.Handled = true; // Ignora il carattere
            }
        }

        */

        public void text_changed1()
        {
            String ConnectionString = "server=127.0.0.1;uid=RaoulBova;pwd=12345;database=formula1";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();

            int num_sql = 0;

            String sql1= "SELECT * FROM piloti ";

            string nomeColonnaDaMostrare = comboBox1.Text;

            if (nomeColonnaDaMostrare != "Mostra tutto" && nomeColonnaDaMostrare != "")
            {
                sql1 = "SELECT " + nomeColonnaDaMostrare + " FROM piloti ";
            }

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                num_sql++;
                sql1 = "SELECT * FROM piloti WHERE Cognome LIKE '" + textBox1.Text + "%'";
            }

            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                num_sql++;
                if(num_sql > 1)
                {
                    sql1 += "AND Team LIKE '" + textBox3.Text + "%'";
                }
                else
                {
                    sql1 = "SELECT * FROM piloti WHERE Team LIKE '" + textBox3.Text + "%'";
                }
            }

            if (radioButton4.Checked == true)
            {
                sql1 += "ORDER BY Cognome";
            }

            sql1 += ";";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1);
            DataTable dati = new DataTable();
            MyAdapter.Fill(dati);

            dataGridView1.DataSource = dati;

            conn.Close();
        }

        public void text_changed2()
        {
            // Prendo il nome della colonna che voglio far vedere
            string nomeColonnaDaMostrare = comboBox2.Text;

            String ConnectionString = "server=127.0.0.1;uid=RaoulBova;pwd=12345;database=formula1";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();

            String sql1 = "select * from team ";

            if (nomeColonnaDaMostrare != "Mostra tutto" && nomeColonnaDaMostrare!="")
            {
                sql1 = "select " + nomeColonnaDaMostrare + " from team ";
            }

            //MessageBox.Show(nomeColonnaDaMostrare);

            int num_sql = 0;

            if (radioButton1.Checked == true)
            {
                sql1 += "WHERE Attivita=1 ";
                num_sql++;
            }
            
            if(radioButton2.Checked == true)
            {
                sql1 += "WHERE Attivita=0 ";
                num_sql++;
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                if (num_sql > 0)
                {
                    sql1 += "AND Nome LIKE '" + textBox2.Text + "%' ";
                }
                else
                {
                    sql1 += "WHERE Nome LIKE '" + textBox2.Text + "%' ";
                }
            }

            sql1 += ";";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1);
            DataTable dati = new DataTable();
            MyAdapter.Fill(dati);

            dataGridView2.DataSource = dati;

            conn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            text_changed2();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            text_changed2();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            text_changed2();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            text_changed2();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            text_changed2();
        }
    }
}
