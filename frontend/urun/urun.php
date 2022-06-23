<link rel="stylesheet" href="urun/urun.css">
<?php function urun($i)
{ ?>
    <div class="urun-bilgi-container">
        <div class="urunleft">
            <img class="currentimg" src="<?php echo isset($i['productImage']) ? $i['productImage'] : "icons/urun.png"; ?>" alt="ürün resmi">
            <!--
            <div class="subimgs">
                <img class="leftarrow" src="icons/up.png" alt="left">
                <img class="rigtharrow" src="icons/up.png" alt="rigth">
                <img class="subimg selected" id="img1" src="<?php echo isset($i['productImage']) ? $i['productImage'] : "icons/urun.png"; ?>" alt="ürün resmi">
                <img class="subimg" id="img2" src="<?php echo isset($i['productImage']) ? $i['productImage'] : "icons/urun.png"; ?>" alt="ürün resmi">
                <img class="subimg" id="img3" src="<?php echo isset($i['productImage']) ? $i['productImage'] : "icons/urun.png"; ?>" alt="ürün resmi">
            </div>
            -->
        </div>
        <div class="urunrigth">

            <div class="urun-ad-kategori">
                <div class="urunAdi">
                    <?php echo isset($i['productName']) ? $i['productName'] : "Ürünün Adı"; ?>
                </div>
                <div class="urun-categoryName">
                    <?php echo isset($i['categoryName']) ? $i['categoryName'] : "Kategori"; ?>
                </div>
            </div>
            <div class="urunAciklama">
                <?php echo isset($i['productDescription']) ? $i['productDescription'] :
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,
                molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum
                numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium
                optio, eaque rerum!"; ?>
            </div>
            <br>
            <div class="IndirimsizFiyat"><?php echo isset($i['priceWithoutDiscount']) ? "$" . $i['priceWithoutDiscount'] : "$0.00"; ?></div>
            <div class="fiyat"><?php echo isset($i['priceWithDiscount']) ? "$" . $i['priceWithDiscount'] : "$0.00"; ?></div>
            <br><br>
            <div class="addpanel">
                <?php if ($i['stock'] == 0) { ?>
                    <div class="addsmth">
                        <img src="icons/addchart.png" width="32" height="32">
                        <div>Stokta yok :(</div>
                    </div>
                <?php } else { ?>
                    <div class="addsmth">
                        <img src="icons/addchart.png" width="32" height="32">
                        <div>Stokta <?php echo $i['stock']; ?> adet var</div>
                    </div>
                    <div class="addsmth" onclick="window.location.href = './sepeteekle.php?id=<?php echo isset($i['productId']) ? $i['productId'] : "-1" ?>'">
                        <img src="icons/addchart.png" width="32" height="32">
                        <div>Sepete ekle!</div>
                    </div>
                <?php } ?>
                <!--
                <div class="addsmth">
                    <img src="icons/addfav.png" width="32" height="32">
                    <div>favorilere ekle!</div>
                </div>
                <div class="addsmth">
                    <img src="icons/bell.png" width="32" height="32">
                    <div>indirim alarmı!</div>
                </div>
                -->
            </div>
        </div>
    </div>
    <div>
    </div>
<?php } ?>