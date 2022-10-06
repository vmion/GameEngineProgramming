using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeometryHelper
{
    static public Vector3? GetTerrainHeightPos(Vector3 _origin)
    {
        Vector3 origin = _origin;
        origin.y += 200f;
        RaycastHit hitInfo;
        int layerMask = (1 << LayerMask.NameToLayer("Player")) | (1<< LayerMask.NameToLayer("Pat"));
        layerMask = ~layerMask;
        if(Physics.Raycast(origin, Vector3.down, out hitInfo, Mathf.Infinity, layerMask))
        {
            return hitInfo.point;
        }
        return null;
    }
}
