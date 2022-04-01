using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class StudentDapperData : IStudentData
    {
        private readonly string _connectionString;
        public StudentDapperData(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Student student)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                // add
            }
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            // get all
            return students;
        }
    }
}
