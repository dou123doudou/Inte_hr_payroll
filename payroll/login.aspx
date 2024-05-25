<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="IntegratedHrPayroll.payroll.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            font-family: glyphicons-halflings-regular.svg;
        }

        .login-container {
            width: 300px;
            padding: 50px;
            border: 3px solid #ccc;
            border-radius: 10px;
            background-color: #f9f9f9;
        }

        .form-field {
            margin-bottom: 1px;
            padding: 1px;


        }

        .form-field label {
            display: block;
            margin-bottom: auto;
        }
        
        .form-field input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }

        .login-container button {
            width: 100%;
            padding: 10px;
            border: none;
            border-radius: 3px;
            background-color: #5c87b2;
            color: white;
            cursor: pointer;
        }
        
        .login-container button:hover {
            background-color: #4a76a8;
        }
    </style>

</head>
<body>`
    <div class="login-container">
        <img src="assets/img/logo.png" style="display: block;margin-left:80px; margin-bottom: 20px; width: auto; max-width: auto; height: auto;justify-content: center;" />
    <form id="form1" runat="server">
        <div class="form-field">
            <label for ="username">Username : </label>
            <asp:TextBox ID ="username" runat="server"></asp:TextBox>
            <div class="form-field">
            <label for ="password">Password : </label>
            <asp:TextBox ID ="password" TextMode="Password" runat="server"></asp:TextBox>
            <div class="form-field">
            <asp:Button ID="submit" runat="server" Text="Login" OnClick="Submit_Click" />
        </div>
    </form>
</body>
</html>
