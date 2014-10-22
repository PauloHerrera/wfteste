using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication3.Data;
using WindowsFormsApplication3.Model;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        private GenericRepository<Estado> repository = new GenericRepository<Estado>();
        private int estadoId;
        private Estado estado;
        public Form2(int id)
        {
            estadoId = id;
            estado = new Estado();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            estado.Nome = textBox1.Text;
            estado.Sigla = textBox2.Text;

            repository.AddOrUpdate(estado);
            
            var form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (estadoId != 0)
            {
                estado = repository.Get(estadoId);

                if (estado != null)
                {
                    textBox1.Text = estado.Nome.TrimEnd();
                    textBox2.Text = estado.Sigla.TrimEnd();    
                }
            }
        
        }
    }
}
