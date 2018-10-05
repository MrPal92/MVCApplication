using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApplication.Models
{
    public class EmployeeDataAccessLayer
    {
        // Connection String
        string connectionString = "Data Source = PAL-PC; Initial Catalog = EmployeeDB; Integrated Security = true;";
        
        // Method to View all employees details
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employeesList = new List<Employee>();

            using( SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee();

                    employee.ID = Convert.ToInt32(reader["EmployeeId"]);
                    employee.Name = reader["Name"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.Department = reader["Department"].ToString(); ;
                    employee.City = reader["City"].ToString();

                    employeesList.Add(employee);
                }
                con.Close();
            }
            return employeesList;
        } //End Of GetAllEmployees Method

        //To Add new employee record in database
        public void AddNewEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Departmant", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }//End of method AddNewEmployee

        //To Update the record of employee
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Departmant", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }//End of method UpdateEmployee

        //Get details of employee by ID
        public Employee GetEmployeeById(int ID)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", ID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employee.ID = Convert.ToInt32(reader["EmployeeId"]);
                    employee.Name = reader["Name"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.Department = reader["Department"].ToString(); ;
                    employee.City = reader["City"].ToString();
                }
                con.Close();
            }

            return employee;
        }// End of method GetEmployeeById

        //Delete record of employee
        public void DeleteEmployee(int ID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
