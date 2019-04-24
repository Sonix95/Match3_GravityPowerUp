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

        public static Color DetectColor(ICell cell)
        {
            SpriteRenderer render = null;
                            
            if (cell.CurrentGameObject.CompareTag(StringsAndConst.TAG_POWER))
            {
                GameObject go = cell.CurrentGameObject.transform.GetChild(0).transform
                    .gameObject;

                render = go.GetComponent<SpriteRenderer>();
            }
            else
            {
                render = cell.CurrentGameObject.GetComponent<SpriteRenderer>();
            }

            return render.color;
        }
        
        public static bool CompareColors(GameObject cellA, GameObject cellB)
        {
            SpriteRenderer renderA = null;
            SpriteRenderer renderB = null;
            
            if (cellA.CompareTag("Power") || cellB.CompareTag("Power"))
            {
                if (cellA.CompareTag("Power"))
                {
                    GameObject goA = cellA.transform.GetChild(0).gameObject;
                    renderA = goA.GetComponent<SpriteRenderer>();
                }
                else
                {
                    GameObject goB = cellB.transform.GetChild(0).gameObject;
                    renderB = goB.GetComponent<SpriteRenderer>();
                }
            }
            else 
            {
                renderA = cellA.GetComponent<SpriteRenderer>();
                renderB = cellB.GetComponent<SpriteRenderer>();
            }

            if (renderA == null || renderB == null)
            {
                return false;
            }

            return renderA.color == renderB.color;
        }

    }
}
