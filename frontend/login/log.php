<?php

include_once("../api.php");
header('Content-Type: application/json');

$seçenekler = array(
    'http' =>
    array(
        'method'  => 'POST',
        'header'  => [
            'Content-type: application/json',
            'Accept: */*',
            'Accept-Encoding: gzip, deflate, br'
        ],
        'content' => json_encode(
            array(
                "email" => $_REQUEST["mail"],
                "password" => $_REQUEST["password"]
            )
        ),
        'ignore_errors' => true
    )
);

$bağlam = stream_context_create($seçenekler);

$url = "http://kozmosapi-001-site1.itempurl.com/api/User/login";

$result = file_get_contents($url, false, $bağlam);
$result = json_decode($result, true);
header("Content-Type: application/json");
echo json_encode($result);

if (isset($result["isSuccess"]) && $result["isSuccess"]) {
    setcookie("email",    $_REQUEST["mail"],             time() + (86400 * 2), "/");
    setcookie("password", $_REQUEST["password"],         time() + (86400 * 2), "/");
    if (!isset($_COOKIE["sepet"])) setcookie("sepet",    json_encode(array()),          time() + (86400 * 2), "/");
    setcookie("token",    $result["tokenInfo"]["token"], time() + (86400 * 2), "/");
    //echo $result["tokenInfo"]["token"];
    header("Location: /");
    die();
} else {
    if (isset($result["errors"]) && isset($result["errors"]["Email"])) {
        header("Location: /login.php?msg=" . $result["errors"]["Email"][0]);
        die();
    }
    echo $result;
    header("Location: /login.php?msg=" . $result["message"]);
    die();
}
