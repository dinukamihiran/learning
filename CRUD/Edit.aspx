<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" MasterPageFile="~/Site.Master" Inherits="CRUD.Edit" %>
 
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">  
        
    <asp:Panel ID="pnlEdit" runat="server">
      <h3> Author</h3> 
      <table>
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAge" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnSave" runat="server" Text="Save" Enabled="false" 
                    onclick="btnSave_Click"></asp:Button>
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click"></asp:Button>
            </td>
        </tr>
      </table>    
    </asp:Panel>
    
</asp:Content>
