CREATE DATABASE Viktalea
GO

USE Viktalea
GO

--DROP TABLE [dbo].[Client]
--DELETE FROM [dbo].[Client]

CREATE TABLE [dbo].[Client] (
    [Id]                 INT IDENTITY(1,1) PRIMARY KEY,
    [Ruc]                VARCHAR(11) NOT NULL UNIQUE,
    [BusinessName]       NVARCHAR(150) NOT NULL,
    [ContactPhone]       VARCHAR(15) NOT NULL,
    [ContactEmail]       NVARCHAR(150) NOT NULL,
    [Address]            NVARCHAR(250) NULL,
    [IsActive]           BIT NULL DEFAULT(1),
    [CreatedAt]          DATETIME NULL DEFAULT GETDATE(),
    [UpdatedAt]          DATETIME NULL,
    [CreatedBy]          NVARCHAR(100) NULL,
    [UpdatedBy]          NVARCHAR(100) NULL
);

CREATE INDEX IX_Client_Ruc ON [dbo].[Client]([Ruc]);
CREATE INDEX IX_Client_BusinessName ON [dbo].[Client]([BusinessName]);

INSERT INTO [dbo].[Client] ([Ruc], [BusinessName], [ContactPhone], [ContactEmail], [Address], [IsActive], [CreatedBy])
VALUES
('20123456789', N'Comercial Andina S.A.', '987654321', 'contacto@andina.com', N'Av. Los Andes 123, Lima', 1, N'admin'),
('20567891234', N'Tecnología Global S.A.C.', '912345678', 'info@tecnologiaglobal.com', N'Jr. Tecnología 456, Lima', 1, N'admin'),
('20456789123', N'Suministros Industriales S.A.', '987123456', 'ventas@suministros.com', N'Av. Industrial 789, Lima', 1, N'admin'),
('20345678912', N'Inversiones Delta S.A.C.', '912678345', 'contacto@deltainv.com', N'Calle Delta 321, Lima', 1, N'admin'),
('20234567891', N'Mercados Unidos S.A.', '987890123', 'info@mercadosunidos.com', N'Av. Comercio 654, Lima', 1, N'admin'),
('20109876543', N'Soluciones Creativas S.A.C.', '912345987', 'hola@solucionescreativas.com', N'Jr. Creativo 987, Lima', 1, N'admin'),
('20543210987', N'Logística Andina S.A.', '987654123', 'contacto@logisticaandina.com', N'Av. Transporte 321, Lima', 1, N'admin');

SELECT * FROM [dbo].[Client]