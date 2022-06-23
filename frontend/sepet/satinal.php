<?php
if (!isset($_COOKIE["token"])) {
    header("location: /login.php?msg=Satın almak için giriş!");
    die();
}
/*
if (!isset($_REQUEST["title"])) {
    header("location: /sepet.php");
    die();
}
if (!isset($_REQUEST["text"])) {
    header("location: /sepet.php");
    die();
}
*/

header('Content-Type: application/json');
$urunler = [];
foreach (json_decode($_COOKIE["sepet"], true) as $val) {
    array_push(
        $urunler,
        array(
            "ProductId" => $val,
            "Amount" => 1
        )
    );
}
$seçenekler = array(
    'http' =>
    array(
        'method'  => 'POST',
        'header'  => [
            'Content-type: application/json',
            'Accept: */*',
            'Accept-Encoding: gzip, deflate, br',
            'Authorization: Bearer ' . $_COOKIE["token"]
        ],
        'content' => json_encode(
            array(
                "TotalPrice" => isset($_COOKIE["sepet_fiyat"]) ? intval($_COOKIE["sepet_fiyat"]) : -1,
                "BasketItems" => $urunler

            )
        ),
        'ignore_errors' => true
    )
);

$bağlam = stream_context_create($seçenekler);

$url = "http://kozmosapi-001-site1.itempurl.com/api/Checkout";

$result = file_get_contents($url, false, $bağlam);
echo $result;
$result = json_decode($result, true);
header("location: /sepetisil.php?delete=1");