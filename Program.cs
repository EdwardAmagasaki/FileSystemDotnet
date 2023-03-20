
using System;
using System.IO;

class Solution
{
    public static void Main(string[] args)
    {
        FileSystem.CriarPasta();
        FileSystem.GravarArquivo();
        FileSystem.LerArquivo();
        //FileSystem.ExcluirArquivo();
    }
}

class FileSystem
{

    /*
     * Complete the 'compareTriplets' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static void CriarPasta()
    {
  // Specify the directory you want to manipulate.
        // Ex MVC: Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~/");´
        // To create the directory C:\Users\User1\Public\Html 
        // when the current directory is C:\Users\User1, 
        // use any of the following calls to ensure that the backslash is interpreted properly: C# Copy

        //Directory.CreateDirectory("Img\\MyTeste");  
        //Directory.CreateDirectory("\\do0CodeS\\Console\\Tuple\\Img\\Html");  
        //Directory.CreateDirectory("c:\\do0CodeS\\Console\\Tuple\\Img\\Html");  

        string path = @"Img\MyTeste";

        try
        {
            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

            // Delete the directory.
            di.Delete();
            Console.WriteLine("The directory was deleted successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        finally {}
    }

    public static void CriarArquivo(){
           string path = @"c:\temp\MyTest.txt";
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
        }

        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
    }

    public static void LerArquivo(){
         try
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader("CDriveDirs.txt"))
            {
                // Read the stream as a string, and write the string to the console.
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
    public static void GravarArquivo(){
            // Get the directories currently on the C drive.
            DirectoryInfo[] cDirs = new DirectoryInfo(@"\do0CodeS\console").GetDirectories();

            // Write each directory name to a file.
            using (StreamWriter sw = new StreamWriter("CDriveDirs.txt"))
            {
                foreach (DirectoryInfo dir in cDirs)
                {
                    sw.WriteLine(dir.Name);
                }
            }

            // Read and show each line from the file.
            string line = "";
            using (StreamReader sr = new StreamReader("CDriveDirs.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
    }
        public static void ExcluirArquivo(){
         try
        {
            File.Delete("CDriveDirs.txt");
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}