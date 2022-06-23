<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Cosmos</title>
    <?php
    include_once 'navbar/navbar.php';
    include_once 'api.php'; ?>
</head>

<body>
    <?php
    navbar(
        array() //"hesapAdi" => "Adem PELİT ", "pp" => "icons/pp.jpg", 
    );
    ?>
    <br><br><br><br><br>
    <?php
    $degerler = file_get_contents("$api_server/SiteInfo");
    $degerler = json_decode($degerler, true);
    /*
    foreach ($_COOKIE as $key => $value) {
        echo "$key: $value<br />";
    }*/
    ?>
    <br><br><br><br><br>
    <div class="welcome">
        <?php echo isset($degerler["siteName"]) ? $degerler["siteName"] : "Hoşgeldiniz!" ?>
    </div>
    <div style="display: flex; justify-content: center;">
        <?php echo isset($degerler["description"]) ? $degerler["description"] : "!" ?>
    </div>
</body>
<script src="index.js"></script>

</html>