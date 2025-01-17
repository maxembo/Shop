﻿using System.IO;
using Newtonsoft.Json;

namespace Data
{
    public class DataLocalProvider : IDataProvider
    {
        private const string FileName = "PlayerSave";
        private const string SaveFileExtension = ".json";

        private readonly IPersistentData _persistentData;

        public DataLocalProvider(IPersistentData persistentData) => _persistentData = persistentData;

        //private string SavePath => Application.persistentDataPath;
        private string SavePath => "Assets/Resources/Data";
        private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtension}");

        public void Save()
        {
            File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistentData.PlayerData, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        public bool TryLoad()
        {
            if (IsDataAlreadyExist() == false) return false;

            _persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));

            return true;
        }

        private bool IsDataAlreadyExist() => File.Exists(FullPath);

    }

}