using System;
using System.IO;
using static System.Net.WebRequestMethods;

DelCatalog(@"C:\temp");
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