using Match3Project.Enums;
using Match3Project.Interfaces.Cells;
using UnityEngine;

namespace Match3Project.Interfaces
{
    public interface ISpawnManager
    {
        GameObject SpawnPrefab(Vector3 position);
        GameObject SpawnPowerPrefab(PowerUpTypes powerUpType, Vector3 position);
        ICell SpawnNormalCell(Vector3 position);
    }
}
