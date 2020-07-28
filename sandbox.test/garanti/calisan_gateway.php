<?php
/**
 * Created by PhpStorm.
 * User: bsevgin
 * Date: 15.12.2017
 * Time: 14:50
 */

session_start();
if (!isset($_SESSION['orderNumber']) || !empty($_SESSION['orderNumber'])) {
    $_SESSION['orderNumber'] = uniqid();
}
// $SecurityData = strtoupper(sha1($this->password . str_pad($this->terminalId, 9, '0', STR_PAD_LEFT)));
// $HashData = strtoupper(sha1($this->order['orderId'] . $this->terminalId . $this->card['number'] . $this->order['total'] . $SecurityData));
// Pos tanımları, sipariş bilgileri ve ödeme bilgileri burada tanımlanıyor
$params = array(
    // Pos tanımları (Pos panelinde tanımlanıp buraya girilecek)
    'mode' => "PROD", // Pos modu, test için: "TEST", production için: "PROD"
    'merchantID' => "291143", // Merchant numarası
    'terminalID' => "10155738", // Terminal numarası
    'provUserID' => "PROVAUT", // Provision kullanıcı adı
    'provUserPassword' => "EvfaL2018.R", // Provision kullanıcı parolası


    'garantiPayProvUserID' => "PROVOOS", // GarantiPay için provision kullanıcı adı
    'garantiPayProvUserPassword' => "XXXXX", // GarantiPay için provision kullanıcı parolası

/*
    terminalprovuserid 12553585712
    terminaluserid 10155738
    terminalid 10155738
    terminalmerchantid 291143
    storeKey 353336657666613331396576666133396576666134356576
    PROVOOS = EvfaB2018.L
    PROVRFN = EvfaK2018.N
    PROVAUT = EvfaL2018.R
*/


    // garantisanalpotemdtesrtr
    // 'storeKey' => "676172616e746973616e616c706f74656d64746573727472", // 24byte hex 3D secure anahtarı
    'storeKey' => "353336657666613331396576666133396576666134356576", // 24byte hex 3D secure anahtarı
    'successUrl' => "http://garanti.test/calisan_gateway.php?action=success", // Başarılı ödeme sonrası dönülecek adres
    'errorUrl' => "http://garanti.test/calisan_gateway.php?action=error", // Hatalı ödeme sonrası dönülecek adres
    'companyName' => "GarantiPos PHP", // Firma adı
    'paymentType' => "creditcard", // Ödeme tipi - kredi kartı için: "creditcard", GarantiPay için: "garantipay"




    // Müşteri tanımları
    'orderNo' => $_SESSION['orderNumber'], // Sipariş numarası
    'amount' => 120, // Çekilecek tutar (ondalıklı olarak değil tam sayı olarak gönderilmeli, örn. 1.20tl için 120 gönderilmeli)
    'installmentCount' => "", // Tek çekim olacaksa boş bırakılmalıdır
    'currencyCode' => 949, // Döviz cinsi kodu(varsayılan:949): TRY=949, USD=840, EUR=978, GBP=826, JPY=392
    'customerIP' => $_SERVER['REMOTE_ADDR'], // Müşteri IP adresi
    'customerEmail' => "emma_adresim@gmail.com", // Müşteri e-mail adresi

    // Kart bilgisi tanımları (GarantiPay ile ödemede bu alanların doldurulması zorunlu değildir)
    'cardName' => "sdsd sdsd", // Kart üzerindeki ad soyad
    'cardNumber' => "5269110248556120", // Kart numarası (16 haneli boşluksuz)
    'cardExpiredMonth' => "07", // Kart geçerlilik tarihi ay
    'cardExpiredYear' => "25", // Kart geçerlilik tarihi yıl (yılın son 2 hanesi)
    'cardCvv' => "326", // Kartın arka yüzündeki son 3 numara(CVV kodu)
);

// print_r($params);
// GarantiPos sınıfı tanımlanıyor
require_once("GarantiPos.php");
$garantipos = new GarantiPos();
$garantipos->debugMode = true;

$params['paymentType'] = isset($_POST['paymenttype']) ? $_POST['paymenttype'] : $params['paymentType'];
$garantipos->setParams($params);

$action = isset($_GET['action']) ? $_GET['action'] : false;
if ($action) {

    $result = $garantipos->callback($action);
    if (isset($result['success']) && $result['success'] == 'success') {
        unset($_SESSION['orderNumber']); // Sipariş başarıyla tamamlandığı için session siliniyor
    }
echo '<pre>';
  print_r($result);
} else {
    
    $garantipos->debugUrlUse = false; // Parametre değerlerinin check edildiği adrese gönderilmesi

    $garantipos->pay(); // 3D doğrulama için bankaya yönlendiriliyor
}
