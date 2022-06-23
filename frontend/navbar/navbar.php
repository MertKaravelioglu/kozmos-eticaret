<link rel="stylesheet" href="navbar/navbar.css">
<link rel="icon" href="icons/icon.png" />
<?php
function navbar($i)
{ ?>
    <div class="navbar">
        <div class="navtop">
            <form class="aramakutusu" action="/arama.php">
                <input type="text" placeholder="Ara!" name="sorgu" id="sorgu">
                <div class="find" type="submit" onClick="document.forms[0].submit();">
                    <img src="icons/find.png" alt="ara!">
                </div>
            </form>
            <img src="icons/cosmos.png" class="logo">
            <div class="navtopleft">
                <div class="hesap" <?php echo isset($_COOKIE["email"]) ? "" : "onclick=\"window.location.href = './login.php'\""; ?>>
                    <img src="<?php echo array_key_exists('pp', $i) ? $i['pp'] : "icons/pp.png"; ?>" alt="ara!" width="32" height="32">
                    <div class="hesapAdi"><?php echo isset($_COOKIE["email"]) ? $_COOKIE["email"] : "Giriş Yapın!";/*echo array_key_exists('hesapAdi', $i) ? $i['hesapAdi'] : "Giriş Yapın!";*/ ?></div>
                </div>
                <div class="hesap" onclick="window.location.href = './sepet.php'">
                    <img src="icons/sepet.png" alt="ara!" width="32" height="32">
                    <div>
                        Sepetim(<?php
                                echo isset($_COOKIE["sepet"]) ? count(json_decode($_COOKIE["sepet"]), true) : "0";
                                ?>)
                    </div>
                </div>
                <?php if (isset($_COOKIE["email"])) { ?>
                    <div class="hesap" onclick="window.location.href = './login/logout.php'">
                        <img src="icons/logout.png" alt="ara!" width="32" height="32">
                        <div>
                            Çıkış Yap!
                        </div>
                    </div>
                <?php } ?>
            </div>
        </div>
        <div class="slice"></div>
        <div class="navbottom">
            <div class="navitem" onclick="window.location.href = './'">Anasayfa</div>
            <select onChange="window.location.href = './kategoriler.php?id='+this.options[this.selectedIndex].value" class="navitem">
                <option value="Kategoriler">Kategoriler</option>
                <?php
                $api_server = 'http://kozmosapi-001-site1.itempurl.com/api';
                $Categories = file_get_contents("$api_server/Categories");
                $Categories = json_decode($Categories, true);
                foreach ($Categories as $item) {
                ?>
                    <option value="<?php echo isset($item['categoryId']) ? $item['categoryId'] : "null"; ?>">
                        <?php echo isset($item['categoryName']) ? $item['categoryName'] : "null"; ?>
                    </option>
                <?php } ?>
            </select>
            <!--
            <div class="navitem" onclick="window.location.href = './kategoriler.php'">Kategoriler</div>
            -->
            <div class="navitem" onclick="window.location.href = './urunler.php'">Ürünler</div>
            <div class="navitem" onclick="window.location.href = './iletisim.php'">iletişim</div>
        </div>
        <div class="slice"></div>

    </div>
    <img class="homebutton" src="icons/up.png" alt="ara!" width="32" height="32">
    <!--
        <img class="buybutton" src="icons/up.png" alt="ara!" width="32" height="32">
    -->
<?php } ?>