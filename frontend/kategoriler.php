<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Cosmos</title>
    <?php
    include_once 'api.php';
    include_once 'navbar/navbar.php';
    include_once 'urun/urunCard.php';
    include_once 'urun/urun.php';
    ?>
</head>

<body>
    <?php
    $degerler = file_get_contents("$api_server/Products");
    $degerler = json_decode($degerler, true);
    $category = file_get_contents("$api_server/Categories/" . $_GET['id']);
    $category = json_decode($category, true);
    if (!isset($category['categoryName'])) {
        echo "<meta http-equiv='refresh' content='0; url=/'>";
        exit();
    }
    navbar(array());
    ?>
        <div class="category-categoryName">
            Kategori: 
            <div class="urun-categoryName"><?php echo $category['categoryName'] ?></div>
        </div>
    <div class="urun-container">
        <?php

        foreach ($degerler as $item) {
            if ($category['categoryName'] == $item['categoryName']) urunCard($item);
        }
        ?>
    </div>
</body>
<script src="index.js"></script>

</html>