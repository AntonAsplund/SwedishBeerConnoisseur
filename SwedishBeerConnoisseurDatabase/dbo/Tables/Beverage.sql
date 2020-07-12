﻿CREATE TABLE [dbo].[Beverage]
(
	[BeverageId] INT NOT NULL PRIMARY KEY,
	[ProductNumber] INT NULL,
	[ProductNameBold] nvarchar (MAX) NULL,
	[ProductNameThin] nvarchar (MAX) NULL,
	[Category] nvarchar (MAX) NULL,
	[ProductNumberShort] INT NULL,
	[SupplierName] nvarchar (MAX) NULL,
	[IsKosher] bit NULL,
	[IsOrganic] bit NULL,
	[IsEthical] bit NULL,
	[Volume] INT NULL,
	[Price] DECIMAL NULL,
	[OldHighPrice] DECIMAL NULL,
	[Country] nvarchar (MAX) NULL,
	[Type] nvarchar (MAX) NULL,
	[Style] nvarchar (MAX) NULL,
	[Usage] nvarchar (MAX) NULL,
	[RecycleFee] DECIMAL NULL,
	[Rating] DECIMAL NULL,
	[NumberOfRatings] INT NULL,
	[RateBRating] DECIMAL NULL,
	[NumberOfRateBRatings] INT NULL
)