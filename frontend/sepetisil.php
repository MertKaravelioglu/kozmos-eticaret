<?php
if (!isset($_COOKIE["sepet"])) setcookie("sepet", "[]",   time() + 86400 * 3, "/");

if (isset($_GET["delete"])){
    setcookie("sepet", "[]",   time() + 86400 * 3, "/");
    header("location: /");
    die();
}

if (isset($_GET["id"])) {
    if (isset($_COOKIE["sepet"])) $eskisepet = json_decode($_COOKIE["sepet"], true);
    else $eskisepet = json_decode("[]", true);
    echo $eskisepet;
    $deger = intval($_GET["id"]);
    $yenisepet = array();
    foreach ($eskisepet as $val) {
        if($val != $deger) array_push($yenisepet,$val);
    }
    setcookie("sepet", json_encode($yenisepet),   time() + 86400 * 3, "/");
    echo "kuki: " . $_COOKIE["sepet"] . "<br>";
    header("Location: /sepet.php");
} else {
    echo "ekleme hata";
}