<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 07.01.2018
 * Time: 16:26
 */
    include "connectDB.php";

    $postdata = file_get_contents("php://input");
    $data = json_decode($postdata);

    $idProfesor = $data->idProfesor;
    $enunt = $data->enunt;
    $timpRaspuns = $data->timpRaspuns;
    $varA = $data->varA;
    $varB = $data->varB;
    $varC = $data->varC;
    $varD = $data->varD;
    $varCorecta = $data->varCorecta;
    $idIntrebare = 0;

    if($conn->connect_error) die("Connection failfed: ".$conn->connect_error);
    $msg = "";
    $queryStr = "INSERT into Intrebari(idProfesor, enunt, timpRaspuns, varCorecta) VALUES ('$idProfesor', '$enunt', '$timpRaspuns', '$varCorecta')";

    if($conn->query($queryStr) == TRUE)
    {
        $queryStr = "SELECT MAX(idIntrebare) FROM Intrebari WHERE idProfesor = '$idProfesor'";
        $result = $conn->query($queryStr);
        $row = mysqli_fetch_array($result);
        $idIntrebare = $row["MAX(idIntrebare)"];

        for($i = 0; $i < 4; $i++)
        {
            $queryStr = "";

            if($i == 0 && $varA != "") $queryStr = "INSERT into Variante(idIntrebare, enuntVarianta) VALUES ('$idIntrebare', '$varA')";
            if($i == 1 && $varB != "") $queryStr = "INSERT into Variante(idIntrebare, enuntVarianta) VALUES ('$idIntrebare', '$varB')";
            if($i == 2 && $varC != "") $queryStr = "INSERT into Variante(idIntrebare, enuntVarianta) VALUES ('$idIntrebare', '$varC')";
            if($i == 3 && $varD != "") $queryStr = "INSERT into Variante(idIntrebare, enuntVarianta) VALUES ('$idIntrebare', '$varD')";

            if($queryStr != "") $conn->query($queryStr);
        }

        $msg = "OK";
    }
    else $msg = "Error";

    $myObj = array("msg" => $msg);
    $myJSON = json_encode($myObj);
    echo ($myJSON);

    $conn->close();
?>