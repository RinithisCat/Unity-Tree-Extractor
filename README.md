# Unity-Tree-Extractor
This is intended to get all objects that are painted as trees in the Unity Terrain Editor. So you can freely manipulate these objects as prefabs and implement optimization techniques by yourself.

In this repository you will have access to the Tool itself. It comes with 3 scripts and a Prefab.
To use it you will need to drag and drop the prefab into your scene hierarchy. So you can assign the Terrain Data object you want to extract from, increase the number of prototype elements you want and add them in the same order they are added in the terrain "Paint Trees" tab. This only works with the Tree tab and does not work with the "Detail Painter"
![image](https://github.com/user-attachments/assets/3a2250ad-5367-43b4-8a41-1cd6e1eb66ab)

![image](https://github.com/user-attachments/assets/c4fa41cb-034f-4db2-8b46-38ddcd5f8fa3)
![image](https://github.com/user-attachments/assets/183a5d7c-08e1-4cb7-92a6-f0eb39762215)

As result you will have your extracted objects inside a gameobject in your hierarchy

![image](https://github.com/user-attachments/assets/1a38ec5b-accd-4914-af7f-d007d935498a)

