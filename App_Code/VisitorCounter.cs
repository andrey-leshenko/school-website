using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

public static class VisitorCounter
{
    public static void LogPageLoad(Page page)
    {
        if (page.Session[countedVisitor] == null)
        {
            AddUser(page.Application);
            page.Session[countedVisitor] = true;
        }
    }

    public static int GetCount(Page page)
    {
        // Itn't is a great place to use the null-coalescing operator??
        return (int)(page.Application[visitors] ?? 1);
    }

    private static void AddUser(HttpApplicationState application)
    {
        application[visitors] = (int)(application[visitors] ?? 0) + 1;
    }

    private static string countedVisitor = "CountedVisitor";
    private static string visitors = "Visitors";
}
