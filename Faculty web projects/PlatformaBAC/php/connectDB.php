<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 20.12.2017
 * Time: 18:07
 */
    define('HOSTNAME', 'localhost');
    define('USERNAME', 'root');
    define('PASSWORD', 'dinamitaA7!xrn/1');
    define('DATABASE', 'platformabac');

    $conn = new mysqli(HOSTNAME, USERNAME, PASSWORD, DATABASE) or die("Unable to connect to DB");
?>