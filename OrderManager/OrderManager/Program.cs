string SuccessOrder( string name, string product, string count, string address, string todaysDate, string datePlusThreeDays )
{
    return $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {todaysDate} + {datePlusThreeDays}";
}

string AcceptOrder( string name, string product, string count, string address )
{
    return $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно?";
}

DateTime nowDate = DateTime.Today;
string todaysDate = thisDate.ToString( "d" );
string datePlusThreeDays = nowDate.AddDays( 3 ).ToString( "d" );

Console.Write( "Введите ваше имя: " );
string name = Console.ReadLine();

Console.Write( "Введите количество товара: " );
string count = Console.ReadLine();

Console.Write( "Введите название товара: " );
string product = Console.ReadLine();

Console.Write( "Введите ваш адрес доставки: " );
string address = Console.ReadLine();

string accept = AcceptOrder( name, product, count, address );
Console.WriteLine( accept );
Console.WriteLine( "Пример подтверждения y(yes)/n(no)" );
string succession = Console.ReadLine();

if ( succession == "y" )
{
    string successOrder = SuccessOrder( name, product, count, address, todaysDate, datePlusThreeDays );
    Console.WriteLine( successOrder );
}
else
{
    Console.WriteLine( "Отмена заказа" );
}

