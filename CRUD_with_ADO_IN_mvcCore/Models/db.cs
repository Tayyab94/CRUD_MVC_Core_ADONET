using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CRUD_with_ADO_IN_mvcCore.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K0705CJ; Initial Catalog=Check; Integrated Security=true");

        public DataSet Empget(Employee model, out String msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@sr_No", model.sr_No);
                com.Parameters.AddWithValue("@Emp_name", model.Emp_name);
                com.Parameters.AddWithValue("@City", model.City);
                com.Parameters.AddWithValue("@Country", model.Country);
                com.Parameters.AddWithValue("@Department", model.Department);
                com.Parameters.AddWithValue("@flag", model.flag);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(com);
                sqlDataAdapter.Fill(ds);
                msg = "Ok";
                return ds;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return ds;
            }
        }



        public string Empdml(Employee model, out String msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@sr_No", model.sr_No);
                com.Parameters.AddWithValue("@Emp_name", model.Emp_name);
                com.Parameters.AddWithValue("@City", model.City);
                com.Parameters.AddWithValue("@Country", model.Country);
                com.Parameters.AddWithValue("@Department", model.Department);
                com.Parameters.AddWithValue("@flag", model.flag);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "OK";

                return msg;
            }
            catch (Exception e)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                msg = e.Message;
                return msg;
            }
        }

    }
}
