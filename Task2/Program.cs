using System;
using System.IO;

Console.WriteLine("Введите путь:");
float Size = SizeCatalog(Console.ReadLine());
Console.WriteLine("Размер указанной папки: " + Size + " байт");

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