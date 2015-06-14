<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCountryUI.aspx.cs" Inherits="WorldsCountryInfoApp.UI.ViewCountryUI" MasterPageFile="~/Site.Master" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    <h1>View Country</h1>
        <asp:Panel ID="Panel1" runat="server" GroupingText="Search Criteria">
         <table>
           <tr>
               <td>
                   <asp:Label ID="Label1" runat="server" Text="Country Name"></asp:Label></td>
               <td>
                   <asp:TextBox ID="countryNameTextBox" runat="server"></asp:TextBox></td>
               <td>
                   <asp:Button ID="searchButton" runat="server" Text="Search" 
                       onclick="searchButton_Click" /></td>
           </tr>
         </table>
            <asp:GridView ID="detailShowGridView" runat="server" 
                AutoGenerateColumns="False" 
                onrowdatabound="detailShowGridView_RowDataBound" AllowPaging="True" 
                onpageindexchanging="detailShowGridView_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:BoundField DataField="Sl" HeaderText="Sl No." />
                    <asp:BoundField DataField="Country_name" HeaderText="Name" />
                    <asp:BoundField DataField="About_country" HeaderText="About" 
                        HtmlEncode="False" />
                    <asp:BoundField DataField="TotalCity" HeaderText="No of City" />
                    <asp:BoundField DataField="No_of_dwellers" HeaderText="No of City Dwellers" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    </asp:Content>
