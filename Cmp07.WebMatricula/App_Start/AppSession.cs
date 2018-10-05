using Cmp02.Entities;
using System.Web;

namespace Cmp07.WebMatricula
{
    public static class AppSession
    {
        public static Tb_Usuario Usuario { get { return (Tb_Usuario)HttpContext.Current.Session["User"]!=null ? (Tb_Usuario)HttpContext.Current.Session["User"] : null; } }
    }
}