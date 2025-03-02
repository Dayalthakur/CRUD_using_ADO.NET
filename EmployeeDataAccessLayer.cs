using CRUD_ADO.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CRUD_ADO
{
    public class EmployeeDataAccessLayer
    {
        string cs = ConnectionString.dbcs;
        public List<Employees> GetEmployees()
        {
            List<Employees> emplist = new List<Employees>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employees emp = new Employees();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["name"].ToString();
                    emp.Gender = reader["gender"].ToString();
                    emp.Age = Convert.ToInt32(reader["age"]);
                    emp.Designation = reader["designation"].ToString();
                    emp.City = reader["city"].ToString();
                    emplist.Add(emp);
                }
                return emplist;
            }
        }
        public void Add_User(Employees emp)
        {
            List<Employees> emplist = new List<Employees>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Employees getEmployeebyID(int id)
        {
            Employees emp = new Employees();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employees where id=@id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["name"].ToString();
                    emp.Gender = reader["gender"].ToString();
                    emp.Age = Convert.ToInt32(reader["age"]);
                    emp.Designation = reader["designation"].ToString();
                    emp.City = reader["city"].ToString();
                }
            }
            return emp;
        }

        public void Update_User(Employees emp)
        {
            List<Employees> emplist = new List<Employees>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete_User(int id)
        {
            List<Employees> emplist = new List<Employees>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
