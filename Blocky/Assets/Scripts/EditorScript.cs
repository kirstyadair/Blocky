/* using System.Collections;
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
    
    string grassCount = "0";
    string dirtCount = "0";
    string sandCount = "0";
    string snowCount = "0";
    string pavingCount = "0";
    string waterCount = "0";
    string pondwaterCount = "0";
    string lavaCount = "0";
    string nuclearCount = "0";
    string iceCount = "0";
    string fireCount = "0";
    string woodCount = "0";
    string stoneCount = "0";
    string burningCount = "0";
    string pebblesCount = "0";
    string flowersCount = "0";
    string treeCount = "0";
    string longgrassCount = "0";
    string lilypadCount = "0";
    string saplingCount = "0";
    string fenceStraightCount = "0";
    string fenceCornerCount = "0";
    string fenceEndCount = "0";
    string lanternCount = "0";
    string lamppostCount = "0";
    string torchCount = "0";
    string floorlightCount = "0";
    string rainbowCount = "0";
    


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
        window.fileNumber = EditorGUI.TextField(new Rect(0, 40, position.width/2, 15), label: "Level number", text: window.fileNumber);
        window.feature1 = EditorGUI.TextField(new Rect(0, 60, position.width, 15), label: "Feature 1", text: window.feature1);
        window.feature2 = EditorGUI.TextField(new Rect(0, 80, position.width, 15), label: "Feature 2", text: window.feature2);



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




        int currentY = 180;
        int reqCount = 0;
        int maxReqCount = 4;

        if (grass && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.grassCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "grassCubes needed", text: window.grassCount);
        }
        if (dirt && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.dirtCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "dirtCubes needed", text: window.dirtCount);
        }
        if (sand && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.sandCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "sandCubes needed", text: window.sandCount);
        }
        if (snow && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.snowCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "snowCubes needed", text: window.snowCount);
        }
        if (paving && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.pavingCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "pavingCubes needed", text: window.pavingCount);
        }
        if (water && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.waterCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "waterCubes needed", text: window.waterCount);
        }
        if (pondwater && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.pondwaterCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "pondwaterCubes needed", text: window.pondwaterCount);
        }
        if (nuclear && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.nuclearCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "nuclearCubes needed", text: window.nuclearCount);
        }
        if (lava && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.lavaCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "lavaCubes needed", text: window.lavaCount);
        }
        if (ice && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.iceCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "iceCubes needed", text: window.iceCount);
        }
        if (fire && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.fireCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "fireCubes needed", text: window.fireCount);
        }
        if (wood && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.woodCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "woodCubes needed", text: window.woodCount);
        }
        if (stone && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.stoneCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "stoneCubes needed", text: window.stoneCount);
        }
        if (burning && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.burningCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "burningCubes needed", text: window.burningCount);
        }
        if (pebbles && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.pebblesCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "pebblesCubes needed", text: window.pebblesCount);
        }
        if (flowers && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.flowersCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "flowersCubes needed", text: window.flowersCount);
        }
        if (tree && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.treeCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "treeCubes needed", text: window.treeCount);
        }
        if (longgrass && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.longgrassCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "longgrassCubes needed", text: window.longgrassCount);
        }
        if (lilypad && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.lilypadCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "lilypadCubes needed", text: window.lilypadCount);
        }
        if (sapling && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.saplingCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "saplingCubes needed", text: window.saplingCount);
        }
        if (fenceStraight && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.fenceStraightCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "fenceStraightCubes needed", text: window.fenceStraightCount);
        }
        if (fenceCorner && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.fenceCornerCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "fenceCornerCubes needed", text: window.fenceCornerCount);
        }
        if (fenceEnd && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.fenceEndCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "fenceEndCubes needed", text: window.fenceEndCount);
        }
        if (lantern && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.lanternCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "lanternCubes needed", text: window.lanternCount);
        }
        if (lamppost && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.lamppostCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "lamppostCubes needed", text: window.lamppostCount);
        }
        if (torch && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.torchCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "torchCubes needed", text: window.torchCount);
        }
        if (floorlight && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.floorlightCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "floorlightCubes needed", text: window.floorlightCount);
        }
        if (rainbow && reqCount < maxReqCount)
        {
            reqCount++;
            currentY += 30;
            window.rainbowCount = EditorGUI.TextField(new Rect(0, currentY, position.width, 15), label: "rainbowCubes needed", text: window.rainbowCount);
        }
        
        currentY += 30;

        
        



        if (GUI.Button(new Rect(10, currentY, position.width/2, 15), text: "Save"))
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

        int numOfReqs = 0;

        if (grass)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "grass");
            xmlWriter.WriteAttributeString("Count", grassCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (dirt)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "dirt");
            xmlWriter.WriteAttributeString("Count", dirtCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (sand)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "sand");
            xmlWriter.WriteAttributeString("Count", sandCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (snow)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "snow");
            xmlWriter.WriteAttributeString("Count", snowCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (paving)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "paving");
            xmlWriter.WriteAttributeString("Count", pavingCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (water)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "water");
            xmlWriter.WriteAttributeString("Count", waterCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (pondwater)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "pondwater");
            xmlWriter.WriteAttributeString("Count", pondwaterCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (nuclear)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "nuclear");
            xmlWriter.WriteAttributeString("Count", nuclearCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (lava)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "lava");
            xmlWriter.WriteAttributeString("Count", lavaCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (ice)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "ice");
            xmlWriter.WriteAttributeString("Count", iceCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (fire)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "fire");
            xmlWriter.WriteAttributeString("Count", fireCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (wood)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "wood");
            xmlWriter.WriteAttributeString("Count", woodCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (stone)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "stone");
            xmlWriter.WriteAttributeString("Count", stoneCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (burning)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "burning");
            xmlWriter.WriteAttributeString("Count", burningCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (pebbles)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "pebbles");
            xmlWriter.WriteAttributeString("Count", pebblesCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (flowers)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "flowers");
            xmlWriter.WriteAttributeString("Count", flowersCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (tree)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "tree");
            xmlWriter.WriteAttributeString("Count", treeCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (longgrass)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "longgrass");
            xmlWriter.WriteAttributeString("Count", longgrassCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (lilypad)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "lilypad");
            xmlWriter.WriteAttributeString("Count", lilypadCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        if (sapling)
        {
            xmlWriter.WriteStartElement("RequiredBlocks");
            xmlWriter.WriteAttributeString("CubeType", "sapling");
            xmlWriter.WriteAttributeString("Count", saplingCount);
            xmlWriter.WriteEndElement();
            numOfReqs++;
        }
        
        xmlWriter.WriteStartElement("NumberOfRequirements");
        xmlWriter.WriteString(numOfReqs.ToString());
        xmlWriter.WriteEndElement();


        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();

        xmlWriter.Close();
    }
}
*/

