<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 24.12.2017
 * Time: 21:37
 */
    include "connectDB.php";

    $postdata = file_get_contents('php://input');
    $data = json_decode($postdata);

    $username = $data->user;
    $parola = $data->pass;

    $msg = "";
    $idCont = "";
    $userType = "";
    $tabel = "";
    $nume = "1";
    $prenume = "";

    if($conn->connect_error) die("Connection failfed: ".$conn->connect_error);

    $queryStr = "SELECT idCont, userType FROM Conturi WHERE username = '$username' and pass = '$parola'";
    $result = $conn->query($queryStr);
    $row = mysqli_fetch_array($result);

    $count = mysqli_num_rows($result);

    if($count == 1)
    {
        //$msg = "OK";
        //echo "id: ".$row["idCont"].", userType: ".$row["userType"]."<br />";
        $idCont = $row["idCont"];
        $userType = $row["userType"];
        //$msg="SELECT nume, prenume FROM $tabel WHERE idCont = '$idCont'";

        if($userType == 'A')
        {
            $nume = "Administrator";
            $prenume = "Platforma";
        }
        else
        {
            if($userType == "P") $tabel = "DatePersonaleProfesor";
            else if($userType == "E") $tabel = "DatePersonaleElev";

            $queryStr = "SELECT nume, prenume FROM $tabel WHERE idCont = '$idCont'";
            $result = $conn->query($queryStr);
            $row = mysqli_fetch_array($result);
            $nume = $row["nume"];
            $prenume = $row["prenume"];
        }
        $msg="OK";
    }
    else $msg = "Error";

    $myObj = array(
        "msg" => $msg,
        "idCont" => $idCont,
        "userType" => $userType,
        "nume" => $nume,
        "prenume" => $prenume
    );

    $myJSON = json_encode($myObj);

    echo ($myJSON);
    $conn->close();
?>

