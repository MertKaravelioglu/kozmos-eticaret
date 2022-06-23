<?php

if (!isset($_COOKIE["token"])) {
    header("location: /login.php");
    die();
}
if (!isset($_REQUEST["title"])) {
    header("location: /iletisim.php");
    die();
}
if (!isset($_REQUEST["text"])) {
    header("location: /iletisim.php");
    die();
}


header('Content-Type: application/json');


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
                "title" => $_REQUEST["title"],
                "text" => $_REQUEST["text"]
            )
        ),
        'ignore_errors' => true
    )
);

$bağlam = stream_context_create($seçenekler);

$url = "http://kozmosapi-001-site1.itempurl.com/api/CustomerMessage";

$result = file_get_contents($url, false, $bağlam);
echo $result;
$result = json_decode($result, true);

header("location: /iletisim.php?msg=Mesajınız gönderildi");