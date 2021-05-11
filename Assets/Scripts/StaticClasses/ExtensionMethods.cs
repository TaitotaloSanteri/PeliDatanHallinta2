using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
   public static void SetToWorldOrigin(this Transform trans)
    {
        trans.position = Vector3.zero;
    }
}
