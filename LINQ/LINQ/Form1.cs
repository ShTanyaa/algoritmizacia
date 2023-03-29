using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LINQ
{
    public partial class Form1 : Form
    {
        List<PeopleInfo> peoples = new List<PeopleInfo>();
        List<Department> department = new List<Department>();
        List<Employ> employ = new List<Employ>();
        public Form1()
        {
            InitializeComponent();
            FillList();
            department.Add(new Department("Отдел закупок", "Германия"));
            department.Add(new Department("Отдел продаж", "Испания"));
            department.Add(new Department("Отдел маркетинга", "Испания"));
            employ.Add(new Employ("Иванов", "Отдел закупок"));
            employ.Add(new Employ("Петров", "Отдел закупок"));
            employ.Add(new Employ("Сидоров", "Отдел продаж"));
            employ.Add(new Employ("Лямин", "Отдел продаж"));
            employ.Add(new Employ("Сидаренко", "Отдел маркетинга"));
            employ.Add(new Employ("Кривоносов", "Отдел продаж"));

            void FillList()
            {
                string[] persons = File.ReadAllLines("info.txt");
                foreach (string person in persons)
                {
                    string[] info = person.Split(' ');
                    PeopleInfo pers = new PeopleInfo(info[0], info[1], info[2], int.Parse(info[3]), double.Parse(info[4]));
                    peoples.Add(pers);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            listBox1.Items.Clear();
            var ages = from t in peoples
                       where t.GetAge > 40
                       select t;
            foreach(PeopleInfo t in ages)
            {
                listBox1.Items.Add(t.Info());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var group = from em in employ
        }
    }
}
