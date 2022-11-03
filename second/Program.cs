using System;

namespace second
{
    class Program
    {
        class student
        {
            public int sno;

            public student(int sno)
            {
                this.sno = sno;
            }
        }
        class banji
        {
            student[] students;

            public banji(int i)
            {
                students = new student[i];
            }
            public student this[int index]
            {
                get 
                { 
                    if(index<0||index>=students.Length)
                    {
                        Console.WriteLine("索引无效");
                        return null;
                    }
                    else { return students[index]; }
                }
                set 
                {
                    if (index < 0 || index >= students.Length)
                    {

                        Console.WriteLine("索引无效");
                        return;
                    }
                    else { students[index] = value; }
                }
            }
        }
        static void Main(string[] args)
        {
            student s = new student(12);
            banji bj = new banji(5);
            bj[1] = s;
            Console.WriteLine(bj[1].sno);
        }
    }
}
