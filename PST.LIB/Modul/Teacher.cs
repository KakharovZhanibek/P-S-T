using P_S_T.Interface;
using PST.LIB.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_S_T.Modul
{
    public class Teacher : IPerson
    {
        public string FIO { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public List<Student> DB;

        public Teacher()
        {
            FIO = "None";
            Age = 0;
            DOB = DateTime.Now;
            DB = new List<Student>();
        }
        public Teacher(string FIO, int Age, DateTime DOB)
        {
            this.FIO = FIO;
            this.Age = Age;
            this.DOB = DOB;
            DB = new List<Student>();
        }
        public void Print()
        {
            Console.WriteLine("Имя : " + FIO);
            Console.WriteLine("Возраст : " + Age);
            Console.WriteLine("Дата рождения:" + DOB);
            Console.WriteLine("\n\tСтуденты : ");

        }
        public override string ToString()
        {
            string str = string.Format("ФИО :{0}\nВозраст :{1}\nДата рождения :{2}", FIO, Age, DOB.Date);
            return str;
        }

        //public static Teacher Random_Teacher(StudentWithAdvisor S, int r)
        //{
            
        //}
    }
}
