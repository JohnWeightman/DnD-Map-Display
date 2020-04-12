using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class SaveLoadMap : MonoBehaviour
{
    [Header("Script Variables")]
    public bool SaveMap = false;
    public string MapName;
    public GameObject Map;

    [Header("Prefabs")]
    public GameObject Tree;
    public GameObject Grass;
    public GameObject DirtRoad;

    void Start()
    {
        if (SaveMap)
            SaveMapFile();
        else
            LoadMapFile();
    }

    void SaveMapFile()
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
            XML.WriteEndElement();
        }
        XML.WriteEndElement();
        XML.WriteEndElement();
        XML.WriteEndDocument();
        XML.Close();
    }

    string CheckName(Transform Tile)
    {
        string TileName = Tile.name;
        TileName = TileName.Replace("(", "");
        TileName = TileName.Replace(")", "");
        TileName = TileName.Replace(" ", "");
        return TileName;
    }

    void LoadMapFile()
    {
        XmlReader XML = XmlReader.Create("Assets\\Maps\\" + MapName + ".xml");
        while(XML.Read() == true)
        {
            if ((XML.NodeType == XmlNodeType.Element) && (XML.Depth == 2))
            {
                Debug.Log(XML.GetAttribute("Name"));
                Instantiate(Resources.Load<GameObject>("Prefabs\\" + XML.GetAttribute("Name")), new Vector3((float) Convert.ToDouble(XML.GetAttribute("XPos")), (float)Convert.ToDouble(XML.GetAttribute("YPos")), (float)Convert.ToDouble(XML.GetAttribute("ZPos"))), Quaternion.identity);
            }
        }
    }
}
