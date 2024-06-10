<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Newspaper_Hub.aspx.vb" Inherits="Enterprise_Village_2._0.Newspaper_Hub" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;" />

    <title>EV Newspaper Hub</title>

    <link href="~/css/Styles.StudentPages.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body class="Newspaper_Hub_Body">
    <form autocomplete="off"  id="Account_Summary_Form" runat="server">

        <%--Content--%>
        <div id="Site_Wrap_Fullscreen">
            <div>
                <h1 style="font-size: xx-large; text-decoration: underline; font-weight: bold;">Enterprise Village Newspaper Hub</h1>

                <h4>Select Visit Date:</h4>
                <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" CssClass="textbox" AutoPostBack="true"></asp:TextBox>

                <div id="articles_div" runat="server" visible="false">
                    <h4>Showing articles for 
                        <asp:Label ID="schoolName_lbl" runat="server" Text="" Font-Italic="true" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                        on 
                        <asp:Label ID="visitDate_lbl" runat="server" Font-Size="X-Large" Font-Italic="true" ForeColor="Black"></asp:Label>
                    </h4>

                    <asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>

                    <%--Confirm Deletion--%>
                    <div id="deletionConfirm_div" runat="server" visible="false">
                        <h4>Type 'Delete' to confirm your deletion of '<a id="articleName_a" runat="server"></a>.docx'</h4>
                        <asp:TextBox ID="confirmDelete_tb" runat="server"></asp:TextBox>&ensp;<asp:Button ID="delete_btn" runat="server" Text="Delete" CssClass="button3" />&ensp;<asp:Button ID="cancel_btn" runat="server" Text="Cancel" CssClass="button3" />
                    </div>

                    <%--File Gridview--%>
                    <h5 style="font-size: large;">Article Downloads</h5>
                    <asp:GridView ID="articles_dgv" runat="server" AutoGenerateColumns="false" EmptyDataText="No files uploaded" Font-Size="Medium" CellPadding="5" AlternatingRowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="#99CCFF" />
                            <Columns>
                                <asp:BoundField DataField="Text" HeaderText="File Name (Upload Date)" />
                                <asp:TemplateField HeaderText="Download File">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="DownloadFile"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                     </asp:GridView>                     
                </div>
            </div>
        </div>

        <asp:HiddenField ID="visitID_hf" runat="server" />
        <asp:HiddenField ID="schoolName_hf" runat="server" />
        <asp:HiddenField ID="visitDate_hf" runat="server" />
        <asp:HiddenField ID="articleName_hf" runat="server" />

        <script>
            function popup() {
                let text;
                let pswd = prompt("Please enter the password to delete the article:", "");
                if (pswd == "gsi123") {
                    document.getElementById("password_lbl").innerHTML = "Yes"
                } else {
                    document.getElementById("error_lbl").innerHTML = "Password is incorrect. Please ask an Enterprise Village staff member for assistance.";
                }
            }
        </script>
    </form>
</body>
</html>
