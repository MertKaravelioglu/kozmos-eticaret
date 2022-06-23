<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Cosmos</title>
    <?php 
    include_once 'navbar/navbar.php';
    include_once 'login/login.php'
    ?>
</head>

<body>
    <?php
    navbar(
        array()
    );
    login_form();
    ?>
</body>
<script src="index.js"></script>

</html>