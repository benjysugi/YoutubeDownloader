<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouTube.aspx.cs" Inherits="YoutubeDownloader.YouTube" %>

<!DOCTYPE html>

<html>
<head>
    <script src="../files/scripts/bootstrap/bootstrap.min.js"></script>
    <%--<link rel="stylesheet" href="../files/stylesheets/bootstrap.min.css">--%>
    <link rel="stylesheet" href="../files/stylesheets/common.css">

    <link rel="icon" type="image/x-icon" href="../files/neofavicon/Volume.ico">

    <script src="../files/scripts/page/uploader_funcs.js"></script>

    <meta content="YouTube Downloader" property="og:title" />
    <meta content="rollup rollup download your youtube videos here" property="og:description" />
    <meta content="#1B1B2F" data-react-helmet="true" name="theme-color" />

    <meta charset="utf-8">
    <title>YouTube Downloader - ABBWP</title>
</head>
<body>
    <div class="header">
        <div class="mx-auto translate-y-[0.15em]">
            <a href="/">
                <span>
                    <img src="/files/img/full.png" width="95">
                </span>
            </a>
        </div>
        <div class="links">
            <a class="selected" href="/YouTube.aspx">YouTube</a>
            <a href="/TikTok.aspx">TikTok</a>
            <a href="/Pinterest.aspx">Pinterest</a>
            <a href="/Instagram.aspx">Instagram</a>
            <div class="ml-auto flex">
                <a href="/Login.aspx">Log In</a>
            </div>
        </div>
        <div class="bg-overlay"></div>
    </div>

    <div id="banner" class="mt-16 mb-12 py-3 px-24 text-center backdrop-blur-md bg-zinc-700">The revamp is still in progress so some stuff might still be buggy - 2023/07/20 18:11</div>

    <div class="flex flex-col items-center">
        <div class="flex grow flex-col items-center text-center transition-all duration-1000">
            <div class="z-10 text-2xl font-thin drop-shadow-md" style="padding-bottom: 10px">YouTube</div>
            <center>
                <form>
                <input type="text" id="yt_uri" name="yt_uri"><br>
                <br>
                <div>
                    <button class="m_button selected" id="inp" onclick="return prc_youtube()">Video</button>
                    <button class="m_button selected" id="inp2" onclick="return prc_youtube_mp3()">Audio</button>
                </div>
            </form> 
            </center>
        </div>
    </div>
</body>
</html>
