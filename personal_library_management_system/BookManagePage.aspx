<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookManagePage.aspx.cs" Inherits="personal_library_management_system.BookManagePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Books</title>
    <style>
        .borrowed-books-div {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>All Books: </h2>
            <br />
            <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewBooks_RowCommand">
                <Columns>
                    <asp:BoundField DataField="BookID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("BookID") %>' Text="Update" />
                            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("BookID") %>' Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="ButtonAdd" runat="server" Text="Add New Book" OnClick="ButtonAdd_Click" />
        </div>
        <div class="borrowed-books-div">
            <h2>Borrowed Books Details</h2>
            <asp:GridView ID="GridViewBorrowedBooks" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="BookID" HeaderText="Book ID" ReadOnly="True" />
                    <asp:BoundField DataField="FriendName" HeaderText="Friend Name" />
                    <asp:BoundField DataField="BorrowDate" HeaderText="Borrow Date" />
                    <asp:BoundField DataField="DaysBorrowed" HeaderText="Days Borrowed" />
                </Columns>
            </asp:GridView>
        </div>

        <br />
        <br />
        
        <asp:Button ID="btnLogout" runat="server" Text="Go Back" OnClick="BtnLogout_Click" />
    </form>
</body>
</html>
