using AutoMapper;
using System.Web.Mvc;
using Taller.ConfigMapper;

namespace Taller
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
