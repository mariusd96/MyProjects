<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 08.01.2018
 * Time: 12:35
 */
include "connectDB.php";

    $postdata = file_get_contents("php://input");
    $data = json_decode($postdata);

    $idCatalog = $data->idCatalog;
    $idProfesor = $data->idProfesor;

    if($conn->connect_error) die("Connection failfed: ".$conn->connect_error);
    $queryStr = "SELECT idCont, nume, prenume, clasa FROM DatePersonaleElev, Catalog WHERE Catalog.idCatalog = '$idCatalog' and Catalog.idProfesor = '$idProfesor' and Catalog.idElev = DatePersonaleElev.idCont;";
    $result = $conn->query($queryStr);

    $outp = "";
    if($result->num_rows > 0)
    {
        while ($rs = $result->fetch_array(MYSQLI_ASSOC))
        {
            if ($outp != "") $outp .= ",";
            $outp .= '{"idCont":"' . $rs["idCont"] . '",';
            $outp .= '"nume":"' . $rs["nume"] . '",';
            $outp .= '"prenume":"' . $rs["prenume"] . '",';
            $outp .= '"clasa":"' . $rs["clasa"] . '"}';
        }
    }

    $outp = '{"records":['.$outp.']}';
    echo ($outp);

    $conn->close();
?>