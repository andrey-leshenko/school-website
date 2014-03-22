using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class _Default : System.Web.UI.Page
{
    public string serverResponse = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection conn = MyAdoHelper.ConnectToDb("Database.mdf");
        conn.Open();
        if (Request["submit"] != null)
        {
            string firstName        = Request["firstName"];
            string lastName         = Request["lastName"];
            string phone            = Request["phone"];
            string firstPassword    = Request["userPassword"];
            string secondPassword   = Request["repeatPassword"];
            string email            = Request["email"];

            if (!FieldChecking.Check(firstName, lastName, phone, firstPassword, secondPassword, email)) {
                Response.Write("Illeagel Values In Fileds, js checking failed. try refrashing the page");
                //return;
            }

            string passwordHash = CalculateSha1(firstPassword);
            
			string sql = string.Format("INSERT INTO Users VALUES('{0}','{1}','{2}','{3}','{4}')",
                email, firstName, lastName, phone, passwordHash);

            MyAdoHelper.DoQuery("Database.mdf", sql);
        }
    }

    private string CalculateSha1(string strToEncrypt) {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);
        // encrypt bytes
        SHA1CryptoServiceProvider md5 = new SHA1CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++) {

            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');

        }
        return hashString.PadLeft(32, '0');
    }


}