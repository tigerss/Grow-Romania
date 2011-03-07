<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Facebook2.aspx.cs" Inherits="Facebook2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="http://www.facebook.com/2008/fbml">
<head runat="server">
    <script src="http://static.ak.connect.facebook.com/js/api_lib/v0.4/FeatureLoader.js.php" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function fct() {
            alert('Post was not published.');
            window.location("http://www.facebook.com/dialog/feed?app_id=126628107409555&redirect_uri=http://localhost:51171/ASPGrowRomania/Facebook2.aspx");
           // document.location("http://www.facebook.com/dialog/feed?app_id=126628107409555&redirect_uri=http://localhost:51171/ASPGrowRomania/Facebook2.aspx");
            alert('fg');
        }
      </script>
    <form id="form1" runat="server">
    <div>
       <fb:login-button onlogin="fct()" perms="publish_stream"></fb:login-button>
    </div>
  
      <script type="text/javascript">
          FB.init("d847e8b9172df9a286ee551bdd4cf6cb", "xd_receiver.htm");
        //  FB.ui("126628107409555", "www.google.com");
</script>
  <script src="http://connect.facebook.net/en_US/all.js">
      </script>
      
      <script>
          FB.init({
              appId: '126628107409555', cookie: true,
              status: true, xfbml: true

          });
         FB.ui({ method: 'feed',
                  name: 'Facebook Dialogs',
                  link: 'http://developers.facebook.com/docs/reference/dialogs/',
                  picture: 'http://fbrell.com/f8.jpg',
                  caption: 'Reference Documentation',
                  description: 'Dialogs provide a simple, consistent interface for applications to interface with users.',
                  message: 'Facebook for Websites is super-cool',
                  alert("ok")
              },
          function (response) {
              if (response && response.post_id) {
                  alert('Post was published.');
              } else {
                  alert('Post was not published.');
              }
          });
          
      </script>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </form>
  
      </body>

</html>
