using UnityEngine;
using System.Collections;

public static class TransformTranslate2D {

    private static void Translate2D(this Transform transform, Vector2 translation, Space relativeTo = Space.Self)
    {
        if (relativeTo == Space.World)
        {
            Vector3 _switch = new Vector3(translation.x, translation.y);
            transform.position += _switch;
        }
        else
        {
            transform.position += transform.TransformDirection(translation);
        }
    }

    /// <summary>
    /// Move an object along a 2D path
    /// </summary>
    public static void Translate2D(this Transform transform, Vector2 translation)
    {
        Space relativeTo = Space.Self;
        Translate2D(transform, translation, relativeTo);
    }
    /// <summary>
    /// Move an object along a 2D path
    /// </summary>
    public static void Translate2D(this Transform transform, float x, float y)
    {
        Space relativeTo = Space.Self;
        Translate2D(transform, new Vector2(x, y), relativeTo);
    }
    /// <summary>
    /// Move an object along a 2D path
    /// </summary>
    public static void Translate2D(this Transform transform, float x, float y, Space relativeTo)
    {
        Translate2D(transform, new Vector2(x, y), relativeTo);
    }

}