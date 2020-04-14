using UnityEngine;
using UnityEditor;
using System;
using System.Xml;

public class SaveLoadButtons : EditorWindow
{
    GameObject Map;
    string MapName = "Roadside1";

    [MenuItem("Window/Map Options")]
    public static void ShowWindow()
    {
        GetWindow<SaveLoadButtons>("Map Options");
    }

    void OnGUI()
    {
        GUILayout.Label("Save/Load Map", EditorStyles.boldLabel);
        MapName = EditorGUILayout.TextField("Map", MapName);
        if (GUILayout.Button("Save Map"))
            SaveMap();
        if (GUILayout.Button("Load Map"))
            LoadMap();
        if (GUILayout.Button("Make Map Object"))
            MakeMapObj();
    }

    void SaveMap()
    {
        XmlWriter XML = XmlWriter.Create("Assets\\Maps\\" + MapName + ".xml");
        XML.WriteStartDocument();
        XML.WriteStartElement("Map");
        XML.WriteStartElement("Ground");
        for (int x = 0; x < Map.transform.GetChild(0).transform.childCount; x++)
        {
            Map.transform.GetChild(0).transform.GetChild(x).name = CheckName(Map.transform.GetChild(0).transform.GetChild(x));
            XML.WriteStartElement(Map.transform.GetChild(0).GetChild(x).gameObject.name);
            XML.WriteAttributeString("Name", Map.transform.GetChild(0).GetChild(x).gameObject.name);
            XML.WriteAttributeString("XPos", Convert.ToString(Map.transform.GetChild(0).GetChild(x).transform.position.x));
            XML.WriteAttributeString("YPos", Convert.ToString(Map.transform.GetChild(0).GetChild(x).transform.position.y));
            XML.WriteAttributeString("ZPos", Convert.ToString(Map.transform.GetChild(0).GetChild(x).transform.position.z));
            XML.WriteAttributeString("XRot", Convert.ToString(Map.transform.GetChild(0).GetChild(x).transform.rotation.eulerAngles.x));
            XML.WriteAttributeString("YRot", Convert.ToString(Map.transform.GetChild(0).GetChild(x).transform.rotation.eulerAngles.y));
            XML.WriteAttributeString("ZRot", Convert.ToString(Map.transform.GetChild(0).GetChild(x).transform.rotation.eulerAngles.z));
            XML.WriteAttributeString("Parent", "Ground");
            XML.WriteEndElement();
        }
        XML.WriteEndElement();
        XML.WriteStartElement("Items");
        for (int x = 0; x < Map.transform.GetChild(1).transform.childCount; x++)
        {
            Map.transform.GetChild(1).transform.GetChild(x).name = CheckName(Map.transform.GetChild(1).transform.GetChild(x));
            XML.WriteStartElement(Map.transform.GetChild(1).GetChild(x).gameObject.name);
            XML.WriteAttributeString("Name", Map.transform.GetChild(1).GetChild(x).gameObject.name);
            XML.WriteAttributeString("XPos", Convert.ToString(Map.transform.GetChild(1).GetChild(x).transform.position.x));
            XML.WriteAttributeString("YPos", Convert.ToString(Map.transform.GetChild(1).GetChild(x).transform.position.y));
            XML.WriteAttributeString("ZPos", Convert.ToString(Map.transform.GetChild(1).GetChild(x).transform.position.z));
            XML.WriteAttributeString("XRot", Convert.ToString(Map.transform.GetChild(1).GetChild(x).transform.rotation.eulerAngles.x));
            XML.WriteAttributeString("YRot", Convert.ToString(Map.transform.GetChild(1).GetChild(x).transform.rotation.eulerAngles.y));
            XML.WriteAttributeString("ZRot", Convert.ToString(Map.transform.GetChild(1).GetChild(x).transform.rotation.eulerAngles.z));
            XML.WriteAttributeString("Parent", "Items");
            XML.WriteEndElement();
        }
        XML.WriteEndElement();
        XML.WriteStartElement("NPCs");
        for (int x = 0; x < Map.transform.GetChild(2).transform.childCount; x++)
        {
            Map.transform.GetChild(2).transform.GetChild(x).name = CheckName(Map.transform.GetChild(2).transform.GetChild(x));
            XML.WriteStartElement(Map.transform.GetChild(2).GetChild(x).gameObject.name);
            XML.WriteAttributeString("Name", Map.transform.GetChild(2).GetChild(x).gameObject.name);
            XML.WriteAttributeString("XPos", Convert.ToString(Map.transform.GetChild(2).GetChild(x).transform.position.x));
            XML.WriteAttributeString("YPos", Convert.ToString(Map.transform.GetChild(2).GetChild(x).transform.position.y));
            XML.WriteAttributeString("ZPos", Convert.ToString(Map.transform.GetChild(2).GetChild(x).transform.position.z));
            XML.WriteAttributeString("XRot", Convert.ToString(Map.transform.GetChild(2).GetChild(x).transform.rotation.eulerAngles.x));
            XML.WriteAttributeString("YRot", Convert.ToString(Map.transform.GetChild(2).GetChild(x).transform.rotation.eulerAngles.y));
            XML.WriteAttributeString("ZRot", Convert.ToString(Map.transform.GetChild(2).GetChild(x).transform.rotation.eulerAngles.z));
            XML.WriteAttributeString("Parent", "NPCs");
            XML.WriteEndElement();
        }
        XML.WriteEndElement();
        XML.WriteStartElement("PCs");
        for (int x = 0; x < Map.transform.GetChild(3).transform.childCount; x++)
        {
            Map.transform.GetChild(3).transform.GetChild(x).name = CheckName(Map.transform.GetChild(3).transform.GetChild(x));
            XML.WriteStartElement(Map.transform.GetChild(3).GetChild(x).gameObject.name);
            XML.WriteAttributeString("Name", Map.transform.GetChild(3).GetChild(x).gameObject.name);
            XML.WriteAttributeString("XPos", Convert.ToString(Map.transform.GetChild(3).GetChild(x).transform.position.x));
            XML.WriteAttributeString("YPos", Convert.ToString(Map.transform.GetChild(3).GetChild(x).transform.position.y));
            XML.WriteAttributeString("ZPos", Convert.ToString(Map.transform.GetChild(3).GetChild(x).transform.position.z));
            XML.WriteAttributeString("XRot", Convert.ToString(Map.transform.GetChild(3).GetChild(x).transform.rotation.eulerAngles.x));
            XML.WriteAttributeString("YRot", Convert.ToString(Map.transform.GetChild(3).GetChild(x).transform.rotation.eulerAngles.y));
            XML.WriteAttributeString("ZRot", Convert.ToString(Map.transform.GetChild(3).GetChild(x).transform.rotation.eulerAngles.z));
            XML.WriteAttributeString("Parent", "PCs");
            XML.WriteEndElement();
        }
        XML.WriteEndElement();
        XML.WriteEndElement();
        XML.WriteEndDocument();
        XML.Close();
    }

    void LoadMap()
    {
        XmlReader XML = XmlReader.Create("Assets\\Maps\\" + MapName + ".xml");
        while (XML.Read() == true)
        {
            if ((XML.NodeType == XmlNodeType.Element) && (XML.Depth == 2))
            {
                GameObject NewObj = Instantiate(Resources.Load<GameObject>(XML.GetAttribute("Name")), new Vector3((float)Convert.ToDouble(XML.GetAttribute("XPos")),
                    (float)Convert.ToDouble(XML.GetAttribute("YPos")), (float)Convert.ToDouble(XML.GetAttribute("ZPos"))),
                    Quaternion.Euler((float)Convert.ToDouble(XML.GetAttribute("XRot")), (float)Convert.ToDouble(XML.GetAttribute("YRot")),
                    (float)Convert.ToDouble(XML.GetAttribute("ZRot"))));
                NewObj.name = XML.GetAttribute("Name");
                NewObj.transform.parent = Map.transform.Find(XML.GetAttribute("Parent"));
            }
        }
    }

    void MakeMapObj()
    {
        Map = Instantiate(Resources.Load<GameObject>("Map"));
        Map.name = "Map";
    }

    string CheckName(Transform Tile)
    {
        string TileName = Tile.name;
        TileName = TileName.Replace("(", "");
        TileName = TileName.Replace(")", "");
        TileName = TileName.Replace(" ", "");
        TileName = TileName.Replace("0", "");
        TileName = TileName.Replace("1", "");
        TileName = TileName.Replace("2", "");
        TileName = TileName.Replace("3", "");
        TileName = TileName.Replace("4", "");
        TileName = TileName.Replace("5", "");
        TileName = TileName.Replace("6", "");
        TileName = TileName.Replace("7", "");
        TileName = TileName.Replace("8", "");
        TileName = TileName.Replace("9", "");
        return TileName;
    }
}
