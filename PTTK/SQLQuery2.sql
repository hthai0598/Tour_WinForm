
CREATE DATABASE tour_db
USE tour_db;

CREATE TABLE KhachHang
(
	 EmailKH VARCHAR(50) PRIMARY KEY,
	 TenKH VARCHAR(50),
	 PhoneKH INT,
	
	 
)

CREATE TABLE Tour
(
	IDTour int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TenTour varchar(50),
	Mota varchar(100),
	GhiChu varchar(50),
	SoNgay int,
	NgayDi VARCHAR(50),
	KhuyenMai int,
	Gia INT

)


CREATE TABLE OrderTour
(
	OrderID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	EmailKH VARCHAR(50) NOT NULL ,
	IDTour int NOT NULL,
	Tong int,
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
	Tong INT,
	Ngay DATETIME,
	FOREIGN KEY(OrderId) REFERENCES dbo.OrderTour(OrderID)
)
INSERT INTO dbo.KhachHang
        ( EmailKH, TenKH, PhoneKH )
VALUES  ( 'thaimeo@gmai.com', -- EmailKH - varchar(50)
          'Thái', -- TenKH - varchar(50)
          1233  -- PhoneKH - int
          )

SELECT * FROM dbo.KhachHang ;
SELECT * FROM dbo.Tour 
SELECT * FROM dbo.OrderTour

