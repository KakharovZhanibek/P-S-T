using GeneratorName;
using P_S_T.Modul;
using PST.LIB.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_S_T
{
    class Program
    {
        static void Create_and_Fixing()
        {
            Generator gen = new Generator();
            Random rnd = new Random();

            List<Student> temp_students = new List<Student>();
            List<Teacher> temp_teachers = new List<Teacher>();

            List<StudentWithAdvisor> SWA = new List<StudentWithAdvisor>();
            List<TeacherWithStudent> TWS = new List<TeacherWithStudent>();

            for (int i = 0; i < 15; i++)
            {
                Student student = new Student();
                student.FIO = gen.GenerateDefault((Gender)rnd.Next(2))
                        .Replace("<center><b><font size=7>", "")
                        .Replace("</font></b></center>", "")
                        .Replace("\n", "")
                        .Substring(1);
                student.DOB = DateTime.Now.AddYears(rnd.Next(-24, -17)).AddMonths(rnd.Next(1, 13)).AddDays(rnd.Next(1, 31));
                student.Age = DateTime.Now.Year - student.DOB.Year;
                temp_students.Add(student);
            }
            for (int i = 0; i < 5; i++)
            {
                Teacher teacher = new Teacher();
                teacher.FIO = gen.GenerateDefault((Gender)rnd.Next(2))
                        .Replace("<center><b><font size=7>", "")
                        .Replace("</font></b></center>", "")
                        .Replace("\n", "")
                        .Substring(1);
                teacher.DOB = DateTime.Now.AddYears(rnd.Next(-63, -25)).AddMonths(rnd.Next(1, 13)).AddDays(rnd.Next(1, 31));
                teacher.Age = DateTime.Now.Year - teacher.DOB.Year;
                temp_teachers.Add(teacher);
            }

            for (int i = 0; i < temp_students.Count; i++)
            {
                StudentWithAdvisor s = new StudentWithAdvisor();
                s.FIO = temp_students[i].FIO;
                s.DOB = temp_students[i].DOB;
                s.Age = temp_students[i].Age;
                //s.DB = temp_teachers;
                SWA.Add(s);
            }

            for (int i = 0; i < temp_teachers.Count; i++)
            {
                TeacherWithStudent t = new TeacherWithStudent();
                t.FIO = temp_teachers[i].FIO;
                t.DOB = temp_teachers[i].DOB;
                t.Age = temp_teachers[i].Age;
                t.DB = temp_students;
                TWS.Add(t);
            }

            for (int i = 0; i < TWS.Count; i++)
            {
                int random1 = rnd.Next(1, ((temp_students.Count / temp_teachers.Count) + 1));
                for (int j = 0; j <=random1; j++)
                {
                    TWS[i].students.Add(Student.Random_Student(ref temp_students));

                    foreach (StudentWithAdvisor item in SWA.Where(w => w.FIO == TWS[i].students[j].FIO && w.DOB == TWS[i].students[j].DOB && w.Age == TWS[i].students[j].Age))
                    {
                        item.Teacher = TWS[i];
                    }
                }
            }
            Print_Teachers(ref TWS);
            Print_Students(ref SWA);
        }

        #region MyRegion
        public static void Print_Students(ref List<StudentWithAdvisor> Students)
        {
            Console.WriteLine("\nStart-----------Students----------");
            foreach (StudentWithAdvisor item in Students)
            {
                Console.WriteLine("_______");
                Console.WriteLine("ФИО : " + item.FIO);
                Console.WriteLine("Возраст : " + item.Age);
                Console.WriteLine("Дата рождения : " + item.DOB.Date);
                Console.WriteLine("\n\tРуководящий учитель : \n\t" + item.Teacher);
                Console.WriteLine("_______");
            }
            Console.WriteLine("\nFinish-----------Students----------");
        }
        #endregion


        #region MyRegion
        public static void Print_Teachers(ref List<TeacherWithStudent> Teachers)
        {
            Console.WriteLine("\nStart-----------Teacher-------------");
            foreach (TeacherWithStudent item in Teachers)
            {
                Console.WriteLine("_______");

                Console.WriteLine("ФИО : " + item.FIO);
                Console.WriteLine("Возраст : " + item.Age);
                Console.WriteLine("Дата рождения : " + item.DOB.Date);
                Console.WriteLine("\n\tУченики : \n\t\t");
                foreach (Student s in item.students)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("_______");
            }
            Console.WriteLine("\nFinish-----------Teacher-------------");
        }
        #endregion


        static void Main(string[] args)
        {
            Create_and_Fixing();

        }
    }
}
