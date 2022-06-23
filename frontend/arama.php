<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Cosmos</title>
    <?php
    if (!isset($_GET["sorgu"])) header("location: /");
    include_once 'api.php';
    include_once 'navbar/navbar.php';
    include_once 'urun/urunCard.php';
    ?>
</head>

<body>
    <?php
    navbar(array());
    $degerler = file_get_contents(
        "http://kozmosapi-001-site1.itempurl.com/api/Products/search?" . http_build_query(array('input' => $_GET["sorgu"])),
        false,
        stream_context_create(array(
            'http' => array('ignore_errors' => true),
        ))
    );

    //if (!is_string($degerler)) 
    $dizi = json_decode($degerler, true);
    ?>
    <div class="category-categoryName">
        <?php
            if (!is_array($dizi)) {
                echo $degerler;
            } else {
                echo '"' . $_GET["sorgu"] . '" araması için ' . count($dizi) . ' adet ürün bulundu!';
            } ?>
    </div>
    <div class="urun-container">
        <?php
        if (is_array($dizi)) foreach ($dizi as $item) urunCard($item);
        ?>
    </div>
</body>
<script src="index.js"></script>

</html>