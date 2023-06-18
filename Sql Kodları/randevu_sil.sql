CREATE PROCEDURE sp_RandevuSil
    @deger NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF ISNUMERIC(@deger) = 1
    BEGIN
        -- Verilen deðer sayýsal bir deðer ise randevu_id'ye göre silme iþlemi yap
        DELETE FROM randevu WHERE randevu_id = CAST(@deger AS INT);
        
        IF @@ROWCOUNT > 0
        BEGIN
            SELECT 'Randevu Silindi' AS Message;
        END
        ELSE
        BEGIN
            SELECT 'Geçersiz Randevu ID' AS Message;
        END
    END
    ELSE
    BEGIN
        -- Verilen deðer sayýsal bir deðer deðil ise arac_plaka'ya göre silme iþlemi yap
        DELETE FROM randevu WHERE arac_plaka = @deger;
        
        IF @@ROWCOUNT > 0
        BEGIN
            SELECT 'Randevu Silindi' AS Message;
        END
        ELSE
        BEGIN
            SELECT 'Geçersiz Araç Plakasý' AS Message;
        END
    END
END
