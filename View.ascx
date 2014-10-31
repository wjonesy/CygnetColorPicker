<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.CygnetColorPicker.View" %>

<link rel="stylesheet" href="<%= ModulePath %>Resources/js/colorPicker/spectrum.css" />

<a href="#" class="toggle-nav btn btn-lg btn-default"><i class="fa fa-cogs"></i>&nbsp;Customise Colors</a>



<div id="siteMenu">
    <a href="#" class="close-nav btn btn-lg btn-default"><i class="fa fa-caret-square-o-left"></i>&nbsp;Close</a>
    <h2>Customise Colours</h2>

    <%--Background Color--%>
    <asp:Label ID="lblBackgroundColor" runat="server" Text="Background Color:"></asp:Label>
    <asp:TextBox ID="backgroundcolor" runat="server" CssClass="colorPicker"></asp:TextBox>
    <asp:HiddenField ID="hidbackgroundcolor" runat="server" />
    <br />
    <%--Content background color--%>
    <asp:Label ID="lblmainbackgroundcolor" runat="server" Text="Content Background Color:"></asp:Label>
    <asp:TextBox ID="txtmainbackgroundcolor" runat="server" CssClass="colorPicker"></asp:TextBox>
    <asp:HiddenField ID="hidmainbackgroundcolor" runat="server" />
    <br />
     <%--textColor color--%>
    <asp:Label ID="lbltextColor" runat="server" Text="Text Color:"></asp:Label>
    <asp:TextBox ID="txttextColor" runat="server" CssClass="colorPicker"></asp:TextBox>
    <asp:HiddenField ID="hidtextColor" runat="server" />
    <br />


    <br />
    <asp:Button ID="btnSubmitColors" runat="server" Text="Save Colors" CssClass="btn btn-lg btn-default" OnClick="btnSubmitColors_Click" />
</div>

<script src="<%= ModulePath %>/Resources/js/colorPicker/spectrum.js"></script>
<script>
   

    //Content Background Color
    var mainbackgroundcolorinit = $(".mainbackgroundcolor").css("backgroundColor");
    $("#<%=txtmainbackgroundcolor.ClientID %>").spectrum({
        color: $(".mainbackgroundcolor").css("background"),
        clickoutFiresChange: true,
        move: function (color) {
            var mainbackgroundcolor = color.toHexString(); // #ff0000
            $(".mainbackgroundcolor").css("background", mainbackgroundcolor);
            $(<%= hidmainbackgroundcolor.ClientID %>).val(mainbackgroundcolor);
        }
    });

 //Background Color
    var backgroundcolorinit = $(".background-color").css('background');
    $("#<%=backgroundcolor.ClientID %>").spectrum({
        color: backgroundcolorinit,
        clickoutFiresChange: true,
        move: function (color) {
            var backgroundcolor = color.toHexString(); // #ff0000
            $(".background-color").css("background", backgroundcolor);
            $(<%= hidbackgroundcolor.ClientID %>).val(backgroundcolor);
        }
    });

    //Text Color
    var textColorinit = "red";
    $("#<%=txttextColor.ClientID %>").spectrum({
        color: textColorinit,
        clickoutFiresChange: true,
        move: function (color) {
            var textColor = color.toHexString(); // #ff0000
            $(".textColor,h1,h2,h3,h4,h5,h6,p,ul,ul li,ol,ol li,table,tr,td").css("color", textColor);
            $(<%= hidtextColor.ClientID %>).val(textColor);
        }
    });
</script>
