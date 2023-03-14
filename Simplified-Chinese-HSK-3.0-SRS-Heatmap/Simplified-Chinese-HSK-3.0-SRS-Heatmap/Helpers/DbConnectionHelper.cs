using System.Runtime.InteropServices;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Helpers
{
    public static class DbConnectionHelper
    {
        /// <summary>
        /// Dynamically finds the anki database file path and creates the connection string.
        /// </summary>
        /// <returns>Database connection string.</returns>
        public static string GetDatabaseConnectionString()
        {
            string anki2Folder = GetAnkiFolder();
            string[] subFolders = GetAnkiSubFolders(anki2Folder);
            string collectionPath = GetDatabasePath(subFolders);

            return "Filename=" + collectionPath;
        }

        /// <summary>
        /// Get the path to the Anki folder depending on OS.
        /// </summary>
        /// <returns>String path to Anki2 folder.</returns>
        private static string GetAnkiFolder()
        {
            string appDataFolder;
            string anki2Folder;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                anki2Folder = Path.Combine(appDataFolder, "Anki2");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                anki2Folder = Path.Combine(appDataFolder, "Library/Application Support/Anki2");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                anki2Folder = Path.Combine(appDataFolder, ".local/share/Anki2");
            }
            else
            {
                Console.WriteLine("Unsupported operating system.");
                return "";
            }

            return anki2Folder;
        }

        /// <summary>
        /// Get the subfolders in the Anki2 folder.
        /// </summary>
        /// <param name="anki2Folder">String path to Anki2 folder.</param>
        /// <returns>String[] of subfolders of Anki2 folder.</returns>
        private static string[] GetAnkiSubFolders(string anki2Folder)
        {
            string[] anki2SubFolders = Directory.GetDirectories(anki2Folder, "*", SearchOption.TopDirectoryOnly);

            if (anki2SubFolders.Length == 0)
            {
                Console.WriteLine("Could not find any Anki user folders.");
            }

            return anki2SubFolders;
        }

        /// <summary>
        /// Get the path to the anki database.
        /// </summary>
        /// <param name="anki2SubFolders"></param>
        /// <returns></returns>
        private static string GetDatabasePath(string[] anki2SubFolders)
        {
            string databasePath = anki2SubFolders.Select(folder => Path.Combine(folder, "collection.anki2")).FirstOrDefault(File.Exists);

            if (databasePath == null)
            {
                Console.WriteLine("Could not find collection.anki2 file.");
                databasePath = "";
            }

            return databasePath;
        }
    }
}
