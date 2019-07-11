using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEditor;

public class EditorScript : EditorWindow
{

    static EditorScript window;
    static XmlWriter xmlWriter;
    string fileNumber;
    string feature1;
    string feature1blockType;
    string feature2;

    bool grass = false;
    bool dirt = false;
    bool sand = false;
    bool snow = false;
    bool paving = false;
    bool water = false;
    bool pondwater = false;
    bool lava = false;
    bool nuclear = false;
    bool ice = false;
    bool fire = false;
    bool wood = false;
    bool stone = false;
    bool burning = false;
    bool pebbles = false;
    bool flowers = false;
    bool tree = false;
    bool longgrass = false;
    bool lilypad = false;
    bool sapling = false;
    bool fenceStraight = false;
    bool fenceCorner = false;
    bool fenceEnd = false;
    bool lantern = false;
    bool lamppost = false;
    bool torch = false;
    bool floorlight = false;
    bool rainbow = false;
    


    [MenuItem("Custom Windows/Level Editor")]
    static void Initialise()
    {
        window = (EditorScript)EditorWindow.GetWindow(typeof(EditorScript));
        window.Show();
    }

    void OnGUI()
    {
        GUIStyle HeaderTextStyle = new GUIStyle();
        HeaderTextStyle.fontSize = 15;
        HeaderTextStyle.fontStyle = FontStyle.Italic;
        HeaderTextStyle.alignment = TextAnchor.MiddleCenter;

        // The file naming header and text field
        EditorGUILayout.LabelField("Level Editor", HeaderTextStyle);
        window.fileNumber = EditorGUI.TextField(new Rect(0, 50, position.width/2, 15), label: "Level number", text: window.fileNumber);
        window.feature1 = EditorGUI.TextField(new Rect(0, 75, position.width, 15), label: "Feature 1", text: window.feature1);
        grass = GUI.Toggle(new Rect(0, 100, position.width/6, 15), grass, "Grass");
        dirt = GUI.Toggle(new Rect(0, 120, position.width/6, 15), dirt, "Dirt");
        sand = GUI.Toggle(new Rect(0, 140, position.width/6, 15), sand, "Sand");
        snow = GUI.Toggle(new Rect(0, 160, position.width/6, 15), snow, "Snow");
        paving = GUI.Toggle(new Rect(0, 180, position.width/6, 15), paving, "Paving");
        water = GUI.Toggle(new Rect(100, 100, position.width/6, 15), water, "Water");
        pondwater = GUI.Toggle(new Rect(100, 120, position.width/6, 15), pondwater, "Pondwater");
        nuclear = GUI.Toggle(new Rect(100, 140, position.width/6, 15), nuclear, "Nuclear");
        lava = GUI.Toggle(new Rect(100, 160, position.width/6, 15), lava, "Lava");
        ice = GUI.Toggle(new Rect(100, 180, position.width/6, 15), ice, "Ice");
        fire = GUI.Toggle(new Rect(200, 100, position.width/6, 15), fire, "Fire");
        wood = GUI.Toggle(new Rect(200, 120, position.width/6, 15), wood, "Wood");
        stone = GUI.Toggle(new Rect(200, 140, position.width/6, 15), stone, "Stone");
        burning = GUI.Toggle(new Rect(200, 160, position.width/6, 15), burning, "Burning");
        pebbles = GUI.Toggle(new Rect(200, 180, position.width/6, 15), pebbles, "Pebbles");
        flowers = GUI.Toggle(new Rect(300, 100, position.width/6, 15), flowers, "Flowers");
        longgrass = GUI.Toggle(new Rect(300, 120, position.width/6, 15), longgrass, "Long grass");
        tree = GUI.Toggle(new Rect(300, 140, position.width/6, 15), tree, "Tree");
        lilypad = GUI.Toggle(new Rect(300, 160, position.width/6, 15), lilypad, "Lilypad");
        sapling = GUI.Toggle(new Rect(300, 180, position.width/6, 15), sapling, "Sapling");
        fenceStraight = GUI.Toggle(new Rect(400, 100, position.width/6, 15), fenceStraight, "Fence S");
        fenceCorner = GUI.Toggle(new Rect(400, 120, position.width/6, 15), fenceCorner, "Fence C");
        fenceEnd = GUI.Toggle(new Rect(400, 140, position.width/6, 15), fenceEnd, "Fence E");
        lantern = GUI.Toggle(new Rect(500, 100, position.width/6, 15), lantern, "Lantern");
        lamppost = GUI.Toggle(new Rect(500, 120, position.width/6, 15), lamppost, "Lamppost");
        torch = GUI.Toggle(new Rect(500, 140, position.width/6, 15), torch, "Torch");
        floorlight = GUI.Toggle(new Rect(500, 160, position.width/6, 15), floorlight, "Floor light");
        rainbow = GUI.Toggle(new Rect(500, 180, position.width/6, 15), rainbow, "Rainbow Light");
        //window.feature2 = EditorGUI.TextField(new Rect(0, 125, position.width, 15), label: "Feature 2", text: window.feature2);
        
        if (GUI.Button(new Rect(10, position.height-10, position.width/2, 15), text: "Save"))
        {
            WriteToFile(fileNumber, feature1, feature2);
        }
    }


    void WriteToFile(string number, string feat1, string feat2)
    {
        XmlWriterSettings writerSettings = new XmlWriterSettings();
        writerSettings.Indent = true;
        
        // Create a write instance
        XmlWriter xmlWriter = XmlWriter.Create("ChallengeLevels/" + "level" + number + ".xml", writerSettings);
        
        xmlWriter.WriteStartDocument();
        // Create the root element
        xmlWriter.WriteStartElement("Features");

        xmlWriter.WriteStartElement("Feature1");
        xmlWriter.WriteString(feat1);
        xmlWriter.WriteEndElement();

        xmlWriter.WriteStartElement("Feature2");
        xmlWriter.WriteString(feat2);
        xmlWriter.WriteEndElement();

        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();

        xmlWriter.Close();
    }
}
