using System.Reflection.PortableExecutable;
using System.Xml.Linq;



string path = @"Path\To\workshop\content\211820";
DateTime datenow = DateTime.Now;
string filepath = @"Path\to\starbound server\mods";
string filetype = "pak";
Random rnd = new Random();
recursivefolder(path, filetype);


void recursivefolder(string path, string filetype)
{
    if (Directory.Exists(path))
    {

        string[] files = Directory.GetFiles(path, "*." + filetype);
        //files = files.Where(x => (DateTime.Now - File.GetLastAccessTime(x)).TotalDays < days).ToArray<String>();
        string[] directories = Directory.GetDirectories(path);
        // Writes out all the files of the top level directory.
        writeFiles(files);
        recursiveFolders(directories, files);
    }
    else
    {
        Console.WriteLine("Directory does not exist");
    }

}


//Loops through all directories 
void recursiveFolders(string[] directories, string[] files)
{
    if (directories.Length >= 0)
    {
        foreach (string directory in directories)
        {
            files = Directory.GetFiles(directory);
            recursivefolder(directory, filetype);
        }
    }
}



void writeFiles(string[] files)
{
    foreach (string file in files)
    {
        string fName = file.Substring(path.Length + 1);
        Console.WriteLine(Path.Combine(filepath, fName.Substring(0,fName.LastIndexOf("\\")))+".pak");
    }
    writeLog(files);
}

void writeLog(string[] files)
{
    foreach (string file in files)
    {
        //string[] stuff = new string[1];

        int num = rnd.Next();
        string fName = file.Substring(path.Length + 1);
        //string fName2 = ((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds().ToString()+num+".pak";
        string fName2 = fName.Substring(0, fName.LastIndexOf("\\"))+".pak";
        File.Copy(Path.Combine(path, fName), Path.Combine(filepath, fName2), true);
        //stuff[0] = File.GetLastAccessTime(file) + " " + file;
        //File.AppendAllLines(filepath, stuff);

    }
}