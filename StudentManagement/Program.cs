using Castle.MicroKernel.Registration;
using Castle.Windsor;
using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            try
            {
                Console.OutputEncoding = Encoding.Unicode;
                string connectionString = "test";
                container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>(),
                                   //Component.For<IStudentData>().ImplementedBy<StudentFileData>()
                                   Component.For<IStudentData>().ImplementedBy<StudentDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
                                   );
                //Console.InputEncoding = Encoding.UTF8;
                var studentService = container.Resolve<IStudentService>();
                List<Student> students = studentService.GetAll();
                while (true)
                {
                    Console.WriteLine("1. Thêm sinh viên");
                    Console.WriteLine("2. Danh sách sinh viên");
                    Console.Write("Chọn chức năng: ");
                    string feature = Console.ReadLine();
                    switch (feature)
                    {
                        case "1":
                            students.Add(studentService.Create());
                            break;
                        case "2":
                            studentService.ShowList(students);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cmnr: " + ex.Message);
            }
            finally
            {
                container.Dispose();
            }
            Console.ReadLine();
        }

        static void Init()
        {

        }
    }
}
