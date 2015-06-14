<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountryEntryUI.aspx.cs" Inherits="WorldsCountryInfoApp.CountryEntryUI" MasterPageFile="~/Site.Master" ValidateRequest="false"%>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../Content/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../froala_editor_1.2/css/froala_editor.min.css" rel="stylesheet" type="text/css" />
    <link href="../froala_editor_1.2/css/froala_style.min.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="../froala_editor_1.2/js/froala_editor.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $('#aboutTextBox').editable({ inlineMode: false })
        });
  </script>
   <style type="text/css">
        .style1
        {
            height: 67px;
        }
        .style2
        {
            height: 40px;
        }
        .hide
        {
            display:none;
        }
    </style>
    <div>
        <asp:Panel ID="Panel1" runat="server"  GroupingText="Country Entry">
            <table>
               <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></td>
                 <td>
                     <asp:TextBox ID="countryNameTextBox" runat="server" Width="252px"></asp:TextBox></td>
               </tr>
                <tr>
                 <td class="style2">
                     <asp:Label ID="Label2" runat="server" Text="About"></asp:Label></td>
                 <td class="style2">
                     <asp:TextBox ID="aboutTextBox" runat="server" Height="87px" ClientIDMode="Static"
                         TextMode="MultiLine" Width="257px"></asp:TextBox></td>
               </tr>
               <tr>
                  <td>
                      <asp:Button ID="saveButton" runat="server" Text="Save" Width="77px" 
                          onclick="saveButton_Click" /></td>
                  <td><asp:Button ID="cancelButton" runat="server" Text="Cancel" Width="85px" 
                          onclick="cancelButton_Click" /></td>
               </tr>
               <tr>
                  <td>
                      <asp:Label ID="statusLabel" runat="server" Text="" style="color:Green"></asp:Label></td>
               </tr>
              
            </table>
             
                  <asp:GridView ID="CountryShowGridView" runat="server" 
                AutoGenerateColumns="False" onrowdatabound="CountryShowGridView_RowDataBound">
                      <Columns>
                          <asp:BoundField DataField="ID" HeaderText="Sl no">
                               <HeaderStyle Height="15px" Width="50px" />
                               <ItemStyle Height="15px" Width="50px" />
                           </asp:BoundField>
                           <asp:BoundField DataField="ID" HeaderText="ID">
                               <HeaderStyle Height="15px" Width="50px" CssClass="hide"/>
                               <ItemStyle Height="15px" Width="50px" CssClass="hide"/>
                           </asp:BoundField>
                          <asp:BoundField DataField="Name" HeaderText="Name">
                              <HeaderStyle Height="15px" Width="150px" />
                               <ItemStyle Height="15px" Width="150px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="About" HeaderText="About" HtmlEncode="False">
                               <HeaderStyle Height="15px" Width="150px" />
                               <ItemStyle Height="15px" Width="150px" />
                          </asp:BoundField>
                      </Columns>
                   </asp:GridView>
                   
               
        </asp:Panel>
    </div>
   </asp:Content>
