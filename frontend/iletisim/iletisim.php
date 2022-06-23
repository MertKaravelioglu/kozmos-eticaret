<link rel="stylesheet" href="login/login.css">
<?php
function iletisim_form()
{
?>
    <div class="form_container iletisim_container">
        <div class="login_baslik">Bizimle İletişime Geçin!</div>
        <?php if (!isset($_COOKIE["token"])) { ?>
            <div>Mesaj gönderebilmek için <a href="/login.php">Giriş yapın!</a></div>
        <?php } else { ?>
            <div class="login_mesaj"><?php if (isset($_GET["msg"])) echo $_GET["msg"]; ?></div>
            <form class="iletisim-form" action="./iletisim/ilet.php" name="signin" method="post">
                <input type="text" name="title" placeholder="Konu...">
                <textarea type="text" name="text" placeholder="İçerik..."></textarea>

                <input type="submit" name="submit" value="gönder!">
            </form>
        <?php } ?>
    </div>
<?php
}
function satinalma_form()
{
?>
    <div class="form_container iletisim_container">
        <div class="login_baslik">Ödeme bilgilerini giriniz!</div>
        <div><strong>Ödenecek tutar:</strong>
            <?php if (isset($_COOKIE["sepet_fiyat"])) echo "$".$_COOKIE["sepet_fiyat"]; else echo "fiyat nanay"; ?>
        </div>
        <?php if (!isset($_COOKIE["token"])) { ?>
            <div>Mesaj gönderebilmek için <a href="/login.php">Giriş yapın!</a></div>
        <?php } else { ?>
            <div class="login_mesaj"><?php if (isset($_GET["msg"])) echo $_GET["msg"]; ?></div>
            <form class="iletisim-form" action="./sepet/satinal.php" name="signin" method="get">
                <input type="text" name="credit_card" placeholder="4000 1234 5678 9010">
                <textarea type="text" name="adress" placeholder="adresinizi girin..."></textarea>

                <input type="submit" name="submit" value="Satın Al!">
            </form>
        <?php } ?>
    </div>
<?php
}
?>