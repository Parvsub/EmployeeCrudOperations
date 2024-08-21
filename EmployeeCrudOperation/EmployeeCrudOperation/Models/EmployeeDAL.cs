using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace EmployeeCrudOperation.Models
{
    public class EmployeeDAL
    {
        private readonly string _connectionstring = ConfigurationManager.ConnectionStrings["EmpConnection"].ConnectionString;

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        EmpName = reader["EmpName"].ToString(),
                        Position = reader["Position"].ToString(),
                        Salary = Convert.ToDecimal(reader["salary"])
                    };
                    employees.Add(employee);
                }
            }
            return employees;
        }

        //Create Add Method

        public int AddEmp(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Insert into Employee(EmpName,Position,Salary) values(@EmpName,@Position,@Salary)", con);
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("@Position", emp.Position);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        // Update Method

        public void UpdateEmp(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Update Employee set EmpName=@EmpName,Position = @Position, Salary=@Salary where Id =@Id", con);
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("@Position", emp.Position);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //Delete Method

        public void DeleteEmp(int empId)
        {
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Delete From Employee where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", empId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        // Get Data by Id

        public Employee GetEmpById(int empId)
        {
            Employee emp = null;
            using (SqlConnection con = new SqlConnection(_connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee where Id =@Id", con);
                cmd.Parameters.AddWithValue("@Id", empId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    emp = new Employee();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.EmpName = reader["EmpName"].ToString();
                    emp.Position = reader["Position"].ToString();
                    emp.Salary = Convert.ToDecimal(reader["Salary"]);
                }
            }
            return emp;
        }
    }
}
