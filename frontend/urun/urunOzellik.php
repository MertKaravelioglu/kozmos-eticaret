<link rel="stylesheet" href="urun/urunOzellik.css">
<?php include_once "urunCard.php" ?>
<?php function ozellik()
{ ?>
    <div class="urun-ozellik-tablo">
        <div class="ozellik-tablo-element" 
            onclick="document.querySelector('body > div.urun-sayfa-container > iframe').scrollIntoView({behavior: 'smooth', block: 'center', inline: 'center'})">
                Ürün Videosu
        </div>
        <div class="ozellik-tablo-element" 
            onclick="document.querySelector('body > div.urun-sayfa-container > div.urun-ozellikleri').scrollIntoView({behavior: 'smooth', block: 'center', inline: 'center'})">
                Ürün Özellikleri
        </div>
        <div class="ozellik-tablo-element" 
            onclick="document.querySelector('body > div.urun-sayfa-container > div.urun-yorumlar').scrollIntoView({block: 'start', inline: 'center'});setTimeout(()=>{window.scrollBy(0, -160);},1)">
                Yorumlar(⭐5)
        </div>
        <div class="ozellik-tablo-element" 
            onclick="document.querySelector('body > div.urun-sayfa-container > div.urun-benzer').scrollIntoView({behavior: 'smooth', block: 'center', inline: 'center'})">
                Benzer Ürünler
        </div>
    </div>
<?php } ?>

<?php function urunOzellik($i)
{ ?>
    <div class="urun-ozellikleri">
        <div class="urun-ozellikleri-baslik">Ürün Özellikleri:</div>
        <div class="urun-ozellikleri-icerik">
            <?php echo isset($i) ? $i : "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,
                molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum
                numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium
                optio, eaque rerum!"; ?>
        </div>
    </div>
<?php } ?>

<?php function stars($count)
{ ?>
    <div class="urun-stars">
        <?php for ($i = 0; $i < $count; $i++) { ?> <img class="urun-star-png" src="icons/yildizon.png"> <?php } ?>
        <?php for ($i = 0; $i < 5 - $count; $i++) { ?> <img class="urun-star-png" src="icons/yildizoff.png"> <?php } ?>
    </div>
<?php } ?>

<?php function yorumlar($decoded)
{ ?>
    <div class="urun-yorumlar">
        <div class="urun-yorum-title">YORUMLAR:</div>
        <?php
        for ($i = 0; $i < count($decoded); $i++) { //
        ?>
            <div class="urun-yorum" id="yorum<?php echo $decoded[$i]['id'] ?>">
                <div class="urun-yorum-top">
                    <div class="urun-ppandname">
                        <img class="user-img" src="<?php echo $decoded[$i]['pp'] ?>" width="32" height="32">
                        <div class="user-name"><?php echo $decoded[$i]['user-name'] ?></div>
                    </div>
                    <?php stars($decoded[$i]['star']); ?>
                </div>
                <div class="comment"><?php echo $decoded[$i]['comment'] ?></div>
            </div>
        <?php } ?>
    </div>
<?php }
function benzer_urunler($degerler)
{ ?>
    <div class="urun-benzer">
        <div class="urun-yorum-title">BENZER URUNLER:</div>
        <img onclick="benzerScrol(-1)" class="leftarrow" src="icons/up.png" alt="left">
        <img onclick="benzerScrol(+1)" class="rigtharrow" src="icons/up.png" alt="rigth">
        <div class="urun-benzer-alt">
            <?php foreach ($degerler as $item) urunCard($item); ?>
        </div>
    </div>
<?php }

function youtube($url)
{ ?>
    <iframe width="1000" height="500" src="<?php echo $url ?>" title="Ürün videosu" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
<?php } ?>