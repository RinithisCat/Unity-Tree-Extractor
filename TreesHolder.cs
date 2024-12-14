using System.Collections.Generic;
using UnityEngine;


public class TreesHolder : MonoBehaviour
{
    public TerrainData Data;
    [HideInInspector]
    public List<Vector4> Positions = new List<Vector4>();
    [HideInInspector]
    public List<int> ProtoIndexes = new List<int>();
    public List<GameObject> Prototypes = new List<GameObject>();
    [HideInInspector]
    public List<Vector2> ScaleProt = new List<Vector2>();
}
