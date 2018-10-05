<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportsServer.aspx.cs" Inherits="Cmp08.WebCaja.Reports.ReportsServer" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>
<html id="html">
<head runat="server">
    <%--<meta http-equiv="X-UA-Compatible" content="IE=11; IE=10; IE=9; IE=EDGE" />--%>
    <meta http-equiv="X-UA-Compatible" content="IE=11" />
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <style type="text/css">
        html#html, body#body, form#FrmReporte, div#content {height:100%;border:0px solid black;padding:0px;margin:0px;}
        /*table div div div { width:100%; min-width:100%; text-align:justify!important; text-justify: distribute-all-lines!important; text-align:justify!important; }*/
        /*table div div div { width:100%; min-width:100%; text-justify: distribute!important; text-align:justify!important; }*/
        /*table div div div { width:100%; min-width:100%; display: inline; text-align-last: justify; text-align: justify; text-justify: inter-word; }*/
        /*table div div div { width:100%; min-width:100%; text-align:justify!important; text-justify: distribute!important; }*/
        /*table div div div { text-align:justify!important; text-justify: distribute!important; }*/
    </style>
</head>
<body id="body">
    <form id="FrmReporte" runat="server" style="min-height: 100%; max-height: 100%; height: 100%">
        <asp:ScriptManager ID="SmrAjax" runat="server"></asp:ScriptManager>
        <div id="content">
            <rsweb:ReportViewer ID="RptViewer" runat="server" Width="100%" Height="100%" ShowParameterPrompts="False" SizeToReportContent="true" ShowPrintButton="True" ></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
