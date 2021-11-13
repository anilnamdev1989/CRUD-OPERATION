using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class User
    {

        string conStr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        public void CreateUser(BO.User objUser)
        {
            int i = 0;
            using (SqlConnection scn=new SqlConnection(conStr))
            {
                using(SqlCommand cmd=new SqlCommand("prc_CreateUser", scn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = objUser.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = objUser.Password;
                    try
                    {
                        scn.Open();
                        i=cmd.ExecuteNonQuery();
                        scn.Close();
                    }
                    catch (Exception ex)
                    {

                        string str = ex.Message;
                    }
                    finally
                    {
                        if (scn.State == ConnectionState.Open)
                            scn.Close();
                    }

                }
            }
        }

    }
}
