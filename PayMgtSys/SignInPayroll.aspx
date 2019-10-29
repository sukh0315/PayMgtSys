<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInPayroll.aspx.cs" Inherits="PayMgtSys.SignInPayroll" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <style type="text/css">
        .login-form {
            width: 340px;
            margin: 50px auto;
        }

            .login-form form {
                margin-bottom: 15px;
                background: #f7f7f7;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
                padding: 30px;
            }

            .login-form h2 {
                margin: 0 0 15px;
            }

        .form-control, .btn {
            min-height: 38px;
            border-radius: 2px;
        }

        .btn {
            font-size: 15px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <div class="login-form">
        <form class="form-horizontal" runat="server">
            <h2 class="text-center">Log in</h2>
            <div class="form-group">
                <asp:TextBox ID="Username" class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="password" class="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="loginBtn" runat="server" class="btn btn-primary" Text="Login" OnClick="signInBtn_Click" />
            </div>
            <div class="clearfix">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
