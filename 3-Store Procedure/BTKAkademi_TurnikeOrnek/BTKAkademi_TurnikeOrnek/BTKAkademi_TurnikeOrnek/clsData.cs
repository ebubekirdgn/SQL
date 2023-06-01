using System;
using System.Data;
using System.Data.SqlClient;

public class clsData
{
    public  string cs = "";




    public DataSet fill(CommandType commandType, string commandText, params SqlParameter[] parameters)
    {
        SqlConnection conn = new SqlConnection(cs);
        DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = commandType;
            cmd.CommandTimeout = 200;
            int i;
            for (i = 0; i <= parameters.Length - 1; i++)
                cmd.Parameters.Add(parameters[i]);
            cmd.CommandTimeout = 10000;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        
       
    }

    public void executeNonQuery(CommandType commandType, string commandText )
    {
        try
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = commandType;
            cmd.CommandTimeout = 200;
            int i;
            
            cmd.CommandTimeout = 10000;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
        }
    }
}
