#region Espacios de Nombres
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
#endregion

namespace Cmp06.WebPreMatricula.Reports
{
    public partial class ReportsView : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ReportParameter> vFullParams = new List<ReportParameter>();

                if (!string.IsNullOrEmpty(Request.QueryString["FullParameters"]))
                {
                    string[] vParams = Request.QueryString["FullParameters"].Split('|');
                    foreach (string item in vParams)
                    {
                        string[] valores = item.Split(',');
                        vFullParams.Add(new ReportParameter(valores[0], valores[1]));
                    }
                }
                if (!string.IsNullOrEmpty(Request.QueryString["FullReporte"]))
                {
                    Utildatatool.HelperReportView.ReportRender(RptViewer, Request.QueryString["FullReporte"], vFullParams,
                        ConfigurationManager.AppSettings["ServerReport"],
                        ConfigurationManager.AppSettings["Folder"],
                        ConfigurationManager.AppSettings["User"],
                        ConfigurationManager.AppSettings["Password"],
                        ConfigurationManager.AppSettings["Domain"]);
                }

                //ReportPrintDocument rp = new ReportPrintDocument(RptViewer.ServerReport);
                //rp.Print(); 
            }
        }
    }
}