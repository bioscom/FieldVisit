<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_Lean_Tests_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../Scripts/jquery-2.0.3.js"></script>
    <script type="text/javascript">
        function ShowRegionsInfo() {
            var pageUrl = '<%=ResolveUrl("../../../WebService/wsJQueryDBCall.asmx")%>'

            $.ajax({
                type: "POST",
                url: pageUrl + "/GetUsersByFirstLastName",
                data: "{'UserName':'" + $('#<%=txtUserName.ClientID%>').val() + "'}",
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: OnSuccessCall,
             error: OnErrorCall
         });
     }

     function OnSuccessCall(response) {

         var oUsers = response.d
         var ddlTest = $('#<%=ddlTest.ClientID%>').empty();
         $.each(oUsers, function (index, item) {

             ddlTest.append($("<option value = '" + item.m_iUserId + "'>" + item.m_sFullName + "</option>"));

         });
     }

     function OnErrorCall(response) {
         alert(response.status + " " + response.statusText);
     }
    </script>


    <%--<script type = "text/javascript">

    $(document).ready(function () {
            $('#<%=btnGetMsg.ClientID%>').click(function () {

                var txtcountry = $('#<%=txtUserName.ClientID%>').val();
                var pageUrl = '<%=ResolveUrl("../../../WebService/wsJQueryDBCall.asmx")%>'

                $.ajax({
                    type: "POST",
                    url: pageUrl + "/GetUsersByFirstLastName",
                    data:" {country: '"+txtcountry+"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var country = response.d
                        var ddlTest =  $('#<%=ddlTest.ClientID%>').empty();
                        $.each(country, function (index, item) {
                             
                            ddlTest.append($("<option value= + '"item.m_iUserId"'+ >" + '" item.m_sFullName "'+ "</option>"));

                        });
                    },
                    error: function (response) {
                        alert(response.status);

                    }
                });
                return false;
            });
        
        });

</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>JQuery DB Call to Retrieve data based on user Criteria </h2>
    <b>Retrieve Users based on First or Last name</b><table>
        <tr>
            <td>Enter First or Last Name:</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Text="" Width="150px"></asp:TextBox>

    <asp:Button ID="btnGetMsg" runat="server" Text="Find..." OnClientClick="ShowRegionsInfo();return false;" Width="50px" />

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlTest" runat="server" Width="200px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>

                &nbsp;</td>
        </tr>
    </table>

    </asp:Content>

