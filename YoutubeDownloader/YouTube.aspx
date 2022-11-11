<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouTube.aspx.cs" Inherits="YoutubeDownloader.YouTube" %>

<!DOCTYPE html>

<html>
	<head>
		<script src="../files/scripts/bootstrap/bootstrap.min.js"></script>
		<link rel="stylesheet" href="../files/stylesheets/bootstrap.min.css">
		<link rel="stylesheet" href="../files/stylesheets/common.css">

		<link rel="stylesheet" href="../files/stylesheets/uploader.css">
		
		<link rel="icon" type="image/x-icon" href="../files/neofavicon/Volume.ico">
		
		<script src="../files/scripts/page/uploader_funcs.js"></script>

		<meta content="YouTube Downloader" property="og:title" />
		<meta content="rollup rollup download your youtube videos here" property="og:description" />
		<meta content="#1B1B2F" data-react-helmet="true" name="theme-color" />
		
		<meta charset="utf-8">
		<title>YouTube Downloader - ABBWP</title>
	</head>
	<body>
		<nav class="navbar navbar-expand-lg navbar-light bg-dark">
  			<div class="collapse navbar-collapse" id="navbarNav">
    			<ul class="navbar-nav">
      				
			</div>
		</nav>
		
		<div style="" id="outer">
			<p class="txt_center">YouTube Link:</p>
			<form>
  				<input type="text" id="yt_uri" name="yt_uri"><br><br>
  				<button id="inp" onClick="return prc_youtube()">Download</button>
			</form>
		</div>
	</body>
</html>