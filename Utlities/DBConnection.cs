using LIT_WEB_APIs_V1.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace LIT_WEB_APIs_V1.Utlities
{

    public class DBConnection
    {
        IConfiguration _configuration;
        public DBConnection(IConfiguration configuration) { 
            
            _configuration = configuration;
        
        }

        public DataTable Get_Login(LoginDto login)
        {
            string query = "select * from tbl_sysuser where EmailID=@EmailID and Password=@Password";

            DataTable table = new DataTable();
            string mySqlDataSource = _configuration.GetConnectionString("ConMySqlDB");

            MySqlDataReader myReader;
            using (MySqlConnection mySqlCon = new MySqlConnection(mySqlDataSource))
            {
                mySqlCon.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlCon))
                {
                    mySqlCommand.Parameters.AddWithValue("@EmailID", login.sEmailID);
                    mySqlCommand.Parameters.AddWithValue("@Password", login.sPassword);


                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mySqlCon.Close();
                }


            }

            return table;
        }

        public DataTable Get_Registration(RegistrationDto registration)
        {
            string query = "INSERT INTO tbl_sysuser( EmailID, UserName,Password,Status,User_Code,Access_Lvl,Created_Date,Updated_Date,UpdatedBy) VALUES ( @EmailID, @UserName,@Password,@Status,@User_Code,@Access_Lvl,now(),now(),@UpdatedBy); ";

            DataTable table = new DataTable();
            string mySqlDataSource = _configuration.GetConnectionString("ConMySqlDB");

            MySqlDataReader myReader;
            using (MySqlConnection mySqlCon = new MySqlConnection(mySqlDataSource))
            {
                mySqlCon.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlCon))
                {
                    mySqlCommand.Parameters.AddWithValue("@EmailID", registration.sEmailID);
                    mySqlCommand.Parameters.AddWithValue("@UserName", registration.sUserName);
                    mySqlCommand.Parameters.AddWithValue("@Password", registration.sPassword);
                    
                    mySqlCommand.Parameters.AddWithValue("@Status", registration.sStatus);
                    mySqlCommand.Parameters.AddWithValue("@User_Code", registration.sUserCode);
                    mySqlCommand.Parameters.AddWithValue("@Access_Lvl", registration.sAccessLvl);
                    mySqlCommand.Parameters.AddWithValue("@UpdatedBy", registration.sUpdatedBy);
                    //mySqlCommand.Parameters.AddWithValue("@Password", registration.sUserCode);

                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mySqlCon.Close();
                }


            }

            return table;
        }


    }
}
