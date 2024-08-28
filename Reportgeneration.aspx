<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportgeneration.aspx.cs" Inherits="dmrc.WebForm4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image ID="Imagehelpdesk" runat="server" BorderColor="Black" 
        BorderStyle="Groove" BorderWidth="6px" Height="318px" 
        ImageUrl="~/images/dmrc helpdisk.jpg" Width="911px" 
        style="margin-left: 0px" />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:DropDownList ID="ddlTimePeriod" runat="server">
            <asp:ListItem Text="Month" Value="Month"></asp:ListItem>
            <asp:ListItem Text="Week" Value="Week"></asp:ListItem>
            <asp:ListItem Text="Year" Value="Year"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnShowData" runat="server" Text="Show Data" OnClick="btnShowData_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" ForeColor="Black" BorderColor="Black" BorderStyle="Dotted">
        </asp:GridView>
        <br />
        <asp:GridView ID="gvMostUsedStations" runat="server" AutoGenerateColumns="false" BorderColor="Black" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="Station" HeaderText="Station" />
                <asp:BoundField DataField="UsageCount" HeaderText="Usage Count" />
            </Columns>
        </asp:GridView>
        <br />
    </div>
</asp:Content>
