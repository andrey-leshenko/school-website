using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public static class DataLink
{
    public static bool Exists(string email, string password)
    {
        string sql = string.Format("SELECT * FROM Users WHERE Email='{0}' AND PassHash='{1}'", email, GetHashedPassword(password));
        return MyAdoHelper.IsExist(database, sql);
    }

    public static void AddUser(string email, string fname, string lname, string password, string id)
    {
        string sql = string.Format("INSERT INTO Users (Email, ID, FirstName, LastName, PassHash, Admin) VALUES ('{0}','{1}','{2}','{3}', '{4}', 'False')",
            email, id, fname, lname, GetHashedPassword(password));
        MyAdoHelper.DoQuery(database, sql);
    }

    public static bool IsEmailRegistered(string email)
    {
        string sql = string.Format("SELECT * FROM Users WHERE Email='{0}'", email);
        return MyAdoHelper.IsExist(database, sql);
    }

    public static bool IsIDRegistered(string id)
    {
        string sql = string.Format("SELECT * FROM Users WHERE ID='{0}'", id);
        return MyAdoHelper.IsExist(database, sql);
    }
    public static void UpdateUser(string oldEmail, string email, string fname, string lname, string password, string id)
    {
        string sql = string.Format("UPDATE Users SET Email='{0}', ID='{1}', FirstName='{2}', LastName='{3}', PassHash='{4}'",
            email, id, fname, lname, GetHashedPassword(password));
        sql += " " + string.Format("WHERE Email='{0}'", oldEmail);
            
        MyAdoHelper.DoQuery(database, sql);
    }

    public static DataTable GetUsers(string searhString)
    {
        if (searhString == null || searhString == "")
            return MyAdoHelper.ExecuteDataTable(database, "SELECT * FROM Users");

        string first = string.Format("FirstName LIKE '%{0}%'", searhString);
        string last = string.Format("LastName LIKE '%{0}%'", searhString);
        string email = string.Format("Email LIKE '%{0}%'", searhString);
        string id = string.Format("ID LIKE '%{0}%'", searhString);

        string sql = string.Format("SELECT * FROM Users WHERE {0} OR {1} OR {2} OR {3}", first, last, email, id);

        return MyAdoHelper.ExecuteDataTable(database, sql); ;
    }

    public static DataTable GetUser(string email)
    {
        string sql = String.Format("SELECT * FROM Users WHERE Email='{0}'", email);
        return MyAdoHelper.ExecuteDataTable(database, sql); ;
    }

    public static void Delete(string email)
    {
        string sql = string.Format("DELETE FROM Users WHERE Email='{0}'", email);
        MyAdoHelper.DoQuery(database, sql);
    }

    public static void SetAdmin(string email, bool admin)
    {
        string sql = string.Format("UPDATE Users SET Admin='{0}' WHERE Email='{1}'", admin, email);
        MyAdoHelper.DoQuery(database, sql);
    }

    public static bool IsAdmin(string email)
    {
        string sql = string.Format("SELECT * FROM USERS WHERE Email='{0}' AND Admin='True'", email);
        return MyAdoHelper.IsExist(database, sql);
    }

    private static string database = "Database.mdf";


    private static string GetHashedPassword(string unhashed)
    {
        string salt = "c5g3uatKK6HECzAqK9uuUr5Xs6hF9n3X";
        return GetHashString(unhashed + salt);
    }

    private static string GetHashString(string unhashed)
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(unhashed);
        System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
        byte[] hash = sha.ComputeHash(inputBytes);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < hash.Length; i++)
            sb.Append(hash[i].ToString("x2"));

        return sb.ToString();
    }
}