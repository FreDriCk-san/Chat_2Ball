﻿using System.Web;
using System.Web.Mvc;

namespace Chat_2Ball
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
