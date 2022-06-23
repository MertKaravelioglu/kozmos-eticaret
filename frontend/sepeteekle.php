<?php
if (!isset($_COOKIE["sepet"])) setcookie("sepet", "[]",   time() + 86400 * 3, "/");

if (isset($_GET["id"])) {
    if (isset($_COOKIE["sepet"])) $eskisepet = json_decode($_COOKIE["sepet"], true);
    else $eskisepet = json_decode("[]", true);
    echo $eskisepet;
    $deger = intval($_GET["id"]);
    if (!in_array($deger, $eskisepet))
        array_push($eskisepet, $deger);
    setcookie("sepet", json_encode($eskisepet),   time() + 86400 * 3, "/");
    echo "kuki: " . $_COOKIE["sepet"] . "<br>";
    header("Location: /urunler.php");
} else {
    echo "ekleme hata";
}