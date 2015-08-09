<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Read.aspx.cs" MasterPageFile="~/Site.Master" Inherits="CRUD.Read" %>
 
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">  
    <asp:Panel ID="pnlRead" runat="server">        
        <asp:GridView ID="grdAuthors" runat="server" AutoGenerateColumns="False" DataKeyNames="a_id"
            EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="a_id" HeaderText="Author ID" ReadOnly="True"  />
                <asp:BoundField DataField="a_name" HeaderText="Author Name" />
                <asp:BoundField DataField="a_address" HeaderText="Author Address" />
                <asp:BoundField DataField="age" HeaderText="Author Age" />
                <asp:HyperLinkField Text="View" DataNavigateUrlFields="a_id" DataNavigateUrlFormatString="~/Edit.aspx?Id={0}" />
            </Columns>
        </asp:GridView>
    </asp:Panel>  
    
    <asp:Panel ID="pnlNew" runat="server">
      <h3> Create New Author</h3> 
      <table>
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmit" runat="server" Text="Save" 
                    onclick="btnSubmit_Click" ></asp:Button>
            </td>
        </tr>
      </table>    
    </asp:Panel>
    <asp:Panel ID="pnlDefault" runat="server">
        <table>
            <tr>
                <td>
                    <asp:LinkButton ID="btnNew" name="btnNew" runnat="server" Text="New" 
                    runat="server" onclick="btnNew_Click"></asp:LinkButton>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:LinkButton ID="btnAll" name="btnAll" runnat="server" Text="All" 
                    runat="server" onclick="btnAll_Click" ></asp:LinkButton>
                </td>
            </tr>
        </table>  
    </asp:Panel>
</asp:Content>
