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
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using lab3.Ef;

namespace lab3
{
    public partial class Form1 : Form
    {
        VkladDb dbContext;
        //List<Record> allRecords;
        BindingList<Vklad> allVklads;
        public Form1()
        {
            InitializeComponent();

            dbContext = new VkladDb();
            loadData();
        }

        private void loadData()
        {

            loadClients();

            //loadClients();

            //ExecuteSP();
        }

        private void loadClients()
        {
            dbContext.Vklads.Load();
            allVklads = dbContext.Vklads.Local.ToBindingList();

            // Отображаем данные
            gvClientsList.DataSource = allVklads;

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddVkladForm f = new AddVkladForm();
            DialogResult result = f.ShowDialog(this);

            if (result == DialogResult.OK)
                return;
            

            Vklad vklad = new Vklad();

            vklad.DateOpen = f.dateTimePicker1.Value;
            vklad.Balance = int.Parse(f.textBox1.Text);
  
            dbContext.Vklads.Add(vklad);
            dbContext.SaveChanges();

            MessageBox.Show("Новый клиент добавлен");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool res = Validate();
            if (res)
            {
                dbContext.SaveChanges();
                this.gvClientsList.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = getSelectedRow(gvClientsList);
            if (index != -1)
            {
                int id = 0;
                bool converted = Int32.TryParse(gvClientsList[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Vklad cl = dbContext.Vklads.Find(id);
                dbContext.Vklads.Remove(cl);
                dbContext.SaveChanges();

                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Ни один объект не выбран!");
        }

        private int getSelectedRow(DataGridView dataGridView)
        {
            int index = -1;
            if (dataGridView.SelectedRows.Count > 0 || dataGridView.SelectedCells.Count == 1)
            {
                if (dataGridView.SelectedRows.Count > 0)
                    index = dataGridView.SelectedRows[0].Index;
                else index = dataGridView.SelectedCells[0].RowIndex;
            }
            return index;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = getSelectedRow(gvClientsList);
            if (index != -1)
            {
                int id = 0;
                bool converted = Int32.TryParse(gvClientsList[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Vklad cl = dbContext.Vklads.Where(i => i.Vklad_id == id).FirstOrDefault();
                if (cl != null)
                {
                    AddVkladForm f = new AddVkladForm();

                    f.textBox1.Text = cl.Balance.ToString();
                    f.dateTimePicker1.Value = cl.DateOpen;
                    

                    DialogResult result = f.ShowDialog(this);

                    if (result == DialogResult.OK)
                        return;


                    cl.DateOpen = f.dateTimePicker1.Value;
                    cl.Balance = int.Parse(f.textBox1.Text);

                   
                    dbContext.SaveChanges();
                    
                    gvClientsList.Refresh();
                    MessageBox.Show("Объект обновлен");
                }
            }
            else
                MessageBox.Show("Ни один объект не выбран!");
        }

        private class SPResult
        {
            public DateTime DateOpen { get; set; }
            public string name { get; set; }
            public Single Bottom_line { get; set; }
            public string Game_name { get; set; }
        }

        private void ExecuteSP()
        {
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@data", dateTimePicker1.Value.Date);
            

            var result = dbContext.Database.SqlQuery<SPResult>("pr_report @data", new object[] { param }).ToList();
            
            dataGridView1.DataSource = result;


            label2.Text = "Общее количество записей : " + dbContext.Database.SqlQuery<int>("SELECT COUNT(*) FROM Record").FirstOrDefault().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExecuteSP();
        }
    }
}
