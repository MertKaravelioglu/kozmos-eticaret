<link rel="stylesheet" href="login/login.css">
<?php
function login_form()
{
?>
    <div class="form_container">
        <div class="login_baslik">Giriş Yapın!</div>
        <div class="login_mesaj"><?php if(isset($_GET["msg"])) echo $_GET["msg"]; ?></div>
        <form class="login-form" method="post" name="login" action="./login/log.php">
            <input type="text" name="mail" placeholder="mailinizi girin!">
            <input type="password" name="password" placeholder="Şifrenizi girin!">
            <a href="/signin.php">Kayıt ol!</a>
            <input type="submit" name="submit" value="Giriş Yap!">
        </form>
    </div>
<?php
}
function signin_form()
{
?>
    <div class="form_container" >
        <div class="login_baslik">Kayıt olun!</div>
        <div class="login_mesaj"><?php if(isset($_GET["msg"])) echo $_GET["msg"]; ?></div>
        <form class="signin-form" action="./login/sig.php" name="signin" method="post">
            <input type="text" name="name" placeholder="Adınızı girin...">
            <input type="text" name="mail" placeholder="mailinizi girin...">
            <input type="password" name="password" placeholder="Şifrenizi girin...">
            <input type="password" name="password-again" placeholder="Şifrenizi tekrar girin..">
            <a href="/login.php">Giriş yap!</a>
            <input type="submit" name="submit"  value="Kayıt ol!">
        </form>
    </div>
<?php
}
?>