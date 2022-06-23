<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Cosmos</title>
    <?php
    include_once 'api.php';
    include_once 'navbar/navbar.php';
    include_once 'urun/urunCard.php';
    ?>
</head>

<body>
    <?php
    navbar(array());
    ?>
    <div class="urun-container">
        <?php
        $degerler = file_get_contents("$api_server/Products");
        $degerler = json_decode($degerler, true);
        foreach ($degerler as $item) urunCard($item);
        ?>
    </div>
</body>
<script src="index.js"></script>

</html>