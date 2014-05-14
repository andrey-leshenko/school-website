<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="Server">
    גלריה
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="Server">
    <link rel="Stylesheet" href="Styles/Gallery.css" />
    
    <script src="Scripts/Gallery.js">
        // Exports: nextImage()
        //          previousImage()
        // Requires: #gallery-image
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

