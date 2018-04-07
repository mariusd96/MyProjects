<?php
/**
 * Created by PhpStorm.
 * User: Many
 * Date: 17.01.2018
 * Time: 18:02
 */

    $postdata = file_get_contents("php://input");
    $data = json_decode($postdata);

    $file = $data->file;
    $filename = $data->filename;
    //$file = 'C:/xampp/htdocs/PlatformaBAC3/documente/bib.pdf';
    //$filename = 'bib.pdf';
    header('Content-type: application/pdf');
    header('Content-Disposition: inline; filename="' . $filename . '"');
    header('Content-Transfer-Encoding: binary');
    header('Content-Length: ' . filesize($file));
    header('Accept-Ranges: bytes');
    @readfile($file);
?>