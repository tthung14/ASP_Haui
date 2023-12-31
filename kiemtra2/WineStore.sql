--Tạo cơ sở dữ liệu
DROP DATABASE [WineStore]
CREATE DATABASE [WineStore]
GO
USE [WineStore]
GO
--Tạo bảng Catalogy
CREATE TABLE [dbo].[Catalogy](
[CatalogyID] [nchar](10) NOT NULL PRIMARY KEY,
[CatalogyName] [nvarchar](50) NOT NULL,
)
--Tạo bảng Product
CREATE TABLE [dbo].[Product](
[ProductID] [int] NOT NULL PRIMARY KEY,
[ProductName] [nvarchar](50) NOT NULL,
[Price] [numeric](8, 2) NOT NULL,
[CatalogyID] [nchar](10) NOT NULL,
[Image] [text] NULL,
)
GO
--Tạo các khóa ngoài
ALTER TABLE [dbo].[Product] WITH CHECK ADD CONSTRAINT [FK_Products_Catalogy] FOREIGN
KEY([CatalogyID])
REFERENCES [dbo].[Catalogy] ([CatalogyID])
GO
--Chèn dữ liệu cho bảng Catalogy
Insert into Catalogy(CatalogyID,CatalogyName) values('01',N'Rượu vang' )
Insert into Catalogy(CatalogyID,CatalogyName) values('02',N'Rượu VODKA' )
--Chèn dữ liệu cho bảng Product
Insert into
Product(ProductID,ProductName,Price,CatalogyID,Image)
values(1,N'RƯỢU VANG PETRUS',800,'01','h1.png' )
Insert into
Product(ProductID,ProductName,Price,CatalogyID,Image)
values(2,N'RƯỢU VODKA PUTINKA LIMITED',900,'02','h2.png' )