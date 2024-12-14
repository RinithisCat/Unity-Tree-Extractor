using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TreesHolder))]
public class TreesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TreesHolder holder = target as TreesHolder;

        if (GUILayout.Button("Get Trees"))
        {
            TreesExtractor.SetTrees(holder.Data, holder.Positions, holder.Prototypes, holder.ProtoIndexes,holder.ScaleProt);

        }
    
    
    
    
    }



}
