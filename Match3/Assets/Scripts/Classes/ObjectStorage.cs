using System.Collections.Generic;
using System.Linq;
using Match3Project.Classes.StaticClasses;
using Match3Project.Enums;
using Match3Project.Interfaces;
using UnityEngine;

namespace Match3Project.Classes
{
    public class ObjectStorage : IObjectStorage
    {
        private readonly IList<GameObject> _normalCellsPrefabsList;
        private readonly IDictionary<PowerUpTypes, GameObject> _powersPrefabs;

        public ObjectStorage()
        {
            _powersPrefabs = new Dictionary<PowerUpTypes, GameObject>();
            _normalCellsPrefabsList = new List<GameObject>();

            Object[] objTempArray = Resources.LoadAll(StringsAndConst.GAMEPLAY_ELEMENTS);
            for (int i = 0; i < objTempArray.Length; i++)
            {
                _normalCellsPrefabsList.Add(objTempArray[i] as GameObject);
            }

            _powersPrefabs.Add(PowerUpTypes.Bomb, Resources.Load(StringsAndConst.POWER_BOMB) as GameObject);
        }

        public GameObject GetRandomGameElement()
        {
            int cellIndex = Random.Range(0, _normalCellsPrefabsList.Count);
            var prefToUse = _normalCellsPrefabsList.ElementAt(cellIndex);
            return Object.Instantiate(prefToUse);
        }

        public GameObject GetPowerElement(PowerUpTypes powerUpType)
        {
            GameObject powerGameObject = Object.Instantiate(_powersPrefabs[powerUpType]);
            return powerGameObject;
        }

    }
}
