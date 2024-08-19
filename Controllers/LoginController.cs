using LIT_WEB_APIs_V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace LIT_WEB_APIs_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;


        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        [Route("Login")]

        public JsonResult LitLogin([FromBody] LoginDto login)
        {
            if (ModelState.IsValid)
            {

                var loginDetails = new Utlities.DBConnection(_configuration).Get_Login(login);

                return new JsonResult(loginDetails);
            }
            return new JsonResult("");

        }
    
    [HttpPost]
    [Route("Registeration")]

        public JsonResult LitRegistration([FromBody] RegistrationDto regstrarion)
        {
            if (ModelState.IsValid)
            {

                var registrationDetails = new Utlities.DBConnection(_configuration).Get_Registration(regstrarion);

                return new JsonResult(registrationDetails);
            }
            return new JsonResult("");

        }

    [HttpGet]
    [Route("LitLogin1")]
    public JsonResult LitLogin1()
        {
            string query = "select * from tbl_sysuser ";
            DataTable table = new DataTable();
            string mySqlDataSource = _configuration.GetConnectionString("ConMySqlDB");

            MySqlDataReader myReader;
            using (MySqlConnection mySqlCon = new MySqlConnection(mySqlDataSource))
            {
                mySqlCon.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlCon))
                {
                    //mySqlCommand.Parameters.AddWithValue("@sEmailID", sEmailID);
                    //mySqlCommand.Parameters.AddWithValue("@sPwd", sPwd);

                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mySqlCon.Close();
                }


            }

            return new JsonResult(table);

        }

    }
}

//public JsonResult LitLogin( string EmailID, string Password)
//{
//    string query = "select * from tbl_sysuser where EmailID=@EmailID and Password=@Password";
//    DataTable table = new DataTable();
//    string mySqlDataSource = _configuration.GetConnectionString("ConMySqlDB");

//    MySqlDataReader myReader;
//    using (MySqlConnection mySqlCon = new MySqlConnection(mySqlDataSource))
//    {
//        mySqlCon.Open();
//        using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlCon))
//        {
//            mySqlCommand.Parameters.AddWithValue("@EmailID", EmailID);
//            mySqlCommand.Parameters.AddWithValue("@Password", Password);


//            myReader = mySqlCommand.ExecuteReader();
//            table.Load(myReader);
//            myReader.Close();
//            mySqlCon.Close();
//        }


//    }

//    return new JsonResult(table);

//}