CREATE PROCEDURE sp_RandevuGuncelle
    @randevuID INT,
    @randevuTarih DATE,
    @randevuSaati TIME,
    @muayeneYerIl INT,
    @muayeneYerIlce INT
AS
BEGIN
    UPDATE randevu
    SET randevu_tarih = @randevuTarih,
        randevu_saati = @randevuSaati,
        muayene_yer_il = @muayeneYerIl,
        muayene_yer_ilce = @muayeneYerIlce
    WHERE randevu_id = @randevuID;
END
