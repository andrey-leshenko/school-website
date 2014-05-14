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