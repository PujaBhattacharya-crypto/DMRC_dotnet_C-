<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dmrc._Default" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <h2 style="background-color: #800080">
       
        <asp:Image ID="dmrc" runat="server" Height="263px" 
            ImageUrl="~/images/DMRC.jpg" Width="911px" BackColor="Black" 
            BorderColor="#000066" BorderStyle="Dotted" BorderWidth="5px" />
       
    </h2>
    <h1 align="center" 
    style="background-color: #6c3737; font-size: 55px; color: #000000;">WELCOME TO DMRC</h1>
    <p style="background-color: #6c3737; color: #FFFFFF;">
       
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label 
            ID="From" runat="server" ForeColor="Black" Text="Start Stations" 
            Height="16px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="StartDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="StationId" DataValueField="StationId" >
            <asp:ListItem>Stations</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:metroConnectionString %>" SelectCommand="SELECT StationId FROM Red UNION ALL SELECT StationId FROM Yellow UNION ALL SELECT StationId FROM Blue UNION ALL SELECT StationId FROM Blue1 UNION ALL SELECT StationId FROM Green UNION ALL SELECT StationId FROM Violet UNION ALL SELECT StationId FROM Pink UNION ALL SELECT StationId FROM Margenta UNION ALL SELECT StationId FROM Grey"></asp:SqlDataSource>
       
    </p>
<p style="background-color: #6c3737; color: #FFFFFF;">
       
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource2" DataTextField="StationNameAndId" DataValueField="StationNameAndId"></asp:ListBox>
       
    </p>
    <p style="background-color: #6c3737">
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="to" runat="server" ForeColor="Black" Text="Destination Stations" 
            Height="16px"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="EndDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="StationId" DataValueField="StationId">
            <asp:ListItem>Stations</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
       </p>
    <p style="background-color: #6c3737">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="StationNameAndId" DataValueField="StationNameAndId"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:metroConnectionString %>" SelectCommand="SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Red UNION ALL SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Yellow UNION ALL SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Blue UNION ALL SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Blue1 UNION ALL SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Green UNION ALL SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Violet UNION ALL SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Pink UNION ALL SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Margenta UNION ALL SELECT Stations + ' - ' + CAST(StationId AS NVARCHAR(50)) AS StationNameAndId FROM Grey">
        </asp:SqlDataSource>
       </p>
<p style="background-color: #6c3737">
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
       <asp:Button ID="fare" runat="server" BackColor="Black" BorderStyle="Ridge" 
           ForeColor="White" Text="Fares" OnClick="fare_Click"  />
&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="route" runat="server" BackColor="Black" BorderStyle="Ridge" 
           ForeColor="White" Text="Route" OnClick="route_Click" />
     <asp:GridView ID="gridview" runat="server" BorderStyle="Dotted" ForeColor="Black" ></asp:GridView>
        <br /><br />
       </p>
</asp:Content>
