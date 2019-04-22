using Match3Project.Enums;
using UnityEngine;

namespace Match3Project.Interfaces
{
    public interface IObjectStorage
    {
        GameObject GetRandomGameElement();
        GameObject GetPowerElement(PowerUpTypes powerUpType);
    }
}
