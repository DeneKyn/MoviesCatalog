using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MoviesCatalog.Services
{
    public static class WorkWithFiles
    {



        private static string fPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public static string FilePath = Path.Combine(fPath, "Book.txt");
        public static void WriteId(int id)
        {

            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(id);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteId(int id)
        {

            string temp = id.ToString();

            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(FilePath).Where(l => l != temp);

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(FilePath);
            File.Move(tempFile, FilePath);

        }
        public static List<string> GetIds()
        {
            List<string> temp = new List<string>();
            using (StreamReader sr = new StreamReader(FilePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    temp.Add(line);
                }
                sr.Close();
            }

            return temp;
        }

        public static void FileClear()
        {
            /*try
            {
                using (StreamWriter sw = new StreamWriter(FilePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("");
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
            File.Delete(FilePath);
        }

    }
}
