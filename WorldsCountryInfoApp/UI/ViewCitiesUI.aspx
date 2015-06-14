<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCitiesUI.aspx.cs" Inherits="WorldsCountryInfoApp.UI.ViewCitiesUI" MasterPageFile="~/Site.Master" ValidateRequest="false"%>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1>View Cities</h1>
        <asp:Panel ID="Panel1" runat="server" GroupingText="Search Criteria">
        <table>
        <tr>
            <td>
                <asp:RadioButton ID="citySelectRadioButton" runat="server" AutoPostBack="True" 
                    oncheckedchanged="citySelectRadioButton_CheckedChanged" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="City Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="cityNameTextBox" runat="server"></asp:TextBox>
            </td>
      </tr>
      <tr>
           <td>
                <asp:RadioButton ID="countrySelectRadioButton" runat="server" 
                    AutoPostBack="True" 
                    oncheckedchanged="countrySelectRadioButton_CheckedChanged" />
           </td>
           <td>
                <asp:Label ID="Label2" runat="server" Text="Country"></asp:Label>
           </td>
           <td>
               <asp:DropDownList ID="countryDropDownList" runat="server"></asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td>
               <asp:Button ID="searchButton" runat="server" Text="Search" 
                onclick="searchButton_Click" />
           </td>
        </tr>
        </table>
            <asp:GridView ID="detailShowGridView" runat="server" 
                AutoGenerateColumns="False" 
                onrowdatabound="detailShowGridView_RowDataBound" AllowPaging="True" 
                onpageindexchanging="detailShowGridView_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="SL No." />
                    <asp:BoundField DataField="City_name" HeaderText="City Name" />
                    <asp:BoundField DataField="About_city" HeaderText="About City" 
                        HtmlEncode="False" />
                    <asp:BoundField DataField="No_of_dwellers" HeaderText="No. of Dwellers" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="Whather" HeaderText="Weather" />
                    <asp:BoundField DataField="Country_name" HeaderText="Country" />
                    <asp:BoundField DataField="About_country" HeaderText="About Country" 
                        HtmlEncode="False" />
                </Columns> 
            </asp:GridView> 
        </asp:Panel>
    
    </div>
    </asp:Content>
