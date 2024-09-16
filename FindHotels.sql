--����� ��������� ������
SELECT * FROM Rooms
WHERE room_id NOT IN (
    SELECT room_id FROM Bookings
    WHERE GETDATE() NOT BETWEEN check_in_date AND check_out_date 
) AND availability = 1;

--����� ������������ �� �������
SELECT * FROM dbo.Customers
WHERE last_name LIKE 'S%';

--����� ������������ � ������������ ������ 
SELECT * FROM dbo.Bookings B
JOIN dbo.Customers C ON B.customer_id = C.customer_id
WHERE C.first_name = 'Anatoly';

--����� ������������ �������
SELECT * FROM dbo.bookings
JOIN dbo.rooms ON bookings.room_id = rooms.room_id
WHERE rooms.room_number = 30;

--����� ������������������ ������� � ������������ ����
SELECT * FROM dbo.rooms
WHERE room_id IN (
	SELECT room_id FROM dbo.bookings
	WHERE ((check_in_date < '2024-07-3') OR (check_out_date > '2024-07-13')) and availability = 'true');