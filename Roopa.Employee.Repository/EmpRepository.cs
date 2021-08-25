using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Roopa.Repository.Model;



namespace Roopa.Employee.Repository
{
    public class EmpRepository
    {
        private SqlConnection sqlconnection;
        private string _dbconnstr;
       // IConfiguration _configuration;


        private string GetConnectionString()
        {
            return _dbconnstr;
        }

        public EmpRepository(string dbconnstr=null)
        {
            _dbconnstr = dbconnstr;

        }



        public bool AddEmployee(Roopa.Repository.Model.EmpModel obj)   
        {

            string sqlConnectionstring = GetConnectionString();
            sqlconnection = new SqlConnection(sqlConnectionstring);

            SqlCommand com = new SqlCommand("USP_InsertEmployees", sqlconnection);

            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);

            sqlconnection.Open();
            int i = com.ExecuteNonQuery();
            sqlconnection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<Roopa.Repository.Model.EmpModel> GetAllEmployees()  //To View employee details with generic list
        {
            string sqlConnectionstring = GetConnectionString();
            sqlconnection = new SqlConnection(sqlConnectionstring);
            List<EmpModel> EmpList = new List<EmpModel>();

            SqlCommand com = new SqlCommand("USP_GetAllEmployees", sqlconnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            da.Fill(dt);
            sqlconnection.Close();


            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(

                    new EmpModel
                    {
                        Empid = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])

                    });
            }

            return EmpList;


        }

        public bool UpdateEmployee(EmpModel obj)
        {
            string sqlConnectionstring = GetConnectionString();
            sqlconnection = new SqlConnection(sqlConnectionstring);


            SqlCommand com = new SqlCommand("USP_UpdateEmployees", sqlconnection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.Empid);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            sqlconnection.Open();
            int i = com.ExecuteNonQuery();
            sqlconnection.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        public bool DeleteEmployee(int Id)
        {

            string sqlConnectionstring = GetConnectionString();
            sqlconnection = new SqlConnection(sqlConnectionstring);
            SqlCommand com = new SqlCommand("USP_DeleteEmployeeById", sqlconnection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);

            sqlconnection.Open();
            int i = com.ExecuteNonQuery();
            sqlconnection.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

    }


}
