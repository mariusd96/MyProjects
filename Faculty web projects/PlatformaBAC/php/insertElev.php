<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 20.12.2017
 * Time: 18:40
 */
    include "connectDB.php";

    $postdata = file_get_contents('php://input');
    $data = json_decode($postdata);

    $username = $data->user;
    $parola = $data->pass;
    $nume = $data->nume;
    $prenume = $data->prenume;
    $profil = $data->profil;
    $specializare = $data->specializare;
    $clasa = $data->clasa;
    $email = $data->email;
    $msg = "";

    if($conn->connect_error) die("Connection failfed: ".$conn->connect_error);

    $queryStr = "SELECT username FROM Conturi WHERE username = '$username'";
    $result = $conn->query($queryStr);
    $count = mysqli_num_rows($result);

    if ($count == 0)
    {
        $msg = "OK";
        $queryStr = "INSERT INTO Conturi(username, pass, userType) VALUES ('$username','$parola', 'E')";
        $conn->query($queryStr);

        $queryStr = "SELECT idCont FROM Conturi WHERE username = '$username'";
        $result = $conn->query($queryStr);
        $row = mysqli_fetch_array($result);

        $idCont = $row["idCont"];
        $queryStr = "INSERT INTO DatePersonaleElev VALUES ('$nume','$prenume', '$profil', '$specializare', '$clasa', '$email', '$idCont')";
        $conn->query($queryStr);
    }
    else
    {
        $msg = "Error";
    }

    $myObj = array(
      "msg" => $msg
    );

    $myJSON = json_encode($myObj);
    echo ($myJSON);

    $conn->close();
?>