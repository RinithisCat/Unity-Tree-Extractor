using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TreesExtractor : MonoBehaviour
{


    static List<Vector4> GetPositions(List<Vector4> Pos, TerrainData data)
    {
        Pos.Clear();
        for (int i = 0; i < data.treeInstanceCount; i++)
        {
            Vector4 treesdata = new Vector4(data.GetTreeInstance(i).position.x, 
                                            data.GetTreeInstance(i).position.y,
                                            data.GetTreeInstance(i).position.z,
                                            data.GetTreeInstance(i).rotation);
            Pos.Add(treesdata);
        }

        return Pos;
    }

    static List<Vector2> GetScale(List<Vector2> size, TerrainData data)
    {
        size.Clear();
        for (int i = 0; i < data.treeInstanceCount; i++)
        {
            Vector2 treesdata = new Vector2(data.GetTreeInstance(i).widthScale, data.GetTreeInstance(i).heightScale);
            size.Add(treesdata);
        }

        return size;
    }


    public static List<int> ChoosePrototype(TerrainData data, List<int> protoindex)
    {
        protoindex.Clear();
        for (int i = 0; i < data.treeInstanceCount; i++)
        {
            int proto = data.treeInstances[i].prototypeIndex;
            protoindex.Add(proto);
        }

        return protoindex;   
    }

    public static void SetTrees(TerrainData data, List<Vector4> Positions, List<GameObject> Tree, List<int>indexes, List<Vector2> scales)
    {
        //Create a parent object to hold the trees
        GameObject parentobj = new GameObject("Extracted Trees");

        //Get terrain data
        Vector3 TerrainSize = new Vector3(data.size.x, data.size.y, data.size.z);
        List<Vector4> PositionsPrototypes = GetPositions(Positions, data);
        List<int> IndexPrototypes = ChoosePrototype(data, indexes);
        List<Vector2> Sizeprototypes = GetScale(scales, data);


        //Loop through every tree and set their properties
        for(int i = 0; i < PositionsPrototypes.Count; i++)
        {
            //Get Every tree position and rotation
            Vector3 Newpos = new Vector3(PositionsPrototypes[i].x * TerrainSize.x, PositionsPrototypes[i].y * TerrainSize.y, PositionsPrototypes[i].z * TerrainSize.z);
            float treerotation = Mathf.Rad2Deg * PositionsPrototypes[i].w;

            //Instance and register
            GameObject InstancedTree;
            InstancedTree = Instantiate(Tree[IndexPrototypes[i]], Newpos, Quaternion.Euler(0, treerotation, 0), parentobj.transform);
            PrefabUtility.ConnectGameObjectToPrefab(InstancedTree, Tree[IndexPrototypes[i]]);

            //Scale Set
            Vector3 initialscale = InstancedTree.transform.localScale;
            Vector3 finalscale = new Vector3 (Sizeprototypes[i].x* initialscale.x, Sizeprototypes[i].y* initialscale.y, Sizeprototypes[i].x* initialscale.z);
            InstancedTree.transform.localScale = finalscale;
        }

    }
}
