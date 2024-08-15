--поиск доступных комнат
SELECT * FROM dbo.Rooms
WHERE availability = 'true';

--поиск бронирований по фамилии
SELECT * FROM dbo.Customers
WHERE last_name LIKE 'S%';

--поиск бронирования с определенным именем 
SELECT * FROM dbo.Bookings B
JOIN dbo.Customers C ON B.customer_id = C.customer_id
WHERE C.first_name = 'Anatoly';

--поиск определенной комнаты
SELECT * FROM dbo.bookings
JOIN dbo.rooms ON bookings.room_id = rooms.room_id
WHERE rooms.room_number = 30;

--поиск незаброннированной комнаты в определенные даты
SELECT * FROM dbo.rooms
WHERE room_id IN (
	SELECT room_id FROM dbo.bookings
	WHERE check_in_date < '2024-08-08' AND check_out_date > '2024-08-08' and availability = 'true');