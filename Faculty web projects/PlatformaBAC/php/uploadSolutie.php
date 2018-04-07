<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 04.01.2018
 * Time: 17:25
 */
    include "connectDB.php";

    $target_dir = "C:/xampp/htdocs/PlatformaBAC3/solutii/";
    $name = $_POST['name'];
    $data = explode(',', $name);
    $idElev = $data[0];
    $idProf = $data[1];

    print_r($_FILES);
    $target_file = $target_dir . basename($_FILES["file"]["name"]);
    //if(!isset($name) || $name=="undefined") $name = $_FILES["file"]["name"];

    move_uploaded_file($_FILES["file"]["tmp_name"], $target_file);
    //write code for saving to database

    if ($conn->connect_error) die("Connection failed: " . $conn->connect_error);

    $sql = "INSERT INTO Solutii (idProfesor, idElev, adrSolutie) VALUES ($idProf, $idElev,'".$target_file."')";
    echo $sql;
    if ($conn->query($sql) == TRUE) {
        echo json_encode($_FILES["file"]); // new file uploaded
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }


    //email
    $queryStr = "SELECT email FROM DatePersonaleProfesor WHERE idCont='$idProf'";
    $result = $conn->query($queryStr);
    $row = mysqli_fetch_array($result);
    //recipient
    //$to = $row["email"];

    //sender
    $from_mail = 'mariusdulau9@gmail.com';
    $from_name = 'Admin Platforma BAC';
    $file = $target_file;

    $mailto = $row["email"];
    $subject = 'Solutie';

    $queryStr = "SELECT nume, prenume, clasa FROM DatePersonaleElev WHERE idCont='$idElev'";
    $result = $conn->query($queryStr);
    $row = mysqli_fetch_array($result);
    $message = 'Solutie: '.$row["nume"]." ".$row["prenume"].", ".$row["clasa"];

    $path = $target_dir;
    $filename = basename($_FILES["file"]["name"]);
    $file = $path.$filename;
    $content = file_get_contents( $file);
    $content = chunk_split(base64_encode($content));
    $uid = md5(uniqid(time()));
    $name = basename($file);

    // header
    $header = "From: ".$from_name." <".$from_mail.">\r\n";
    $header .= "MIME-Version: 1.0\r\n";
    $header .= "Content-Type: multipart/mixed; boundary=\"".$uid."\"\r\n\r\n";

    // message & attachment
    $nmessage = "--".$uid."\r\n";
    $nmessage .= "Content-type:text/plain; charset=iso-8859-1\r\n";
    $nmessage .= "Content-Transfer-Encoding: 7bit\r\n\r\n";
    $nmessage .= $message."\r\n\r\n";
    $nmessage .= "--".$uid."\r\n";
    $nmessage .= "Content-Type: application/octet-stream; name=\"".$filename."\"\r\n";
    $nmessage .= "Content-Transfer-Encoding: base64\r\n";
    $nmessage .= "Content-Disposition: attachment; filename=\"".$filename."\"\r\n\r\n";
    $nmessage .= $content."\r\n\r\n";
    $nmessage .= "--".$uid."--";

    if (mail($mailto, $subject, $nmessage, $header)) return true; // Or do something here
    else return false;

    $conn->close();
?>