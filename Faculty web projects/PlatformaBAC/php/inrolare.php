<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 07.01.2018
 * Time: 19:46
 */
    include "connectDB.php";

    $postdata = file_get_contents("php://input");
    $data = json_decode($postdata);

    $idElev = $data->idElev;
    $key = $data->key;
    $msg = "";
    $idProfesor = 0;
    $idMaterie = 0;
    $idCheie = 0;
    $materie = "";

    if($conn->connect_error) die("Connection failfed: ".$conn->connect_error);

    $queryStr = "SELECT COUNT(idElev) FROM Optiune WHERE idElev='$idElev'";
    $result = $conn->query($queryStr);
    if($result == false) $count = 0;
    else $count = mysqli_num_rows($result);

    if($count < 3)
    {
        $queryStr = "SELECT idMaterie, idProfesor, idCheie FROM InrolareCurs, DatePersonaleProfesor WHERE InrolareCurs.cheieInrolare = '$key' AND InrolareCurs.idProfesor = DatePersonaleProfesor.idCont";
        $result = $conn->query($queryStr);
        $count = mysqli_num_rows($result);

        if ($count == 1)
        {
            $row = mysqli_fetch_array($result);
            $idProfesor = $row["idProfesor"];
            $idMaterie = $row["idMaterie"];
            $idCheie = $row["idCheie"];

            $queryStr = "SELECT * FROM Catalog WHERE idElev = '$idElev' AND idProfesor = '$idProfesor'";
            $result = $conn->query($queryStr);
            $count = mysqli_num_rows($result);

            if($count == 0)
            {
                $queryStr = "INSERT INTO Optiuni VALUES('$idElev', '$idMaterie')";
                $conn->query($queryStr);
                $queryStr = "INSERT INTO Catalog VALUES('$idCheie', '$idProfesor', '$idElev')";
                $conn->query($queryStr);

                $msg = "OK";
            }
            else $msg = "Sunteti deja inrolat la aceasta materie";
        }
        else $msg = "Error";
    }
    else $msg = "Error";

    $myObj = array("msg" => $msg);
    $myJSON = json_encode($myObj);
    echo ($myJSON);

    $conn->close();
?>