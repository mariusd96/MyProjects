<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 04.01.2018
 * Time: 17:25
 */
    include "connectDB.php";

    $target_dir = "C:/xampp/htdocs/PlatformaBAC3/documente/";
    $idProf = $_POST['name'];

    print_r($_FILES);
    $target_file = $target_dir . basename($_FILES["file"]["name"]);
    //if(!isset($name) || $name=="undefined") $name = $_FILES["file"]["name"];

    move_uploaded_file($_FILES["file"]["tmp_name"], $target_file);
    //write code for saving to database

    if ($conn->connect_error) die("Connection failed: " . $conn->connect_error);

    $sql = "INSERT INTO Lectii (idProfesor, numeFisier ,adrFisier) VALUES ($idProf,'".basename($_FILES["file"]["name"])."','".$target_file."')";
    echo $sql;
    if ($conn->query($sql) == TRUE) {
        echo json_encode($_FILES["file"]); // new file uploaded
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
    $conn->close();
?>