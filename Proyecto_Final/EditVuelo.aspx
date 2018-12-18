<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditVuelo.aspx.cs" Inherits="EditVuelo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        
            <html>
	<head>
		<title>Generic - Phantom by HTML5 UP</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="assets/css/main.css" />
		<!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
	</head>
	<body>
		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Header -->
					<header id="header">
						<div class="inner">

							<!-- Logo -->
								<a href="index.aspx" class="logo">
									<span class="symbol"><img src="images/travel.png" alt="" /></span><span class="title">V-Vuelos</span>
								</a>

							<!-- Nav -->
								<nav>
									<ul>
										<li><a href="#menu">Menu</a></li>
									</ul>
								</nav>

						</div>
					</header>

				<!-- Menu -->
					<nav id="menu">
						<h2>Menu</h2>
						<ul>
							<li><a href="IndexAdmin.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>
            <!-- Main -->
                <asp:Panel ID="main" runat="server">
                    <asp:Panel ID="Panel1" class="inner" runat="server">
                        <h1>Editar Vuelo</h1>
                        <div class="auto-style1">
                            <h2>Codigo:<asp:Label ID="lblcodigo" runat="server" Text="Label"></asp:Label>
                            </h2>&nbsp;&nbsp; 
                            <br />
                        </div>
                        <div class="field first half">
                            <h2>Estado:<asp:DropDownList ID="dplEstado" runat="server">
                                </asp:DropDownList>
                            </h2>
                                <br />
                        </div>
                         <div class="field">
                        &nbsp;<asp:Button ID="btnUpload" runat="server"  Text="Modificar" class="special" OnClick="btnUpload_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server"  Text="Cancelar" class="special" OnClick="btnCancel_Click" />
                            <br />
                                </div>
                            </div>
                            &nbsp;<br /> &nbsp;</asp:Panel>
                </asp:Panel>

				<!-- Footer -->
                
			</div>

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
			<script src="assets/js/main.js"></script>

       

	</body>
</html>

    </form>



    <footer align="center">

 <div id="google_translate_element"></div><script type="text/javascript">
function googleTranslateElementInit() {
  new google.translate.TranslateElement({pageLanguage: 'es', includedLanguages: 'de,en,es,it', layout: google.translate.TranslateElement.InlineLayout.SIMPLE}, 'google_translate_element');
}
</script><script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
    <style type="text/css">
		.goog-te-banner-frame.skiptranslate{display:none!important;}
		body{top:0px!important;}
		.auto-style1 {
            left: 0px;
            top: 0px;
            height: 94px;
        }
		</style>
</footer>

</body>
</html>