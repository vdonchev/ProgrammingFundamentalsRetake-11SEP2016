namespace _04.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Files
    {
        private static readonly Dictionary<string, Dictionary<string, SortedDictionary<string, long>>> FilesArchive =
            new Dictionary<string, Dictionary<string, SortedDictionary<string, long>>>();

        public static void Main()
        {
            var numberOfFiles = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfFiles; i++)
            {
                var tokens = Console.ReadLine().Split(';').ToArray();

                var fileTokens = tokens[0].Split('\\').ToArray();

                var rootFolderName = fileTokens[0];
                var fileName = fileTokens[fileTokens.Length - 1];
                var fileExtension = fileName.Split('.').Last();
                var fileSize = long.Parse(tokens[1]);

                if (!FilesArchive.ContainsKey(rootFolderName))
                {
                    FilesArchive[rootFolderName] = new Dictionary<string, SortedDictionary<string, long>>();
                }

                if (!FilesArchive[rootFolderName].ContainsKey(fileExtension))
                {
                    FilesArchive[rootFolderName][fileExtension] = new SortedDictionary<string, long>();
                }

                FilesArchive[rootFolderName][fileExtension][fileName] = fileSize;
            }

            var searchString = Console.ReadLine().Split(' ').ToArray();
            var folderName = searchString[2];
            var extension = searchString[0];

            if (FilesArchive.ContainsKey(folderName) && FilesArchive[folderName].ContainsKey(extension))
            {
                var sortedFiles = FilesArchive[folderName][extension].OrderByDescending(e => e.Value);
                foreach (var file in sortedFiles)
                {
                    Console.WriteLine($"{file.Key} - {file.Value} KB"); 
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}