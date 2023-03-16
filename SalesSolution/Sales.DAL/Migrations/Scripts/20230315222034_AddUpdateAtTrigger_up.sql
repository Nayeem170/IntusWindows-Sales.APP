CREATE OR ALTER TRIGGER [dbo].[tr_orders_update]
ON [dbo].[Orders]
AFTER UPDATE
AS
BEGIN
    UPDATE Orders
    SET UpdatedAt = CURRENT_TIMESTAMP
    FROM inserted i
    WHERE Orders.UId = i.UId;
END
GO

ALTER TABLE [dbo].[Orders] ENABLE TRIGGER [tr_orders_update]
GO

CREATE OR ALTER TRIGGER [dbo].[tr_windows_update]
ON [dbo].[Windows]
AFTER UPDATE
AS
BEGIN
    UPDATE Windows
    SET UpdatedAt = CURRENT_TIMESTAMP
    FROM inserted i
    WHERE Windows.UId = i.UId;
END
GO

ALTER TABLE [dbo].[Windows] ENABLE TRIGGER [tr_windows_update]
GO

CREATE OR ALTER TRIGGER [dbo].[tr_sub_elements_update]
ON [dbo].[SubElements]
AFTER UPDATE
AS
BEGIN
    UPDATE SubElements
    SET UpdatedAt = CURRENT_TIMESTAMP
    FROM inserted i
    WHERE SubElements.UId = i.UId;
END
GO

ALTER TABLE [dbo].[SubElements] ENABLE TRIGGER [tr_sub_elements_update]
GO

CREATE OR ALTER TRIGGER [dbo].[tr_element_types_update]
ON [dbo].[ElementTypes]
AFTER UPDATE
AS
BEGIN
    UPDATE ElementTypes
    SET UpdatedAt = CURRENT_TIMESTAMP
    FROM inserted i
    WHERE ElementTypes.UId = i.UId;
END
GO

ALTER TABLE [dbo].[ElementTypes] ENABLE TRIGGER [tr_element_types_update]
GO