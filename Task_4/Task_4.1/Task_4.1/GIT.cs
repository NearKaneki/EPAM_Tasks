using Microsoft.VisualBasic;

namespace Task_4._1
{
    public class GIT
    {
        public struct infoFile
        {
            public int nameHash;
            public DateTime changed;
            public bool notDeleted;
            public override string ToString()
            {
                return $"{nameHash} {changed} {notDeleted}";
            }
        }

        private string _path;
        private string _saves;
        private Dictionary<string, List<infoFile>> _infoFiles;

        public GIT()
        {
            _path = Directory.GetCurrentDirectory() + @"\Test";
            _saves = Directory.GetCurrentDirectory() + @"\Saves";
            if (!File.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            if (!File.Exists(_saves))
            {
                Directory.CreateDirectory(_saves);
            }

            GetInfo();
            int ab = 2;
        }

        public void StartWatcher()
        {
            using var watcher = new FileSystemWatcher($"{_path}");

            watcher.NotifyFilter = NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.EnableRaisingEvents = true;

            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            Console.WriteLine("Нажмите Enter чтобы выйти из режима наблюдения");
            Console.ReadLine();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            string value = e.FullPath;
            Console.WriteLine($"Changed: {e.Name}");
            int hashCode = new FileInfo(value).GetHashCode();
            Console.WriteLine(hashCode);
            File.Copy(e.FullPath, _saves + $"\\{hashCode}.txt");
            _infoFiles[e.Name].Add(new infoFile { nameHash = hashCode, changed = DateTime.Now, notDeleted = true });
        }


        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = e.FullPath;
            Console.WriteLine($"Created: {e.Name}");
            int hashCode = new FileInfo(value).GetHashCode();
            Console.WriteLine(hashCode);
            File.Copy(e.FullPath, _saves + $"\\{hashCode}.txt");
            if (!_infoFiles.ContainsKey(e.Name))
            {
                _infoFiles.Add(e.Name, new List<infoFile>());
            }
            _infoFiles[e.Name].Add(new infoFile { nameHash = hashCode, changed = DateTime.Now, notDeleted = true });

        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted: {e.FullPath}");
            int preHash = _infoFiles[e.Name].Last().nameHash;
            _infoFiles[e.Name].Add(new infoFile { changed = DateTime.Now, nameHash = preHash, notDeleted = false });
        }


        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldName}");
            Console.WriteLine($"    New: {e.Name}");

            int preHash = _infoFiles[e.OldName].Last().nameHash;
            DateTime time = DateTime.Now;
            _infoFiles[e.OldName].Add(new infoFile { changed = time, nameHash = preHash, notDeleted = false });

            if (!_infoFiles.ContainsKey(e.Name))
            {
                _infoFiles.Add(e.Name, new List<infoFile>());
            }
            _infoFiles[e.Name].Add(new infoFile { changed = time, nameHash = preHash, notDeleted = true });
        }

        private void GetInfo()
        {
            if (!File.Exists($"{_path}/info.txt"))
            {
                _infoFiles = new Dictionary<string, List<infoFile>>();
                return;
            }
            using (StreamReader input = new StreamReader($"{_path}/info.txt"))
            {
                _infoFiles = new Dictionary<string, List<infoFile>>();
                int n;
                bool check = int.TryParse(input.ReadLine(), out n);
                for (int i = 0; i < n; i++)
                {
                    string[] parts = input.ReadLine().Split(".txt ");
                    int countPath;
                    string fileName = parts[0] + @".txt";
                    bool checkV2 = int.TryParse(parts[1], out countPath);
                    _infoFiles.Add(fileName, new List<infoFile>());
                    for (int j = 0; j < countPath; j++)
                    {
                        string[] infoPath = input.ReadLine().Split(' ', '/', ':');
                        DateTime time = new DateTime(int.Parse(infoPath[3]), int.Parse(infoPath[1]), int.Parse(infoPath[2]),
                            int.Parse(infoPath[4]), int.Parse(infoPath[5]), int.Parse(infoPath[6]));
                        bool notDeletedCheck = infoPath[8] == "True" ? true : false;
                        _infoFiles[fileName].Add(new infoFile { nameHash = int.Parse(infoPath[0]), changed = time, notDeleted = notDeletedCheck });
                    }
                }
            }
        }

        public void SaveInfo()
        {
            using (StreamWriter output = new StreamWriter($"{_path}/info.txt"))
            {
                output.WriteLine(_infoFiles.Count());
                foreach (var item in _infoFiles)
                {
                    output.WriteLine($"{item.Key} {item.Value.Count}");
                    foreach (var path in item.Value)
                    {
                        output.WriteLine($"{path}");
                    }
                }
            }
        }

        public void BackupMod(DateTime time)
        {
            Directory.Delete(_path, true);
            Directory.CreateDirectory(_path);
            foreach (var fileName in _infoFiles.Keys)
            {
                int ind = _infoFiles[fileName].FindLastIndex(x => x.changed <= time);
                if (ind != -1 && _infoFiles[fileName][ind].notDeleted == true)
                {
                    string oldName = $"\\{_infoFiles[fileName][ind].nameHash}.txt";
                    string newName = $"\\{fileName}";
                    File.Copy(_saves + oldName, _path+newName);
                    _infoFiles[fileName].Add(new infoFile
                    {
                        nameHash = _infoFiles[fileName][ind].nameHash,
                        notDeleted = true,
                        changed = DateTime.Now
                    });
                }
                else
                {
                    _infoFiles[fileName].Add(new infoFile
                    {
                        nameHash = _infoFiles[fileName].Last().nameHash,
                        notDeleted = false,
                        changed = DateTime.Now
                    });
                }
            }
        }
    }
}