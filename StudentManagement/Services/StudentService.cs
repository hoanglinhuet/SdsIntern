using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;

namespace StudentManagement.Services
{
    internal class StudentService
    {
        private StudentFileData _da;
        public StudentService()
        {
            _da = new StudentFileData();
        }
        public List<Student> GetAll()
        {
            return _da.GetAll();
        }

        public Student Create()
        {
            Student student = new Student();
            Console.Write("Code: ");
            student.Code = Console.ReadLine();
            Console.Write("Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Age: ");
            student.Age = Convert.ToInt32(Console.ReadLine());
            _da.Add(student);
            return student;
        }

        public void ShowList(List<Student> student)
        {
            var t = new TablePrinter("Code", "Name", "Age");
            foreach (var s in student)
            {
                t.AddRow(s.Code, s.Name, s.Age);
            }
            t.Print();
        }
    }
}
