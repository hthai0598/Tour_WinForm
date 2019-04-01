DROP DATABASE tour_manager
CREATE DATABASE tour_manager
USE tour_manager;

CREATE TABLE KhachHang
(
	 IDKH int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	 TenKH VARCHAR(50),
	 PhoneKG INT,
	 EmailKH VARCHAR(50)
	 
)

CREATE TABLE Tour
(
	IDTour int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TenTour varchar(50),
	Mota varchar(100),
	GhiChu varchar(50),
	SoNgay int,
	NgayDi VARCHAR(50),
	KhuyenMai int

)


CREATE TABLE OrderTour
(
	OrderID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IDKH int NOT NULL ,
	IDTour int NOT NULL,
	Tong DECIMAL,
	Active INT,
	NgayTao DATETIME,
	SoKH INT,
	SoTreEm INT,
	SoNguoiLon INT,
	FOREIGN KEY (IDKH) REFERENCES dbo.KhachHang(IDKH),
	FOREIGN KEY(IDTour) REFERENCES dbo.Tour(IDTour)
)
CREATE TABLE ThongKe
(
	ThongKeID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	OrderId INT NOT NULL,
	Tong INT,
	Ngay DATETIME,
	FOREIGN KEY(OrderId) REFERENCES dbo.OrderTour(OrderID)
)


SELECT dbo.OrderTour.OrderID, dbo.KhachHang.TenKH, dbo.Tour.TenTour,dbo.Tour.IDTour FROM dbo.OrderTour INNER JOIN dbo.KhachHang ON KhachHang.IDKH = OrderTour.IDKH INNER JOIN dbo.Tour ON Tour.IDTour = OrderTour.IDTour;


SELECT * FROM dbo.KhachHang;
SELECT * FROM dbo.Tour;
SELECT * FROM dbo.OrderTour;