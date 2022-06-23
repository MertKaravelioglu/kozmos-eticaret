<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Cosmos</title>
    <?php
    if (!isset($_GET['id'])) {
        echo "<meta http-equiv='refresh' content='0; url=/'>";
        exit();
    }
    include_once 'api.php';
    include_once 'navbar/navbar.php';
    include_once 'urun/urun.php';
    include_once 'urun/urunOzellik.php';
    ?>
</head>

<body>
    <?php
    navbar(array());
    ?>
    <div class="urun-sayfa-container">
        <br>
        <?php
            $degerler = file_get_contents("$api_server/Products/" . $_GET['id']); //httpPost($api_server . "/urun", array("id" => 5));
            $degerler = json_decode($degerler, true);
            urun($degerler);
            echo "<br>";
            ozellik();
            echo "<br>";
            //isset($degerler['youtubeUrl']) ? $degerler['youtubeUrl'] : "Hakkında NULL"
            youtube("https://www.youtube.com/embed/QcfhPVmWjwQ");
            echo "<br>";
            urunOzellik(isset($degerler['productDescription']) ? $degerler['productDescription'] : "Hakkında NULL");
            echo "<br>";
            //yorumlar(json_decode(file_get_contents("json/yorum.json"), true));
            //echo "<br>";
            $benzerler = file_get_contents("$api_server/Products");
            
            $benzerler = json_decode($benzerler, true);
            benzer_urunler($benzerler);
        ?>

    </div>
</body>
<script src="index.js"></script>

</html>