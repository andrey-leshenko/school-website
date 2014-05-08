<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="Server">
    גלריה
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <style>
        body {
            background-color: #282828;
        }

        .gallery-wapper {
            width: 90%;
            margin: auto;
        }

        #gallery-image {
            width: 100%;
        }

        .gallery-button {
            width: 49%;
            line-height: 1.5em;
            background-color: #000;
            text-align: center;
            color: #999999;
            font-size: 2em;
            cursor: pointer;
            /* Disable selection */
            -webkit-touch-callout: none;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        #gallery-left {
            float: left;
        }

        #gallery-right {
            float: right;
        }

        #controls-wrapper {
            background-color: #a3a3a3;
            height: 3em;
        }
    </style>

    <script>
        var imageCount = 4;
        var currImage = 1;

        function nextImage() {
            currImage++;
            if (currImage > imageCount)
                currImage = 1;
            loadImage();
        }

        function previousImage() {
            currImage--;
            if (currImage == 0)
                currImage = imageCount;
            loadImage();
        }

        function loadImage() {
            document.getElementById("gallery-image").setAttribute("src", "Images/Gallery/img_" + currImage + ".png");
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" runat="Server">
    גלריה
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" runat="Server">
    <div class="gallery-wapper">
        <img id="gallery-image" src="Images/Gallery/img_1.png" />

        <div id="controls-wrapper">
            <span id="gallery-left" class="gallery-button" onclick="previousImage()">◄
            </span>
            <span id="gallery-right" class="gallery-button" onclick="nextImage()">►
            </span>
        </div>
    </div>
</asp:Content>

