using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Swizzler
{
    public static class SwizzlerExt
    {
        public static Vector2 XY(this Vector3 vec)
            => new Vector2(vec.x, vec.y);

        public static Vector2 XZ(this Vector3 vec)
            => new Vector2(vec.x, vec.z);

        public static Vector3 X0Y(this Vector2 vec)
            => new Vector3(vec.x, 0f, vec.y);

        public static Vector3 XY0(this Vector2 vec)
            => new Vector3(vec.x, vec.y, 0f);

        public static Vector3 XYY(this Vector2 vec)
            => new Vector3(vec.x, vec.y, vec.y);
        public static Vector3 X0Z(this Vector3 vec)
            => new Vector3(vec.x, 0f, vec.z);

        public static Vector3 XY0(this Vector3 vec)
            => new Vector3(vec.x, vec.y, 0f);

        public static Vector2 XY(this Quaternion quat)
            => quat.eulerAngles.XY();

        public static Vector3 XXX(this float value)
            => new Vector3(value, value, value);
    }
}