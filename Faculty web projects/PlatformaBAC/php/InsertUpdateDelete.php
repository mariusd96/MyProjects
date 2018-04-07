<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 20.12.2017
 * Time: 20:51
 */
    include "connectDB.php";

    $postdata = file_get_contents("php://input");
    $data = json_decode($postdata);

    if($conn->connect_error) die("Connection failfed: ".$conn->connect_error);
    $queryStr = $data->sqlQuery;
    $msg = "";

    if($conn->query($queryStr) == TRUE) $msg = "OK";
    else $msg = "Error";

    $myObj = array("msg" => $msg);
    $myJSON = json_encode($myObj);
    echo ($myJSON);

    $conn->close();
?>