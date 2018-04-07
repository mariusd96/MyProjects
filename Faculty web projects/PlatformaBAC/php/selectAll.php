<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 20.12.2017
 * Time: 18:24
 */
    include "connectDB.php";

    $postdata = file_get_contents("php://input");
    $data = json_decode($postdata);
    $tabel = $data->tabel;

    if($conn->connect_error) die("Connection failfed: ".$conn->connect_error);
    $queryStr = $data->sqlQuery;
    $result = $conn->query($queryStr);

    $outp = "";
    if($result->num_rows > 0)
    {
        while ($rs = $result->fetch_array(MYSQLI_ASSOC))
        {
            if($outp != "") $outp .= ",";

            if(strcmp($tabel, "Conturi") == 0)
            {
                $outp .= '{"idCont":"'.$rs["idCont"].'",';
                $outp .= '"username":"'.$rs["username"].'",';
                $outp .= '"pass":"'.$rs["pass"].'",';
                $outp .= '"userType":"'. $rs["userType"].'"}';
            }
            else if(strcmp($tabel, "DatePersonaleElev") == 0)
            {
                $outp .= '{"nume":"'.$rs["nume"].'",';
                $outp .= '"prenume":"'.$rs["prenume"].'",';
                $outp .= '"profil":"'.$rs["profil"].'",';
                $outp .= '"specializare":"'.$rs["specializare"].'",';
                $outp .= '"clasa":"'.$rs["clasa"].'",';
                $outp .= '"email":"'.$rs["email"].'",';
                $outp .= '"idCont":"'. $rs["idCont"].'"}';
            }
            else if(strcmp($tabel, "Materii") == 0)
            {
                $outp .= '{"idMaterie":"'.$rs["idMaterie"].'",';
                $outp .= '"numeMaterie":"'. $rs["numeMaterie"].'"}';
            }
            else if(strcmp($tabel, "DatePersonaleProfesor") == 0)
            {
                $outp .= '{"nume":"'.$rs["nume"].'",';
                $outp .= '"prenume":"'.$rs["prenume"].'",';
                $outp .= '"idMaterie":"'.$rs["idMaterie"].'",';
                $outp .= '"email":"'.$rs["email"].'",';
                $outp .= '"idCont":"'. $rs["idCont"].'"}';
            }
            else if(strcmp($tabel, "Optiuni") == 0)
            {
                $outp .= '{"idElev":"'.$rs["idElev"].'",';
                $outp .= '"idMaterie":"'. $rs["idMaterie"].'"}';
            }
            else if(strcmp($tabel, "InrolareCurs") == 0)
            {
                $outp .= '{"idCheie":"'.$rs["idCheie"].'",';
                $outp .= '"idProfesor":"'.$rs["idProfesor"].'",';
                $outp .= '"cheieInrolare":"'. $rs["cheieInrolare"].'"}';
            }
            else if(strcmp($tabel, "Intrebari") == 0)
            {
                $outp .= '{"idIntrebare":"'.$rs["idIntrebare"].'",';
                $outp .= '"idProfesor":"'.$rs["idProfesor"].'",';
                $outp .= '"enunt":"'.$rs["enunt"].'",';
                $outp .= '"timpRaspuns":"'.$rs["timpRaspuns"].'",';
                $outp .= '"varCorecta":"'. $rs["varCorecta"].'"}';
            }
            else if(strcmp($tabel, "Variante") == 0)
            {
                $outp .= '{"idVarianta":"'.$rs["idVarianta"].'",';
                $outp .= '"idIntrebare":"'.$rs["idIntrebare"].'",';
                $outp .= '"enuntVarianta":"'.$rs["enuntVarianta"].'"}';
            }
            else if(strcmp($tabel, "Teste") == 0)
            {
                $outp .= '{"idTest":"'.$rs["idTest"].'",';
                $outp .= '"idIntrebare":"'.$rs["idIntrebare"].'",';
                $outp .= '"idElev":"'. $rs["idElev"].'"}';
            }
            else if(strcmp($tabel, "ValidareTest") == 0)
            {
                $outp .= '{"idTest":"'.$rs["idTest"].'",';
                $outp .= '"scorTest":"'. $rs["scorTest"].'"}';
            }
            else if(strcmp($tabel, "Catalog") == 0)
            {
                $outp .= '{"idCatalog":"'.$rs["idCatalog"].'",';
                $outp .= '"idProfesor":"'.$rs["idProfesor"].'",';
                $outp .= '"idELev":"'. $rs["idElev"].'"}';
            }
            else if(strcmp($tabel, "Lectii") == 0)
            {
                $outp .= '{"idLectie":"'.$rs["idLectie"].'",';
                $outp .= '"idProfesor":"'.$rs["idProfesor"].'",';
                $outp .= '"adrFisier":"'. $rs["adrFisier"].'"}';
            }
            else if(strcmp($tabel, "Chat") == 0)
            {
                $outp .= '{"idProfesor":"'.$rs["idProfesor"].'",';
                $outp .= '"idElev":"'.$rs["idElev"].'",';
                $outp .= '"mesajProf":"'.$rs["mesajProf"].'",';
                $outp .= '"mesajElev":"'. $rs["mesajElev"].'"}';
            }
            else if(strcmp($tabel, "Stiri") == 0)
            {
                $outp .= '{"idStire":"'.$rs["idStire"].'",';
                $outp .= '"idProfesor":"'.$rs["idProfesor"].'",';
                $outp .= '"idCatalog":"'.$rs["idCatalog"].'",';
                $outp .= '"anunt":"'. $rs["anunt"].'"}';
            }
            else if(strcmp($tabel, "Solutii") == 0)
            {
                $outp .= '{"idSolutie":"'.$rs["idSolutie"].'",';
                $outp .= '"idProfesor":"'.$rs["idProfesor"].'",';
                $outp .= '"idElev":"'.$rs["idElev"].'",';
                $outp .= '"adrSolutie":"'. $rs["adrSolutie"].'"}';
            }
            else if(strcmp($tabel, "feedbackProfesor") == 0)
            {
                $outp .= '{"idProfesor":"'.$rs["idProfesor"].'",';
                $outp .= '"idElev":"'.$rs["idElev"].'",';
                $outp .= '"feedbackProfesor":"'. $rs["feedbackProfesor"].'"}';
            }
            else if(strcmp($tabel, "feedbackPlatforma") == 0)
            {
                $outp .= '{"idElev":"'.$rs["idElev"].'",';
                $outp .= '"feedbackPlatforma":"'. $rs["feedbackPlatforma"].'"}';
            }
        }
    }

    $outp = '{"records":['.$outp.']}';
    echo ($outp);
?>