CREATE PROCEDURE sp_RandevuSil
    @deger NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF ISNUMERIC(@deger) = 1
    BEGIN
        -- Verilen de�er say�sal bir de�er ise randevu_id'ye g�re silme i�lemi yap
        DELETE FROM randevu WHERE randevu_id = CAST(@deger AS INT);
        
        IF @@ROWCOUNT > 0
        BEGIN
            SELECT 'Randevu Silindi' AS Message;
        END
        ELSE
        BEGIN
            SELECT 'Ge�ersiz Randevu ID' AS Message;
        END
    END
    ELSE
    BEGIN
        -- Verilen de�er say�sal bir de�er de�il ise arac_plaka'ya g�re silme i�lemi yap
        DELETE FROM randevu WHERE arac_plaka = @deger;
        
        IF @@ROWCOUNT > 0
        BEGIN
            SELECT 'Randevu Silindi' AS Message;
        END
        ELSE
        BEGIN
            SELECT 'Ge�ersiz Ara� Plakas�' AS Message;
        END
    END
END
