<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CityEntryUI.aspx.cs" Inherits="WorldsCountryInfoApp.UI.CityEntryUI" MasterPageFile="~/Site.Master" ValidateRequest="false"%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
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
 <div>
        <asp:Panel ID="Panel1" runat="server" GroupingText="City Entry">
          <table>
          <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></td>
            <td>
                <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox></td>
          </tr>
           <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="About"></asp:Label></td>
            <td>
                <asp:TextBox ID="aboutTextBox" runat="server" Height="87px" ClientIDMode="Static"
                         TextMode="MultiLine" Width="257px"></asp:TextBox></td>
          </tr>
           <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Population"></asp:Label></td>
            <td>
                <asp:TextBox ID="populationTextBox" runat="server"></asp:TextBox></td>
          </tr>
           <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Location"></asp:Label></td>
            <td>
                <asp:TextBox ID="locationTextBox" runat="server"></asp:TextBox></td>
          </tr>
           <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Weather"></asp:Label></td>
            <td>
                <asp:TextBox ID="weatherTextBox" runat="server"></asp:TextBox></td>
          </tr>
           <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Country"></asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownList" runat="server">
                </asp:DropDownList>
            </td>
          </tr>
           <tr>
            <td>
                <asp:Button ID="saveButton" runat="server" Text="Save" 
                    onclick="saveButton_Click" /></td>
            <td>
                <asp:Button ID="cancelButton" runat="server" Text="Cancel" 
                    onclick="cancelButton_Click" /></td>
          </tr>
          <tr>
             <td colspan="2"><asp:Label ID="statusLabel" runat="server" Text="" style="color:green"></asp:Label></td>
              
          </tr>
          </table>
            <asp:GridView ID="GridView" runat="server"  
                onrowdatabound="GridView_RowDataBound" AutoGenerateColumns="False" 
                Width="564px">
                
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Sl no"> 
                    </asp:BoundField>
                    <asp:BoundField DataField="City_name" HeaderText="Name"> 
                    </asp:BoundField>
                    <asp:BoundField DataField="About_city" HeaderText="About" HtmlEncode="False"> 
                    </asp:BoundField>
                    <asp:BoundField DataField="No_of_dwellers" HeaderText="Population"> 
                    </asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location"> 
                    </asp:BoundField>
                    <asp:BoundField DataField="Whather" HeaderText="Weather"> 
                    </asp:BoundField>
                    <asp:BoundField DataField="Country_name" HeaderText="Country"> 
                    </asp:BoundField> 
                </Columns>
                
            </asp:GridView>
        </asp:Panel>
    </div>
  
</asp:Content>