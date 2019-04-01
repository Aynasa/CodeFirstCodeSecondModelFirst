using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Model1 dbContext = new Model1();

            Vklad Vklad = new Vklad();

            Vklad.Balance = 123;
            dbContext.Vklad.Add(Vklad);
            dbContext.SaveChanges();

            MessageBox.Show("Новый клиент добавлен");
            
        }
    }
}
