using Match3Project.Classes.Cells;
using Match3Project.Enums;
using Match3Project.Interfaces;
using Match3Project.Interfaces.Cells;
using UnityEngine;

namespace Match3Project.Classes
{
    public class SpawnManager : ISpawnManager
    {
        private readonly IObjectStorage _objectStorage;
        private readonly IObjectSetter _objectSetter;

        public SpawnManager(IObjectStorage objectStorage, IObjectSetter objectSetter)
        {
            _objectStorage = objectStorage;
            _objectSetter = objectSetter;
        }

        public GameObject SpawnPrefab(Vector3 position)
        {
            GameObject newGameObject = _objectStorage.GetRandomGameElement();
            _objectSetter.SetGameObject(newGameObject, position);
            
            return newGameObject;
        }

        public GameObject SpawnPowerPrefab(PowerUpTypes powerUpType, Vector3 position)
        {
            GameObject powerGameObject = _objectStorage.GetPowerElement(powerUpType);
            _objectSetter.SetGameObject(powerGameObject, position);
            
            return powerGameObject;
        }
        
        public ICell SpawnNormalCell(Vector3 position)
        {
            GameObject newGameObject = _objectStorage.GetRandomGameElement();
            ICell newNormalCell = new NormalCell((int) position.x, (int) position.y);
            
            _objectSetter.SetGameObject(newGameObject, position);
            _objectSetter.SetNormalCell(newNormalCell as INormalCell, newGameObject);
            
            return newNormalCell;
        }
        
    }
}
