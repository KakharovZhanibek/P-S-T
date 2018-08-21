using P_S_T.Interface;
using PST.LIB.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_S_T.Modul
{
    public class Student : IPerson
    {
        public string FIO { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        
        public Student()
        {
            FIO = "None";
            Age = 0;
            DOB = DateTime.Now;
        }
        public Student(string FIO,int Age ,DateTime DOB)
        {
            this.FIO = FIO;
            this.Age = Age;
            this.DOB = DOB;
        }
        public void Print()
        {
            
        }
        public override string ToString()
        {
            string str = string.Format("ФИО :{0}\nВозраст :{1}\nДата рождения :{2}", FIO, Age, DOB.Date);
            return str;
        }
        public static Student Random_Student(ref List<Student>temp_students)
        {
            Student s = new Student();
            Random rnd = new Random();
            int r = rnd.Next(1, temp_students.Count);
            s = temp_students[r];
            temp_students.RemoveAt(r);
            return s;
        }
    }
}
