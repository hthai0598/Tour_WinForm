

CREATE DATABASE tour_db
USE tour_db;

CREATE TABLE KhachHang
(
	 EmailKH VARCHAR(50) PRIMARY KEY,
	 TenKH VARCHAR(50),
	 PhoneKH INT,
	 Active VARCHAR(50),	
)

CREATE TABLE Tour
(
	IDTour VARCHAR(50) NOT NULL PRIMARY KEY,
	TenTour varchar(50),
	Mota varchar(100),
	GhiChu varchar(50),
	SoNgay int,
	NgayDi DATETIME,
	KhuyenMai int,
	Gia INT,
	TrangThai VARCHAR(50)

)


CREATE TABLE OrderTour
(
	OrderID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	EmailKH VARCHAR(50) NOT NULL ,
	IDTour VARCHAR(50) NOT NULL,
	Tong FLOAT,
	TrangThai VARCHAR(50),
	NgayTao DATETIME,
	SoKH INT,
	SoTreEm INT,
	SoNguoiLon INT,
	FOREIGN KEY (EmailKH) REFERENCES dbo.KhachHang(EmailKH),
	FOREIGN KEY(IDTour) REFERENCES dbo.Tour(IDTour)
)

CREATE TABLE ThongKe
(
	ThongKeID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	OrderId int NOT NULL,
	Tong FLOAT,
	Ngay DATETIME,
	FOREIGN KEY(OrderId) REFERENCES dbo.OrderTour(OrderID)
)


SELECT * FROM dbo.OrderTour
SELECT * FROM dbo.KhachHang
SELECT * FROM dbo.Tour
SELECT * FROM dbo.ThongKe

