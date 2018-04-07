<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 17.01.2018
 * Time: 18:10
 */
    include "connectDB.php";

    $postdata = file_get_contents("php://input");
    $data = json_decode($postdata);

    $idElev = $data->idElev;
    $idMaterie = $data->idMaterie;
    $msg = "";

    if($conn->connect_error) die("Connection failfed: ".$conn->connect_error);
    $queryStr = "SELECT idProfesor FROM DatePersonaleProfesor, Catalog WHERE Catalog.idElev = '$idElev' and Catalog.idProfesor = DatePersonaleProfesor.idCont and DatePersonaleProfesor.idMaterie = '$idMaterie'";
    $result = $conn->query($queryStr);
    $row = mysqli_fetch_array($result);

    if($result->num_rows == 1)
    {
        $msg = "OK";
        $idProfesor = $row["idProfesor"];
    }
    else $msg = "Error";

    $myObj = array("msg" => $msg, "idProfesor" => $idProfesor);
    $myJSON = json_encode($myObj);
    echo ($myJSON);

    $conn->close();
?>