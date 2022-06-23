<link rel="stylesheet" href="urun/urunCard.css">
<?php function urunCard($i)
{ ?>
    <div id="urun<?php echo isset($i['productId']) ? $i['productId'] : "-1 "; ?>" class="urun-card" onclick="git(<?php echo isset($i['productId']) ? $i['productId'] : "-1"; ?>)">
        <img src="<?php echo isset($i['productImage']) ? $i['productImage'] : "icons/urun.png"; ?>" class="urunFoto">
        <div class="urunInfo">
            <div class="urunInfo-left">
                <div class="urun-name"><?php echo isset($i['productName']) ? $i['productName'] : "Ürünün Adı"; ?></div>
                <div class="uruncard-categoryName"><?php echo isset($i['categoryName']) ? $i['categoryName'] : "Kategori"; ?></div>
                <div class="urun-discount">
                    <?php
                    if (isset($i['priceWithoutDiscount']) && isset($i['priceWithoutDiscount'])) {
                        $discount = (($i['priceWithoutDiscount'] - $i['priceWithDiscount']) / $i['priceWithoutDiscount']);
                        $discount = (int)($discount * 100);
                        echo "-$discount%";
                    } else echo "-33%";
                    ?>
                </div>
            </div>
            <div class="urunInfo-rigth">
                <div class="old-price">
                    <?php echo isset($i['priceWithoutDiscount']) ? "$" . $i['priceWithoutDiscount'] : "$29.99"; ?>
                </div>
                <div class="new-price">
                    <?php echo isset($i['priceWithDiscount']) ? "$" . $i['priceWithDiscount'] : "$19.99"; ?>
                </div>
                <div class="addsmth" onclick="sepeteekle(<?php echo isset($i['productId']) ? $i['productId'] : "-1" ?>);">
                    <div style="font-weight: 500;">Sepete ekle!</div>
                </div>
            </div>
        </div>
    </div>
<?php } ?>