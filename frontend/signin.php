<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Cosmos</title>
    <?php 
    include_once 'login/login.php';
    include_once 'navbar/navbar.php';
    ?>
</head>

<body>
    <?php
    navbar(
        array()
    );
    signin_form();
    ?>
</body>
<script src="index.js"></script>

</html>