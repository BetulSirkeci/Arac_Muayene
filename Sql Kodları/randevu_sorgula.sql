CREATE PROCEDURE sp_RandevuSorgula
    @arac_plaka NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT randevu.randevu_id, sehir.ad AS il, ilce.ilce_ad AS ilce, randevu.randevu_tarih, randevu.randevu_saati, sahip_bilgileri.sahip_TC, sahip_bilgileri.sahip_ad, sahip_bilgileri.soyad, sahip_bilgileri.telefon, sahip_bilgileri.mail
    FROM randevu
    INNER JOIN sehir ON randevu.muayene_yer_il = sehir.sehir_id
    INNER JOIN ilce ON randevu.muayene_yer_ilce = ilce.ilce_id
    INNER JOIN sahip_bilgileri ON randevu.sahip_TC = sahip_bilgileri.sahip_TC
    WHERE randevu.arac_plaka = @arac_plaka;
END
