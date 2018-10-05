using Cmp02.Entities;
using System.Web;

namespace Cmp11.WebSistemas
{
    public static class AppSession
    {
        public static Tb_Usuario Usuario { get { return (Tb_Usuario)HttpContext.Current.Session["User"]!=null ? (Tb_Usuario)HttpContext.Current.Session["User"] : null; } }
    }
}