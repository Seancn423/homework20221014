using System;

namespace third
{
    class Program
    {
        public delegate bool GradePrint(Student s);

        public class Student
        {
            public GradePrint GP { set; get; }
            public void InvokeGradePrint()
            {
                GP(this);
            }
        }
        public class GradeReport//成绩单
        {
            public static bool GradeReportOrderByTerm(Student s)
            {
                Console.WriteLine("按学期打印成绩");
                return true;
            }
            public static bool GradeReportOrderByRank(Student s)
            {
                Console.WriteLine("按排名打印成绩");
                return true;
            }
            public static bool GradeReportOrderByCourse(Student s)
            {
                Console.WriteLine("按课程打印成绩");
                return true;
            }
        }
        static void Main(string[] args)
        {
            Student s = new Student();
            s.GP = GradeReport.GradeReportOrderByTerm;
            s.GP += GradeReport.GradeReportOrderByRank;
            s.GP += GradeReport.GradeReportOrderByCourse;
            s.InvokeGradePrint();

        }
    }
}
