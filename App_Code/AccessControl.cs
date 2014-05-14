using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.SessionState;

/// <summary>
/// Manages log in / out operations and granting users
/// admin permissions.
/// </summary>
public static class AccessControl
{
    public static void LogIn(Page page, string username, bool admin)
    {
        page.Session[userField] = username;
        page.Session[adminField] = admin;
    }

    public static void LogOut(Page page)
    {
        page.Session.Abandon();
    }

    public static bool IsLoggedIn(Page page)
    {
        return page.Session[userField] != null;
    }

    public static string GetLoggedUser(Page page)
    {
        if (page.Session[userField] == null)
            return null;
        return (string)page.Session[userField];
    }

    public static bool IsAdmin(Page page)
    {
        if (page.Session[adminField] == null)
            return false;
        return (bool)page.Session[adminField];
    }

    private static string userField = "logedInUser";
    private static string adminField = "admin";
}
