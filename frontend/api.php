<?php 
    $api_server = 'http://kozmosapi-001-site1.itempurl.com/api/';
    function httpPost($url, $data)
    {
        $curl = curl_init($url);
        curl_setopt($curl, CURLOPT_POST, true);
        curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
        curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
        $response = curl_exec($curl);
        curl_close($curl);
        return $response;
    }

    function httpGet($url, $data)
    {
        $url .= "?";
        foreach($data as $key => $value){
            $url .= urlencode($key).'='.urlencode($value).'&';
        }$url = substr($url, 0, -1);
        $curl = curl_init($url);
        $response = curl_exec($curl);
        curl_close($curl);
        return $response;
    }
?>