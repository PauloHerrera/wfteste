using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Objects;
using WindowsFormsApplication3.Data;
using WindowsFormsApplication3.Model;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        private GenericRepository<Estado> repository = new GenericRepository<Estado>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var teste = repository.GetAll();
            
            dataGridView1.DataSource = teste.ToList();

            // MessageBox.Show(estadoConsulta.ToTraceString());
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var form2 = new Form2(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                this.Hide();
                form2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(0);
            this.Hide();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var estado = repository.Get(id);

                if (estado != null)
                {
                    repository.Remove(estado);
                }

                dataGridView1.DataSource = repository.GetAll().ToList();

            }
        }
    }
}
