<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Cosmos</title>
    <?php
    include_once 'api.php';
    //işlemler hata alindigi icinb buraya alindi...
    $degerler = file_get_contents("$api_server/Products");
    $degerler = json_decode($degerler, true);
    $fiyat = 0;
    foreach ($degerler as $item) if (in_array($item["productId"], json_decode($_COOKIE["sepet"], true))) {
        $fiyat += intval($item["priceWithDiscount"]);
        // urun_sepet($item);
        //echo "<br />";
    }
    //sepet_total($fiyat);
    setcookie("sepet_fiyat", $fiyat,   time() + 86400 * 3, "/");

    include_once 'navbar/navbar.php';
    include_once 'sepet/sepet_urun.php'; ?>
</head>

<body>
    <?php
    navbar(
        array() //"hesapAdi" => "Adem PELİT ", "pp" => "icons/pp.jpg", 
    );
    ?>
    <br>
    <div class="urun-sayfa-container">
        <?php
        ?>
        <?php
        foreach ($degerler as $item) if (in_array($item["productId"], json_decode($_COOKIE["sepet"], true))) {
            urun_sepet($item);
            echo "<br />";
        }
        sepet_total($fiyat);
        ?>
        <br><br>
    </div>
</body>
<script src="index.js"></script>

</html>