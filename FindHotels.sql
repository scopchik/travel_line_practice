--����� ��������� ������
SELECT * FROM dbo.Rooms
WHERE availability = 'true';

--����� ������������ �� �������
SELECT * FROM dbo.Customers
WHERE last_name LIKE 'S%';

--����� ������������ � ������������ ������ 
SELECT * FROM dbo.Bookings B
JOIN dbo.Customers C ON
B.customer_id = C.customer_id
WHERE C.first_name = 'Anatoly';

--����� ������������ �������
SELECT * FROM dbo.Bookings B
JOIN dbo.Rooms R ON 
B.room_id = R.room_id
WHERE R.room_number = 145;

--����� ������������������ ������� � ������������ ����
SELECT * FROM dbo.Rooms R
JOIN dbo.Bookings B ON 
R.room_id = B.room_id
WHERE ('2024-07-15' < B.check_in_date) OR (B.check_out_date > '2024-07-15') and availability = 'true';