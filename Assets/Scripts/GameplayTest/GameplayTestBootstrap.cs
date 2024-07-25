using Data;
using UnityEngine;

namespace GameplayTest
{
    public class GameplayTestBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform _characterSpawnPoint;
        [SerializeField] private Transform _mazeSpawnPoint;
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private MazeCellsFactory _mazeCellsFactory;
        [SerializeField] private PlayerDataConfig _config;
        
        private IDataProvider _dataProvider;
        private IPersistentData _persistentData;

        private void Awake()
        {
            InitializeData();
            
            DoTestSpawn();
        }

        private void DoTestSpawn()
        {
            Character character = _characterFactory.Get(_persistentData.PlayerData.SelectedCharacterSkin, _characterSpawnPoint.position);
            MazeCell mazeCell = _mazeCellsFactory.Get(_persistentData.PlayerData.SelectedMazeSkin, _mazeSpawnPoint.position);
            
            Debug.Log($"Spawned character: {_persistentData.PlayerData.SelectedCharacterSkin} \n" +
                      $"and maze cell: {_persistentData.PlayerData.SelectedMazeSkin}");
        }

        private void InitializeData()
        {
            _persistentData = new PersistentData();
            _dataProvider = new DataLocalProvider(_persistentData);
            
            LoadDataOrInit();
        }

        private void LoadDataOrInit()
        {
            if(_dataProvider.TryLoad() == false) _persistentData.PlayerData = new PlayerData(_config);
        }
    }
}