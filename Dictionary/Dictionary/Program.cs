Dictionary<string, string> dictionary = new Dictionary<string, string>();
const string filePath = "dictionary.txt";

LoadDictionaryFromFile();

while ( true )
{
    Console.WriteLine( "Выберите действие:" );
    Console.WriteLine( "1. Перевод слова" );
    Console.WriteLine( "2. Добавить новое слово" );
    Console.WriteLine( "3. Выйти" );

    string command = Console.ReadLine();

    switch ( command )
    {
        case "1":
            TranslateWord();
            break;
        case "2":
            AddNewWord();
            break;
        case "3":
            SaveDictionaryToFile();
            return;
        default:
            Console.WriteLine( "Неверный выбор. Попробуйте еще раз." );
            break;
    }
}

void LoadDictionaryFromFile()
{
    if ( !File.Exists( filePath ) )
    {
        Console.WriteLine( "Файл словаря не найден, создаем новый." );
        return;
    }

    try
    {
        foreach ( string? line in File.ReadAllLines( filePath ) )
        {
            string[] parts = line.Split( ':' );
            if ( parts.Length == 2 )
            {
                dictionary[ parts[ 0 ].Trim() ] = parts[ 1 ].Trim();
            }
        }
    }
    catch ( Exception e )
    {
        Console.WriteLine( $"Ошибка при чтении файла: {e.Message}" );
    }
}

void TranslateWord()
{
    Console.Write( "Введите слово для перевода: " );
    string word = Console.ReadLine().Trim().ToLower();

    if ( !dictionary.ContainsKey( word ) )
    {
        Console.WriteLine( "Слово не найдено в словаре." );
        Console.Write( "Хотите добавить новое слово? (да/нет): " );
        string response = Console.ReadLine().Trim().ToLower();
        if ( response == "да" )
        {
            AddNewWordToDictionary( word );
        }
    }
    else
    {
        Console.WriteLine( $"Перевод: {dictionary[ word ]}" );
    }
}

void AddNewWord()
{
    Console.Write( "Введите слово на русском: " );
    string russianWord = Console.ReadLine().Trim().ToLower();

    if ( !dictionary.ContainsKey( russianWord ) )
    {
        Console.Write( "Введите перевод на английском: " );
        string englishTranslation = Console.ReadLine().Trim();
        dictionary[ russianWord ] = englishTranslation;
        Console.WriteLine( "Слово добавлено в словарь." );
    }
    else
    {
        Console.WriteLine( $"Слово уже существует в словаре. Вот его перевод: {dictionary[russianWord]}" );
    }
}

void AddNewWordToDictionary( string word )
{
    Console.Write( $"Введите перевод для слова '{word}': " );
    string translation = Console.ReadLine().Trim();
    dictionary[ word ] = translation;
    Console.WriteLine( "Слово добавлено в словарь." );
}

void SaveDictionaryToFile()
{
    try
    {
        using ( StreamWriter writer = new StreamWriter( filePath ) )
        {
            foreach ( KeyValuePair<string, string> entry in dictionary )
            {
                writer.WriteLine( $"{entry.Key}:{entry.Value}" );
            }
        }
        Console.WriteLine( "Изменения сохранены в файл." );
    }
    catch ( Exception ex )
    {
        Console.WriteLine( $"Ошибка при записи в файл: {ex.Message}" );
    }
}