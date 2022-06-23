<?php
include_once("../api.php");
header('Content-Type: application/json');
echo json_encode($_REQUEST);

$settings = array(
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
                "fullName" => $_REQUEST["name"],
                "email" => $_REQUEST["mail"],
                "password" => $_REQUEST["password"],
                "confirmPassword" => $_REQUEST["password-again"]
            )
        ),
        'ignore_errors' => true
    )
);
$bağlam = stream_context_create($settings);

$url = "http://kozmosapi-001-site1.itempurl.com/api/User/register";

$result = file_get_contents($url, false, $bağlam);
$result = json_decode($result, true);
echo json_encode($result);

if (isset($result["isSuccess"]) && $result["isSuccess"]) {
    setcookie("email",    $_REQUEST["mail"],             time() + (86400 * 2), "/");
    setcookie("password", $_REQUEST["password"],         time() + (86400 * 2), "/");
    if (!isset($_COOKIE["sepet"]))  setcookie("sepet",   json_encode(array()),                          time() + (86400 * 2), "/");
    setcookie("token",    $result["tokenInfo"]["token"], time() + (86400 * 2), "/");

    header("Location: /");
    die();
} else {
    if (isset($result["errors"])) {
        if (isset($result["errors"]["Email"])) {
            header("Location: /signin.php?msg=" . $result["errors"]["Email"][0]);
        } else if (isset($result["errors"]["ConfirmPassword"])) {
            header("Location: /signin.php?msg=" . $result["errors"]["ConfirmPassword"][0]);
        }
        die();
    }
    //echo $result;
    header("Location: /signin.php?msg=" . $result["message"]);
    die();
}
