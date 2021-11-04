// See https://aka.ms/new-console-template for more information

using FilesAndDirectories;
using System.Text.Json;


#region Q1

string[] arr = new string[10];
arr = Directory.GetDirectories(@"C:\\");
foreach (string dir in arr.Take(10))
{
    //Console.WriteLine(dir);
}

#endregion

#region Q2

DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\User\Desktop\האקר-יו\מיון");
PrintFolderDetails(directoryInfo);

static void PrintFolderDetails(DirectoryInfo directoryInfo)
{
    var files1 = directoryInfo.GetFiles().OrderByDescending(file => file.Length).Take(3).ToList();
    foreach (var file in files1)
    {
        //Console.WriteLine("File name: " + file.Name);
        //Console.WriteLine("Last Change date: " + file.LastWriteTime);
        //Console.WriteLine();
    }

    // עשיתי את זה קודם בדרך הארוכה (למטה) ואז ראיתי פיתרון יותר קל במקום אחר אז ניסיתי לעשות
    // גם אותו (למעלה), השארתי את שניהם כי כבר כתבתי חח

    var files = directoryInfo.GetFiles();
    int[] indexes = new int[3] { -1, -1, -1 };
    long max = 0;
    for (int j = 0; j < indexes.Length; j++)
    {
        for (int i = 0; i < files.Length; i++)
        {
            if (i != indexes[0] && i != indexes[1])
            {
                if (files[i].Length > max)
                {
                    max = files[i].Length;
                    indexes[j] = i;
                }
            }
        }
        max = 0;
    }
    for (int i = 0; i < indexes.Length; i++)
    {
        //Console.WriteLine("File name: " + files[indexes[i]].Name);
        //Console.WriteLine("Last Change date: " + files[indexes[i]].LastWriteTime);
        //Console.WriteLine();
    }
}

#endregion

List<Book> Books = new List<Book>();

Books.Add(new Book { Id = 56, Name = "One Peace", Author = "Arthur Conan Doyle", DatePublished = new DateTime(1887, 04, 20) });
Books.Add(new Book { Id = 2, Author = "Oda", Name = "One Peace", DatePublished = new DateTime(2008, 03, 24) });
Books.Add(new Book { Id = 7101, Author = "Lev Tolstoy", DatePublished = new DateTime(1962, 05, 17), Name = "War and Pease", NumberOfPages = 780, NumberOfCopies = 2 });
Books.Add(new Book { Id = 7102, Author = "O'Henry", DatePublished = new DateTime(1932, 12, 17), Name = "Novells", NumberOfPages = 360, NumberOfCopies = 2 });
Books.Add(new Book { Id = 7103, Author = "Arthur Heily", DatePublished = new DateTime(1999, 11, 17), Name = "Hotel", NumberOfPages = 260, NumberOfCopies = 3 });
Books.Add(new Book { Id = 1, Author = "Marcel Proust", DatePublished = new DateTime(2009, 05, 17), Name = "In Search of Lost Time", NumberOfPages = 525, NumberOfBorrowedOut = 3 });
Books.Add(new Book { Id = 2, Author = "Miguel de Cervantes", DatePublished = new DateTime(1605, 03, 02), Name = "Miguel de Cervantes", NumberOfPages = 400, NumberOfBorrowedOut = 2 });
Books.Add(new Book { Id = 3, Author = "Gabriel Garcia Marquez", DatePublished = new DateTime(2013, 07, 05), Name = "One Hundred Years of Solitude", NumberOfPages = 321, NumberOfBorrowedOut = 5 });
Books.Add(new Book { Id = 4, Author = "Leo Tolstoy", DatePublished = new DateTime(1980, 05, 15), Name = "War and Peace", NumberOfPages = 900, NumberOfBorrowedOut = 15 });
Books.Add(new Book { Id = 5, Author = "Fyodor Dostoyevsky", DatePublished = new DateTime(1993, 05, 17), Name = "Crime and Punishment", NumberOfPages = 276, NumberOfBorrowedOut = 6 });
Books.Add(new Book { Id = 987, ISBN = new Guid(), Author = "Mozes", Name = "Efshar Gam Bly Qavier", NumberOfPages = 321, NumberOfCopies = 10, NumberOfBorrowedOut = 7, DatePublished = new DateTime(1947, 02, 01) });
Books.Add(new Book { Id = 964, ISBN = new Guid(), Author = "Ariel Naim", Name = "My First Book", NumberOfPages = 543, NumberOfCopies = 29, NumberOfBorrowedOut = 27, DatePublished = new DateTime(2007, 05, 24) });
Books.Add(new Book { Id = 864, ISBN = new Guid(), Author = "Haim Mosh", Name = "Ein li Shem Amiti", NumberOfPages = 111, NumberOfCopies = 7, NumberOfBorrowedOut = 0, DatePublished = new DateTime(1985, 11, 11) });
Books.Add(new Book { Id = 653, ISBN = new Guid(), Author = "Gady Halper", Name = "My New Car", NumberOfPages = 444, NumberOfCopies = 17, NumberOfBorrowedOut = 13, DatePublished = new DateTime(2021, 10, 21) });

#region Q3

SaveBooksAsJSON(Books);
static void SaveBooksAsJSON(List<Book> Books)
{
    var jsonSTR = JsonSerializer.Serialize(Books);

    File.WriteAllText(@"books.json", jsonSTR);
}

string str;

str = File.ReadAllText(@"C:\Users\User\source\repos\FilesAndDirectories\FilesAndDirectories\bin\Debug\net6.0\books.json");
//Console.WriteLine(str);


#endregion

#region Q4

SaveBooksAsLengthFixed(Books);

static void SaveBooksAsLengthFixed(List<Book> books)
{
    string str = "";
    foreach (var item in books)
    {
        str += item.ToFixedLength() + Environment.NewLine;
    }
    Console.WriteLine(str);
    File.WriteAllText(@"C:\new file\books.txt", str);
}

#endregion

#region Q5

//SaveBooksAsCSV(Books);

static void SaveBooksAsCSV(List<Book> books)
{
    string str = "";
    foreach (var item in books)
    {
        str += item.ToCSV() + Environment.NewLine;
    }
    File.WriteAllText(@"C:\new file\books.csv", str);
}

#endregion

#region Q6

//string str;

//str = File.ReadAllText(@"C:\new file\books.csv");
//Console.WriteLine(str);

string[] strArr = new string[14];
strArr = File.ReadAllLines(@"C:\new file\books.csv");
for (int i = 0; i < strArr.Length; i++)
{
    //Console.WriteLine(i + 1 + " {0}", strArr[i]);
}

#endregion


/*   
 
7 .איזה פורמט חסכוני יותר בזיכרון CSV או Length Fixed ?

CSV
חסכוני יותר בד"כ
כי ב-Length Fixed
הקובץ יקצה X 
תווים עבור כל משתנה אפילו אם הוא ריק לחלוטין, לעומת CSV
שיכול להשאיר ערך ריק (רק יוסיף פסיקים)

תיאורטית אפשרי ש-Length Fixed
יהיה חסכוני יותר מ-CSV
אם הערכים יכילו הרבה מאוד תווים שלא יהיה להם מקום בתבנית של ה-Length Fixed
אבל זה אומר שאיבדנו הרבה מידע אז זה לא ממש חסכון


8 .איזה חסרונות יש בפורמט Length Fixed?

אם הערך ארוך יותר ממס' התווים שהוגדר עבורו הוא לא יישמר בשלמות ונאבד מידע.
אם הערך קטן יותר ממס' התווים שהוגדרו - נשמור תווים מיותרים שיתפסו לנו מקום "בחינם"
הקובץ יוצא לא קריא - כל הערכים כתובים בצמוד אחד לשני ברצף



9 .מה היתרונות שיש בקובץ בינארי? 
 
חסכוני יותר בזיכרון, כי בשיטות האחרות, שהן מבוססות טקסט, כל תו טקסט תופס 4 בתים, שאפשר
לשמור בהם הרבה יותר מידע בצורה בינארית 
 
 
 */