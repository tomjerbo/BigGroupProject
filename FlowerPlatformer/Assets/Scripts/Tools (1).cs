using UnityEngine;

namespace Toolkit
{
    public static class Tools
    {
        public static float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public static Vector3[] FiveByFiveGrid
        {
            get
            {
                return new Vector3[25]
                {
                //Outer Circle
                Vector3.left * 2,
                Vector3.forward + Vector3.left * 2,
                Vector3.forward * 2 + Vector3.left * 2,
                Vector3.forward * 2 + Vector3.left,
                Vector3.forward * 2,
                Vector3.forward * 2 + Vector3.right,
                Vector3.forward * 2 + Vector3.right * 2,
                Vector3.forward + Vector3.right * 2,
                Vector3.right * 2,
                Vector3.back + Vector3.right * 2,
                Vector3.back * 2 + Vector3.right * 2,
                Vector3.back * 2 + Vector3.right,
                Vector3.back * 2,
                Vector3.back * 2 + Vector3.left,
                Vector3.back * 2 + Vector3.left * 2,
                Vector3.back + Vector3.left * 2,
                //Inner Circle
                Vector3.left,
                Vector3.forward + Vector3.left,
                Vector3.forward,
                Vector3.forward + Vector3.right,
                Vector3.right,
                Vector3.back + Vector3.right,
                Vector3.back,
                Vector3.back + Vector3.left,
                Vector3.zero
                };
            }
        }

        public static Vector3[] VectorRotation(int index)
        {
            Vector3[,] array = new Vector3[6, 3]
            {
                { Vector3.back, Vector3.left, Vector3.down },
                { Vector3.down, Vector3.back, Vector3.left },
                { Vector3.left, Vector3.down, Vector3.back },

                { Vector3.forward, Vector3.right, Vector3.up },
                { Vector3.up, Vector3.forward, Vector3.right },
                { Vector3.right, Vector3.up, Vector3.forward }
            };
            Vector3[] sendArray = new Vector3[3];

            if (index < 0)
                index = 0;
            else if (index > 5)
                index = 5;

            for (int i = 0; i < 3; i++)
                sendArray[i] = array[index, i];

            return sendArray;
        }

        public static Vector3 IgnoreY(this Vector3 v3)
        {
            return new Vector3(v3.x, 0, v3.z);
        }

        public static Vector2 ToXZ(this Vector3 v3)
        {
            return new Vector2(v3.x, v3.z);
        }
        public static Vector2 ToXY(this Vector3 v3)
        {
            return new Vector2(v3.x, v3.y);
        }
        public static Vector2 ToYZ(this Vector3 v3)
        {
            return new Vector2(v3.y, v3.z);
        }

        public static Vector3 Vector3RoundToInt(Vector3 v3)
        {
            return new Vector3(Mathf.RoundToInt(v3.x), Mathf.RoundToInt(v3.y), Mathf.RoundToInt(v3.z));
        }

        public static bool Vector3Exists(Vector3 v3, Vector3[] collection)
        {
            foreach (Vector3 otherV3 in collection)
            {
                if (Vector3RoundToInt(v3) == Vector3RoundToInt(otherV3))
                    return true;
            }
            return false;
        }

        public static bool Contains(this int layer, LayerMask layerMask)
        {
            if (((1 << layer) & layerMask) != 0)
                return true;
            else
                return false;
        }
    }
}
