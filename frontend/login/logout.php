<?php
setcookie("email", $_REQUEST["mail"], time() - 86400, "/");
setcookie("password", $_REQUEST["password"], time() - 86400, "/");
setcookie("sepet", json_encode(array(1,2,3,4)), time() - 86400, "/");
setcookie("token", $result["tokenInfo"]["token"], time() - 86400, "/");

header("Location: /");
?>