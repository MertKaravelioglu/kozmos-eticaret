<link rel="stylesheet" href="urun/urun.css">
<link rel="stylesheet" href="sepet/sepet_urun.css">
<?php function urun_sepet($i)
{ ?>
    <div class="urun-bilgi-container sepet-urun">
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
            <br>
            <div class="addpanel addpanel-rigth" onclick="window.location.href = './sepetisil.php?id=<?php echo isset($i['productId']) ? $i['productId'] : "-1" ?>'">
                <div class="addsmth">
                    <img src="icons/delete.png" width="32" height="32">
                    <div>ürünü çıkar</div>
                </div>

            </div>
        </div>
    </div>
<?php }
function sepet_total($i)
{ ?>
    <div class="urun-bilgi-container sepet-total">
        <h1>Total:</h1>
        <h1>$<?php echo $i ?></h1>
    </div>
    <br>
    <div class="sepet-satinal">
        <div onclick="window.location.href = './odeme.php'">Satın Al!</div>
    </div>
<?php } ?>