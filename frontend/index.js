document.querySelector('body > .homebutton').onclick = () => {
    document.body.scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" })
}
benzerUrunIndex = 2;
benzerDiv = document.querySelector("body > div.urun-sayfa-container > div.urun-benzer > div.urun-benzer-alt")
benzerScrol = (ekle) => {
    benzerUrunIndex += ekle;
    if (benzerUrunIndex >= benzerDiv.childElementCount) benzerUrunIndex = benzerDiv.childElementCount - 1
    else if (benzerUrunIndex <= 0) benzerUrunIndex = 0;
    //[].forEach.call(benzerDiv.children, (e) => {e.style = ""})
    benzerDiv.children[benzerUrunIndex].scrollIntoView({ behavior: 'smooth', block: 'center', inline: 'center' });
    //benzerDiv.children[benzerUrunIndex].style = "background-color: rgb(230, 230, 230);margin: 10px;padding: 10px;";
}

gidilebilir = true;
sepeteekle = (e) => {
    gidilebilir = false;
    window.location.href = './sepeteekle.php?id=' + e;
    setTimeout(() => {
        gidilebilir = true;
    }, 0.05);
}

git = (url) => {
    if (gidilebilir) {
        window.location.href = "./urun.php?id=" + url
    }
}