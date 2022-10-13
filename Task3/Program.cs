using System;
using System.IO;

Console.WriteLine("Введите путь:");
string Folder = Console.ReadLine();
float Size = SizeCatalog(Folder);
Console.WriteLine("Исходный размер папки: " + Size + " байт");

DelCatalog(Folder);
float newSize = Size - SizeCatalog(Folder);
Console.WriteLine("Освобождено: " + newSize + " байт");

Console.WriteLine("Текущий размер папки: " + SizeCatalog(Folder) + " байт");

static float SizeCatalog(string folder)
{
    DirectoryInfo di = new DirectoryInfo(folder);
    DirectoryInfo[] diA = di.GetDirectories();
    FileInfo[] fi = di.GetFiles();
    float FileSize = 0.0f;

    foreach (FileInfo file in fi)
    {
        FileSize += file.Length;
    }

    foreach (DirectoryInfo dir in diA)
    {
        FileSize += SizeCatalog(dir.FullName);
    }
    return FileSize;
}

static void DelCatalog(string folder)
{
    try
    {
        DirectoryInfo di = new DirectoryInfo(folder);
        DirectoryInfo[] diA = di.GetDirectories();
        FileInfo[] fi = di.GetFiles();

        foreach (FileInfo file in fi)
        {
            var d = DateTime.Now.Subtract(di.LastWriteTime);

            if (d > TimeSpan.FromMinutes(30))
                file.Delete();
        }
        foreach (DirectoryInfo dir in diA)
        {
            DelCatalog(dir.FullName);

            var f = DateTime.Now.Subtract(dir.LastWriteTime);
            if (f > TimeSpan.FromMinutes(30))
                dir.Delete();
        }
    }
    catch (Exception ex)
    { Console.WriteLine("Произошла ошибка" + ex.Message); }
}
