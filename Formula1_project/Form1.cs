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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Formula1_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Prendo il nome della colonna che voglio far vedere
            string nomeColonnaDaMostrare = comboBox1.Text;

            if(nomeColonnaDaMostrare!= "Mostra tutto")
            {
                // Nascondi tutte le colonne
                foreach (DataGridViewColumn colonna in dataGridView1.Columns)
                {
                    colonna.Visible = false;
                }

                // Trova la colonna con il nome desiderato e la mostra
                foreach (DataGridViewColumn colonna in dataGridView1.Columns)
                {
                    if (colonna.HeaderText == nomeColonnaDaMostrare)
                    {
                        colonna.Visible = true;
                        break;  // Esco dopo aver trovato la colonna desiderata
                    }
                }
            }
            else
            {
                foreach (DataGridViewColumn colonna in dataGridView1.Columns)
                {
                    colonna.Visible = true;
                }
            }
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
            // Prendo il nome della colonna che voglio far vedere
            string nomeColonnaDaMostrare = comboBox2.Text;

            if (nomeColonnaDaMostrare != "Mostra tutto")
            {
                // Nascondi tutte le colonne
                foreach (DataGridViewColumn colonna in dataGridView2.Columns)
                {
                    colonna.Visible = false;
                }

                // Trova la colonna con il nome desiderato e la mostra
                foreach (DataGridViewColumn colonna in dataGridView2.Columns)
                {
                    if (colonna.HeaderText == nomeColonnaDaMostrare)
                    {
                        colonna.Visible = true;
                        break;  // Esco dopo aver trovato la colonna desiderata
                    }
                }
            }
            else
            {
                foreach (DataGridViewColumn colonna in dataGridView2.Columns)
                {
                    colonna.Visible = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=RaoulBova;pwd=12345;database=formula1";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();

            String sql1 = "SELECT * FROM piloti WHERE Cognome LIKE '" + textBox1.Text + "%';";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1);
            DataTable dati = new DataTable();
            MyAdapter.Fill(dati);

            dataGridView1.DataSource = dati;

            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=RaoulBova;pwd=12345;database=formula1";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();

            String sql1 = "SELECT * FROM piloti ORDER BY Cognome;";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1);
            DataTable dati = new DataTable();
            MyAdapter.Fill(dati);

            dataGridView1.DataSource = dati;

            conn.Close();
        }
    }
}
