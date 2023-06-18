use arac_muayene;
CREATE PROCEDURE sp_RandevuEkle
    @sahip_TC VARCHAR(11),
    @arac_plaka VARCHAR(10),
    @randevuTarih DATE,
    @randevuSaati TIME,
    @muayeneYerIl INT,
    @muayeneYerIlce INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Randevu tablosuna kay�t ekleme
    INSERT INTO randevu (sahip_TC, arac_plaka, randevu_tarih, randevu_saati, muayene_yer_il, muayene_yer_ilce)
    VALUES (@sahip_TC, @arac_plaka, @randevuTarih, @randevuSaati, @muayeneYerIl, @muayeneYerIlce);
    
    -- ��lemin ba�ar�yla tamamland���n� belirtmek i�in bir de�er d�nd�rme
    SELECT 1 AS Result;
END