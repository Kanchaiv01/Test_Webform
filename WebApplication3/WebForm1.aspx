<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="description" runat="server"></asp:TextBox>
                    </td>
                </tr>

                

                <tr>
                    <td>CreatBy</td>
                    <td>
                        <asp:TextBox ID="createby" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan ="2" style="color:red;">สำหรับการ Delete และ Update เท่านั้น</td>
                </tr>

                    
                
                <tr>
                    <td>ID</td>
                    <td>
                        <asp:DropDownList ID="listid" runat="server" AutoPostBack="true" ></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td colspan ="2" style="color:red; text-align:center">******************</td>
                </tr>

                <tr>
                  <td colspan ="2" class="auto-style1" style="text-align:center">
                      <asp:Button ID="insert" runat="server" Text="Insert" OnClick="insert_Click"/>
                      <asp:Button ID="delete" runat="server" Text="Delete" OnClick="delete_Click"/>
                      <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click"/>
                  </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="WorningNotInputId" runat="server" Text="ต้องเลือก ID ที่ต้องการทำรายการ" Font-Size="12px" Visible="false" style="color:red;" ></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
