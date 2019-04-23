using Match3Project.Enums;
using Match3Project.Interfaces.Cells;
using UnityEngine;

namespace Match3Project.Classes.StaticClasses
{
    public static class Helper
    {
        public static MoveDirectionTypes FindMoveDirection(Vector3 a, Vector3 b)
        {
            MoveDirectionTypes moveDirection = MoveDirectionTypes.None;

            float angle = Mathf.Atan2(b.y - a.y, b.x - a.x) * 180 / Mathf.PI;
            
            if (angle > -45 && angle <= 45)
                moveDirection = MoveDirectionTypes.Right;
            else if (angle > 45 && angle <= 135)
                moveDirection = MoveDirectionTypes.Up;
            else if (angle > 135 || angle <= -135)
                moveDirection = MoveDirectionTypes.Left;
            else if (angle >= -135 && angle < -45)
                moveDirection = MoveDirectionTypes.Down;
            
            return moveDirection;
        }
        
        public static bool CellIsEmpty(ICell cell)
        {
            if (cell == null || cell.CurrentGameObject == null)
                return true;

            return false;
        }
        
        public static PowerUpTypes StringToPowerType(string powerTypeString)
        {
            PowerUpTypes powerUpType = PowerUpTypes.None;

            switch (powerTypeString)
            {
                case StringsAndConst.TAG_GRAVITY:
                    powerUpType = PowerUpTypes.Gravity;
                    break;
            }

            return powerUpType;
        }
        
        public static PowerUpTypes DetectPowerUp(int matchCount, AxisTypes axis)
        {
            PowerUpTypes powerUp = PowerUpTypes.None;

            if (matchCount >= 4)
                powerUp = PowerUpTypes.Gravity;

            return powerUp;
        }
        
        public static void SetGravityPowerUpColor(GameObject go, Color color)
        {
            GameObject powerGameObject = go.transform.GetChild(0).transform.gameObject;
            
            if (powerGameObject.CompareTag("Gravity"))
            {
                SpriteRenderer render = powerGameObject.GetComponent<SpriteRenderer>();
                render.color = color;
            }
        }
        
    }
}
