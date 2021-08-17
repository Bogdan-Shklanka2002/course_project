using DAL_ComputerRepair;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectorApp
{
    public partial class Login : Form
    {
        GenericUnitOfWork work;
        IGenericRepository<Employee> repository;
        int pos;
        public Login(GenericUnitOfWork work_, int position )
        {
            InitializeComponent();
            //work = work_;
            repository = work_.Repository<Employee>();
            pos = position;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(textBox1.Text) && 
               !string.IsNullOrEmpty(textBox2.Text))
            {
                var isEmployee = repository.GetAll()
                    .Where(x => x.Login == textBox1.Text && 
                        x.Password == textBox2.Text && 
                        x.IdPosition == pos)
                    .FirstOrDefault();
                if (isEmployee != null)
                {
                    MessageBox.Show("Welcome!");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Access denied!");
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
