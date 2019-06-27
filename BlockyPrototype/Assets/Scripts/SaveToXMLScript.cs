using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Windows;

public class SaveToXMLScript : MonoBehaviour
{
    public GameObject[] floorCubes;
    public PlayerScript playerScript;
    public List<GameObject> houseCubes;
    public RestartScript restartScript;
    public Animator clouds;
    GameData gameData;
    public Material grassMaterial;
    public Material sandMaterial;
    public Material snowMaterial;
    public Material dirtMaterial;
    public Material standardMaterial;
    public Material woodMaterial;
    public Material houseSnowMaterial;
    public Material brickMaterial;

    public GameObject fire;
    public GameObject burning;
    public GameObject longgrass;
    public GameObject tree;
    public GameObject flowers;
    public GameObject stone;
    public GameObject wood;
    public GameObject lantern;
    public GameObject fence;
    public GameObject fenceCorner;
    public GameObject fenceEnd;
    public GameObject fenceGate;
    public GameObject fenceArch;
    public GameObject lilypad;
    public GameObject lamppost;
    public GameObject grass;
    public GameObject dirt;
    public GameObject snow;
    public GameObject sand;
    public GameObject nuclear;
    public GameObject lava;
    public GameObject water;
    public GameObject pondwater;
    public GameObject paving;
    public GameObject ice;
    public GameObject sapling;
    public GameObject pebbles;
    public GameObject torch;
    public GameObject floorLight;
    public GameObject rainbowLight;

    public List<CubeToSpawn> cubesToSpawnList;
    public List<HouseCubeToColour> houseCubesList;

    public GameObject loadSlots;
    public GameObject saveSlots;

    public RawImage screenshot1;
    public RawImage screenshot2;
    public RawImage screenshot3;
    public string readBlankCubeType;
    string url;
    int floorCubeCount;


    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        cubesToSpawnList = new List<CubeToSpawn>();
        floorCubes = GameObject.FindGameObjectsWithTag("Floor");
        houseCubes = GameObject.Find("RequirementsObject").GetComponent<RequirementsGeneratorScript>().allCubes;
        houseCubesList = new List<HouseCubeToColour>();
        saveSlots.SetActive(false);
        loadSlots.SetActive(false);
        
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            
            if (!saveSlots.activeInHierarchy)
            {
                playerScript.savingOrLoading = true;
                clouds.SetBool("in", true);
                saveSlots.SetActive(true);
            }
            else
            {
                playerScript.savingOrLoading = false;
                clouds.SetBool("in", false);
                saveSlots.SetActive(false);
            }

            loadSlots.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (!loadSlots.activeInHierarchy)
            {
                playerScript.savingOrLoading = true;
                clouds.SetBool("in", true);
                loadSlots.SetActive(true);
                Texture2D screenshot = LoadTexture("saveScreenshot1.png");
                if (screenshot != null)
                {
                    screenshot1.texture = screenshot;
                }
                else
                {
                    screenshot1.enabled = false;
                }

                Texture2D screenshot2 = LoadTexture("saveScreenshot2.png");
                if (screenshot2 != null)
                {
                    this.screenshot2.texture = screenshot2;
                }
                else
                {
                    this.screenshot2.enabled = false;
                }

                Texture2D screenshot3 = LoadTexture("saveScreenshot3.png");
                if (screenshot3 != null)
                {
                    this.screenshot3.texture = screenshot3;
                }
                else
                {
                    this.screenshot3.enabled = false;
                }
                
            }
            else
            {
                playerScript.savingOrLoading = false;
                clouds.SetBool("in", false);
                loadSlots.SetActive(false);
            }
            
            saveSlots.SetActive(false);
        }
    }

    public void SaveToSlot1()
    {
        
        floorCubes = GameObject.FindGameObjectsWithTag("Floor");
        houseCubes = GameObject.Find("RequirementsObject").GetComponent<RequirementsGeneratorScript>().allCubes;

        StartCoroutine(ScreenshotSave(1));
        SaveFloorToXMLFile(floorCubes, "floorSave1", gameData.blankCubeType);
        SaveHouseToXMLFile(houseCubes, "houseSave1");

        saveSlots.SetActive(false);
        clouds.SetBool("in", false);
        playerScript.savingOrLoading = false;
    }

    public void LoadSave1()
    {
        cubesToSpawnList = ReadFloorFromXML("floorSave1");
        houseCubesList = ReadHouseCubesFromXML("houseSave1");

        

        StartCoroutine(LoadInCubes());
        StartCoroutine(ColourHouseCubes());

        loadSlots.SetActive(false);
        clouds.SetBool("in", false);
        playerScript.savingOrLoading = false;
    }
    
    public void SaveToSlot2()
    {
        floorCubes = GameObject.FindGameObjectsWithTag("Floor");
        houseCubes = GameObject.Find("RequirementsObject").GetComponent<RequirementsGeneratorScript>().allCubes;

        StartCoroutine(ScreenshotSave(2));
        SaveFloorToXMLFile(floorCubes, "floorSave2", gameData.blankCubeType);
        SaveHouseToXMLFile(houseCubes, "houseSave2");

        saveSlots.SetActive(false);
        clouds.SetBool("in", false);
        playerScript.savingOrLoading = false;
    }

    public void LoadSave2()
    {
        cubesToSpawnList = ReadFloorFromXML("floorSave2");
        houseCubesList = ReadHouseCubesFromXML("houseSave2");

        StartCoroutine(LoadInCubes());
        StartCoroutine(ColourHouseCubes());

        loadSlots.SetActive(false);
        clouds.SetBool("in", false);
        playerScript.savingOrLoading = false;
    }
    
    public void SaveToSlot3()
    {
        floorCubes = GameObject.FindGameObjectsWithTag("Floor");
        houseCubes = GameObject.Find("RequirementsObject").GetComponent<RequirementsGeneratorScript>().allCubes;

        StartCoroutine(ScreenshotSave(3));
        SaveFloorToXMLFile(floorCubes, "floorSave3", gameData.blankCubeType);
        SaveHouseToXMLFile(houseCubes, "houseSave3");

        saveSlots.SetActive(false);
        clouds.SetBool("in", false);
        playerScript.savingOrLoading = false;
    }

    public void LoadSave3()
    {
        cubesToSpawnList = ReadFloorFromXML("floorSave3");
        houseCubesList = ReadHouseCubesFromXML("houseSave3");

        StartCoroutine(LoadInCubes());
        StartCoroutine(ColourHouseCubes());

        loadSlots.SetActive(false);
        clouds.SetBool("in", false);
        playerScript.savingOrLoading = false;
    }
    



///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////SAVING TO FILES//////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////SAVING TO FILES//////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////SAVING TO FILES//////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public static void SaveFloorToXMLFile(GameObject[] floorCubes, string fileName, CubeType blankCubeType)
    {
        XmlWriterSettings writerSettings = new XmlWriterSettings();
        writerSettings.Indent = true;
        // Create a write instance
        XmlWriter xmlWriter = XmlWriter.Create(fileName + ".xml", writerSettings);
        
        xmlWriter.WriteStartDocument();
        // Create the root element
        xmlWriter.WriteStartElement("FloorCubes");

        xmlWriter.WriteStartElement("BlankCubeType");
        xmlWriter.WriteString(blankCubeType.ToString());
        xmlWriter.WriteEndElement();

        xmlWriter.WriteStartElement("FloorCubeCount");
        xmlWriter.WriteString(floorCubes.Length.ToString());
        xmlWriter.WriteEndElement();




        // iterate through all array elements
        for (int i = 0; i < floorCubes.Length; i++)
        {
            xmlWriter.WriteStartElement("FloorCube");

            // Write the cube position
            xmlWriter.WriteStartElement("Details");
            xmlWriter.WriteAttributeString("x", floorCubes[i].transform.position.x.ToString());
            xmlWriter.WriteAttributeString("y", floorCubes[i].transform.position.y.ToString());
            xmlWriter.WriteAttributeString("z", floorCubes[i].transform.position.z.ToString());

            if (floorCubes[i].GetComponent<GrassCubeScript>() != null)
            {
                if (blankCubeType == CubeType.GRASS)
                {
                    xmlWriter.WriteAttributeString("CubeType", "Standard");
                }
                else
                {
                    xmlWriter.WriteAttributeString("CubeType", "Grass");
                }
                
            }
            else if (floorCubes[i].GetComponent<DirtCubeScript>() != null)
            {
                if (blankCubeType == CubeType.DIRT)
                {
                    xmlWriter.WriteAttributeString("CubeType", "Standard");
                }
                else
                {
                    xmlWriter.WriteAttributeString("CubeType", "Dirt");
                }
            }
            else if (floorCubes[i].GetComponent<SandCubeScript>() != null)
            {
                if (blankCubeType == CubeType.SAND)
                {
                    xmlWriter.WriteAttributeString("CubeType", "Standard");
                }
                else
                {
                    xmlWriter.WriteAttributeString("CubeType", "Sand");
                }
            }
            else if (floorCubes[i].GetComponent<SnowCubeScript>() != null)
            {
                if (blankCubeType == CubeType.SNOW)
                {
                    xmlWriter.WriteAttributeString("CubeType", "Standard");
                }
                else
                {
                    xmlWriter.WriteAttributeString("CubeType", "Snow");
                }
            }
            else if (floorCubes[i].GetComponent<PavingCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Paving");
            }
            else if (floorCubes[i].GetComponent<WaterCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Water");
            }
            else if (floorCubes[i].GetComponent<PondWaterCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "PondWater");
            }
            else if (floorCubes[i].GetComponent<NuclearCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Nuclear");
            }
            else if (floorCubes[i].GetComponent<LavaCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Lava");
            }
            else if (floorCubes[i].GetComponent<IceCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Ice");
            }


            else if (floorCubes[i].GetComponent<FireCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Fire");
            }
            else if (floorCubes[i].GetComponent<BurningCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Burning");
            }
            else if (floorCubes[i].GetComponent<LongGrassCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "LongGrass");
            }
            else if (floorCubes[i].GetComponent<TreeCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Tree");
            }
            else if (floorCubes[i].GetComponent<FlowerCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Flower");
            }
            else if (floorCubes[i].GetComponent<StoneCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Stone");
            }
            else if (floorCubes[i].GetComponent<WoodCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Wood");
            }
            else if (floorCubes[i].GetComponent<LanternCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Lantern");
            }
            else if (floorCubes[i].GetComponent<FenceCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Fence");
                xmlWriter.WriteStartElement("FenceType");
                xmlWriter.WriteAttributeString("Rotation", floorCubes[i].GetComponent<FenceCubeScript>().rotation.ToString());
                xmlWriter.WriteAttributeString("Type", floorCubes[i].GetComponent<FenceCubeScript>().type.ToString());
                xmlWriter.WriteEndElement();
            }
            else if (floorCubes[i].GetComponent<LilypadCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Lilypad");
            }
            else if (floorCubes[i].GetComponent<LamppostCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Lamppost");
            }
            else if (floorCubes[i].GetComponent<SaplingCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Sapling");
            }
            else if (floorCubes[i].GetComponent<PebblesCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Pebbles");
            }
            else if (floorCubes[i].GetComponent<TorchCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Torch");
            }
            /*else if (floorCubes[i].GetComponent<FloorLightCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "FloorLight");
            }
            else if (floorCubes[i].GetComponent<RainbowLightCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "RainbowLight");
            }*/

            xmlWriter.WriteEndElement();


            // Write if the cube is a black floor cube
            
            if (floorCubes[i].GetComponent<GrassCubeScript>() != null)
            {
                xmlWriter.WriteStartElement("BlackFloorCube");
                if (floorCubes[i].GetComponent<GrassCubeScript>().isBlackCube)
                {
                    xmlWriter.WriteString("true");
                }
                else
                {
                    xmlWriter.WriteString("false");
                }
                xmlWriter.WriteEndElement();
            } 
            else if (floorCubes[i].GetComponent<DirtCubeScript>() != null)
            {
                xmlWriter.WriteStartElement("BlackFloorCube");
                if (floorCubes[i].GetComponent<DirtCubeScript>().isBlackCube)
                {
                    xmlWriter.WriteString("true");
                }
                else
                {
                    xmlWriter.WriteString("false");
                }
                xmlWriter.WriteEndElement();
            }
            else if (floorCubes[i].GetComponent<SandCubeScript>() != null)
            {
                xmlWriter.WriteStartElement("BlackFloorCube");
                if (floorCubes[i].GetComponent<SandCubeScript>().isBlackCube)
                {
                    xmlWriter.WriteString("true");
                }
                else
                {
                    xmlWriter.WriteString("false");
                }
                xmlWriter.WriteEndElement();
            } 
            else if (floorCubes[i].GetComponent<SnowCubeScript>() != null)
            {
                xmlWriter.WriteStartElement("BlackFloorCube");
                if (floorCubes[i].GetComponent<SnowCubeScript>().isBlackCube)
                {
                    xmlWriter.WriteString("true");
                }
                else
                {
                    xmlWriter.WriteString("false");
                }
                xmlWriter.WriteEndElement();
            }
            
            


            

            xmlWriter.WriteEndElement();
        }

        // End the root element
        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();
        xmlWriter.Close();
    }
















    public void SaveHouseToXMLFile(List<GameObject> houseCubes, string fileName)
    {
        XmlWriterSettings writerSettings = new XmlWriterSettings();
        writerSettings.Indent = true;
        // Create a write instance
        XmlWriter xmlWriter = XmlWriter.Create(fileName + ".xml", writerSettings);
        
        xmlWriter.WriteStartDocument();
        // Create the root element
        xmlWriter.WriteStartElement("HouseCubes");

        for (int i = 0; i < houseCubes.Count; i++)
        {
            xmlWriter.WriteStartElement("HouseCube");
            if (houseCubes[i].GetComponent<CubeScript>().cubeMaterial == CubeMaterial.STANDARD)
            {
                xmlWriter.WriteAttributeString("Material", "Standard");
                xmlWriter.WriteAttributeString("Colour", ColorUtility.ToHtmlStringRGB(houseCubes[i].GetComponent<Renderer>().material.color));
                xmlWriter.WriteAttributeString("ID", houseCubes[i].GetComponent<CubeScript>().ID.ToString());
            }
            if (houseCubes[i].GetComponent<CubeScript>().cubeMaterial == CubeMaterial.GLASS)
            {
                xmlWriter.WriteAttributeString("Material", "Glass");
                xmlWriter.WriteAttributeString("Colour", ColorUtility.ToHtmlStringRGBA(houseCubes[i].GetComponent<Renderer>().material.color));
                xmlWriter.WriteAttributeString("ID", houseCubes[i].GetComponent<CubeScript>().ID.ToString());
            }
            if (houseCubes[i].GetComponent<CubeScript>().cubeMaterial == CubeMaterial.WOOD)
            {
                xmlWriter.WriteAttributeString("Material", "Wood");
                xmlWriter.WriteAttributeString("Colour", ColorUtility.ToHtmlStringRGB(houseCubes[i].GetComponent<Renderer>().material.color));
                xmlWriter.WriteAttributeString("ID", houseCubes[i].GetComponent<CubeScript>().ID.ToString());
            }
            if (houseCubes[i].GetComponent<CubeScript>().cubeMaterial == CubeMaterial.SNOW)
            {
                xmlWriter.WriteAttributeString("Material", "Snow");
                xmlWriter.WriteAttributeString("Colour", ColorUtility.ToHtmlStringRGB(houseCubes[i].GetComponent<Renderer>().material.color));
                xmlWriter.WriteAttributeString("ID", houseCubes[i].GetComponent<CubeScript>().ID.ToString());
            }
            if (houseCubes[i].GetComponent<CubeScript>().cubeMaterial == CubeMaterial.BRICK)
            {
                xmlWriter.WriteAttributeString("Material", "Brick");
                xmlWriter.WriteAttributeString("Colour", ColorUtility.ToHtmlStringRGB(houseCubes[i].GetComponent<Renderer>().material.color));
                xmlWriter.WriteAttributeString("ID", houseCubes[i].GetComponent<CubeScript>().ID.ToString());
            }
            xmlWriter.WriteEndElement();
        }

        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();
        xmlWriter.Close();

    }

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////READING FROM FILES///////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////READING FROM FILES///////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////READING FROM FILES///////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public List<CubeToSpawn> ReadFloorFromXML(string filename)
    {
        XmlReader xmlReader = XmlReader.Create(filename + ".xml");
        List<CubeToSpawn> cubes = new List<CubeToSpawn>();

        while (xmlReader.Read())
        {
            if (xmlReader.IsStartElement("FloorCubes"))
            {
                XmlReader floorcubesReader = xmlReader.ReadSubtree();

                while (floorcubesReader.Read())
                {
                    if (xmlReader.IsStartElement("BlankCubeType"))
                    {
                        readBlankCubeType = floorcubesReader.ReadString();
                        ChangeBlankCubeType();
                        
                    }

                    if (xmlReader.IsStartElement("FloorCubeCount"))
                    {
                        floorCubeCount = int.Parse(floorcubesReader.ReadString());
                    }

                   
                    if (xmlReader.IsStartElement("FloorCube"))
                    {
                        XmlReader individualCubeReader = xmlReader.ReadSubtree();

                        while (individualCubeReader.Read())
                        {
                            
                            CubeToSpawn newCube = new CubeToSpawn();

                            if(xmlReader.IsStartElement("Details"))
                            {
                                float xVal = float.Parse(individualCubeReader["x"]);
                                float yVal = float.Parse(individualCubeReader["y"]);
                                float zVal = float.Parse(individualCubeReader["z"]);

                                Vector3 pos = new Vector3(xVal, yVal, zVal);
                                cubes.Add(newCube);
                                newCube.position = pos;
                                
                                string cubeType = individualCubeReader["CubeType"];
                                if (cubeType != "Standard")
                                {
                                    
                                    if (cubeType == "Fire")
                                    {
                                        newCube.cubePrefab = fire;
                                    }
                                    if (cubeType == "Burning")
                                    {
                                        newCube.cubePrefab = burning;
                                    }
                                    if (cubeType == "LongGrass")
                                    {
                                        newCube.cubePrefab = longgrass;
                                    }
                                    if (cubeType == "Tree")
                                    {
                                        newCube.cubePrefab = tree;
                                    }
                                    if (cubeType == "Flower")
                                    {
                                        newCube.cubePrefab = flowers;
                                    }
                                    if (cubeType == "Stone")
                                    {
                                        newCube.cubePrefab = stone;
                                    }
                                    if (cubeType == "Wood")
                                    {
                                        newCube.cubePrefab = wood;
                                    }
                                    if (cubeType == "Lantern")
                                    {
                                        newCube.cubePrefab = lantern;
                                    }
                                    if (cubeType == "Fence")
                                    {
                                        XmlReader fenceIndividualCubeReader = xmlReader.ReadSubtree();

                                        while(fenceIndividualCubeReader.Read())
                                        {
                                            if (fenceIndividualCubeReader.IsStartElement("FenceType"))
                                            {
                                                newCube.fenceRotation = int.Parse(fenceIndividualCubeReader["Rotation"]);
                                                if (fenceIndividualCubeReader["Type"] == "CORNER")
                                                {
                                                    newCube.cubePrefab = fenceCorner;
                                                }
                                                else if (fenceIndividualCubeReader["Type"] == "END")
                                                {
                                                    newCube.cubePrefab = fenceEnd;
                                                }
                                                else if (fenceIndividualCubeReader["Type"] == "GATE")
                                                {
                                                    newCube.cubePrefab = fenceGate;
                                                }
                                                else if (fenceIndividualCubeReader["Type"] == "ARCH")
                                                {
                                                    newCube.cubePrefab = fenceArch;
                                                }
                                                else
                                                {
                                                    newCube.cubePrefab = fence;
                                                }
                                            }
                                        }
                                        
                                    }
                                    if (cubeType == "Lilypad")
                                    {
                                        newCube.cubePrefab = lilypad;
                                    }
                                    if (cubeType == "Lamppost")
                                    {
                                        newCube.cubePrefab = lamppost;
                                    }
                                    if (cubeType == "Grass")
                                    {
                                        newCube.cubePrefab = grass;
                                    }
                                    if (cubeType == "Dirt")
                                    {
                                        newCube.cubePrefab = dirt;
                                    }
                                    if (cubeType == "Sand")
                                    {
                                        newCube.cubePrefab = sand;
                                    }
                                    if (cubeType == "Snow")
                                    {
                                        newCube.cubePrefab = snow;
                                    }
                                    if (cubeType == "Paving")
                                    {
                                        newCube.cubePrefab = paving;
                                    }
                                    if (cubeType == "Water")
                                    {
                                        newCube.cubePrefab = water;
                                    }
                                    if (cubeType == "PondWater")
                                    {
                                        newCube.cubePrefab = pondwater;
                                    }
                                    if (cubeType == "Nuclear")
                                    {
                                        newCube.cubePrefab = nuclear;
                                    }
                                    if (cubeType == "Lava")
                                    {
                                        newCube.cubePrefab = lava;
                                    }
                                    if (cubeType == "Ice")
                                    {
                                        newCube.cubePrefab = ice;
                                    }
                                    if (cubeType == "Sapling")
                                    {
                                        newCube.cubePrefab = sapling;
                                    }
                                    if (cubeType == "Pebbles")
                                    {
                                        newCube.cubePrefab = pebbles;
                                    }
                                    if (cubeType == "Torch")
                                    {
                                        newCube.cubePrefab = torch;
                                    }
                                    if (cubeType == "FloorLight")
                                    {
                                        newCube.cubePrefab = floorLight;
                                    }
                                    if (cubeType == "RainbowLight")
                                    {
                                        newCube.cubePrefab = rainbowLight;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return cubes;
    }








    public List<HouseCubeToColour> ReadHouseCubesFromXML(string filename)
    {
        XmlReader xmlReader = XmlReader.Create(filename + ".xml");
        List<HouseCubeToColour> readHouseCubes = new List<HouseCubeToColour>();
        

        while (xmlReader.Read())
        {
            if (xmlReader.IsStartElement("HouseCubes"))
            {
                XmlReader houseCubeReader = xmlReader.ReadSubtree();

                while (houseCubeReader.Read())
                {
                    if (houseCubeReader.IsStartElement("HouseCube"))
                    {
                        HouseCubeToColour readCube = new HouseCubeToColour();
                        readHouseCubes.Add(readCube);

                        if (houseCubeReader["Material"] == "Standard")
                        {
                            readCube.material = CubeMaterial.STANDARD;
                        }
                        if (houseCubeReader["Material"] == "Glass")
                        {
                            readCube.material = CubeMaterial.GLASS;
                        }
                        if (houseCubeReader["Material"] == "Snow")
                        {
                            readCube.material = CubeMaterial.SNOW;
                        }
                        if (houseCubeReader["Material"] == "Wood")
                        {
                            readCube.material = CubeMaterial.WOOD;
                        }
                        if (houseCubeReader["Material"] == "Brick")
                        {
                            readCube.material = CubeMaterial.BRICK;
                        }

                        Color readColour;
                        string hexColour ="#" + houseCubeReader["Colour"];
                        if(ColorUtility.TryParseHtmlString(hexColour, out readColour))
                        {
                            readCube.color = readColour;
                        }

                        readCube.ID = houseCubeReader["ID"];
                    }
                    
                }
            }
        }

        return readHouseCubes;
    }





///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////END OF READING FILES/////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////END OF READING FILES/////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////END OF READING FILES/////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





    void ChangeBlankCubeType()
    {
        if (readBlankCubeType == "GRASS")
            {
                if (gameData.blankCubeType != CubeType.GRASS)
                {
                    GameObject[] floor = GameObject.FindGameObjectsWithTag("Floor");
                    foreach (GameObject floorCube in floor)
                    {
                        if (gameData.blankCubeType == CubeType.DIRT)
                        {
                            if (floorCube.name == "DirtCube")
                            {
                                Destroy(floorCube.GetComponent<DirtCubeScript>());
                                floorCube.AddComponent<GrassCubeScript>();
                                floorCube.GetComponent<Renderer>().material = grassMaterial;
                                
                            }
                        }
                        if (gameData.blankCubeType == CubeType.SAND)
                        {
                            if (floorCube.name == "SandCube")
                            {
                                Destroy(floorCube.GetComponent<SandCubeScript>());
                                floorCube.AddComponent<GrassCubeScript>();
                                floorCube.GetComponent<Renderer>().material = grassMaterial;
                                
                            }
                        }
                        if (gameData.blankCubeType == CubeType.SNOW)
                        {
                            if (floorCube.name == "SnowCube")
                            {
                                Destroy(floorCube.GetComponent<SnowCubeScript>());
                                floorCube.AddComponent<GrassCubeScript>();
                                floorCube.GetComponent<Renderer>().material = grassMaterial;
                                
                            }
                        }
                    }
                    gameData.blankCubeType = CubeType.GRASS;
                    GameObject.Find("PlayerObject").GetComponent<PlayerScript>().cubeType = CubeType.NULL;
                }
            } 
            else if (readBlankCubeType == "DIRT")
            {
                if (gameData.blankCubeType != CubeType.DIRT)
                {
                    GameObject[] floor = GameObject.FindGameObjectsWithTag("Floor");
                    foreach (GameObject floorCube in floor)
                    {
                        if (gameData.blankCubeType == CubeType.GRASS)
                        {
                            if (floorCube.name == "GrassCube")
                            {
                                Destroy(floorCube.GetComponent<GrassCubeScript>());
                                floorCube.AddComponent<DirtCubeScript>();
                                floorCube.GetComponent<Renderer>().material = dirtMaterial;
                                
                            }
                        }
                        if (gameData.blankCubeType == CubeType.SAND)
                        {
                            if (floorCube.name == "SandCube")
                            {
                                Destroy(floorCube.GetComponent<SandCubeScript>());
                                floorCube.AddComponent<DirtCubeScript>();
                                floorCube.GetComponent<Renderer>().material = dirtMaterial;
                                
                            }
                        }
                        if (gameData.blankCubeType == CubeType.SNOW)
                        {
                            if (floorCube.name == "SnowCube")
                            {
                                Destroy(floorCube.GetComponent<SnowCubeScript>());
                                floorCube.AddComponent<DirtCubeScript>();
                                floorCube.GetComponent<Renderer>().material = dirtMaterial;
                                
                            }
                            
                        }
                        
                    }
                    gameData.blankCubeType = CubeType.DIRT;
                    GameObject.Find("PlayerObject").GetComponent<PlayerScript>().cubeType = CubeType.NULL;
                }
            } 
            else if (readBlankCubeType == "SAND")
            {
                if (gameData.blankCubeType != CubeType.SAND)
                {
                    GameObject[] floor = GameObject.FindGameObjectsWithTag("Floor");
                    foreach (GameObject floorCube in floor)
                    {
                        if (gameData.blankCubeType == CubeType.GRASS)
                        {
                            if (floorCube.name == "GrassCube")
                            {
                                Destroy(floorCube.GetComponent<GrassCubeScript>());
                                floorCube.AddComponent<SandCubeScript>();
                                floorCube.GetComponent<Renderer>().material = sandMaterial;
                                
                            }
                        }
                        if (gameData.blankCubeType == CubeType.DIRT)
                        {
                            if (floorCube.name == "DirtCube")
                            {
                                Destroy(floorCube.GetComponent<DirtCubeScript>());
                                floorCube.AddComponent<SandCubeScript>();
                                floorCube.GetComponent<Renderer>().material = sandMaterial;
                                
                            }
                        }
                        if (gameData.blankCubeType == CubeType.SNOW)
                        {
                            if (floorCube.name == "SnowCube")
                            {
                                Destroy(floorCube.GetComponent<SnowCubeScript>());
                                floorCube.AddComponent<SandCubeScript>();
                                floorCube.GetComponent<Renderer>().material = sandMaterial;
                                
                            }
                        }
                    }
                    gameData.blankCubeType = CubeType.SAND;
                    GameObject.Find("PlayerObject").GetComponent<PlayerScript>().cubeType = CubeType.NULL;
                }
            } 
            else if (readBlankCubeType == "SNOW")
            {
                if (gameData.blankCubeType != CubeType.SNOW)
                {
                    GameObject[] floor = GameObject.FindGameObjectsWithTag("Floor");
                    foreach (GameObject floorCube in floor)
                    {
                        if (gameData.blankCubeType == CubeType.GRASS)
                        {
                            if (floorCube.name == "GrassCube")
                            {
                                Destroy(floorCube.GetComponent<GrassCubeScript>());
                                floorCube.AddComponent<SnowCubeScript>();
                                floorCube.GetComponent<Renderer>().material = snowMaterial;
                                
                            }
                        }
                        if (gameData.blankCubeType == CubeType.DIRT)
                        {
                            if (floorCube.name == "DirtCube")
                            {
                                Destroy(floorCube.GetComponent<DirtCubeScript>());
                                floorCube.AddComponent<SnowCubeScript>();
                                floorCube.GetComponent<Renderer>().material = snowMaterial;
                                
                            }
                        }
                        if (gameData.blankCubeType == CubeType.SAND)
                        {
                            if (floorCube.name == "SandCube")
                            {
                                Destroy(floorCube.GetComponent<SandCubeScript>());
                                floorCube.AddComponent<SnowCubeScript>();
                                floorCube.GetComponent<Renderer>().material = snowMaterial;
                                
                            }
                        }
                    }
                    gameData.blankCubeType = CubeType.SNOW;
                    GameObject.Find("PlayerObject").GetComponent<PlayerScript>().cubeType = CubeType.NULL;
                }
            } 
    }




    IEnumerator LoadInCubes()
    {
        restartScript.loading = true;
        yield return new WaitForSeconds(0.5f);
        restartScript.loading = false;

        for (int i = 0; i < cubesToSpawnList.Count; i++)
        {
            if (cubesToSpawnList[i].cubePrefab != null)
            {
                if (readBlankCubeType == "GRASS" && cubesToSpawnList[i].cubePrefab != grass || readBlankCubeType == "SAND" && cubesToSpawnList[i].cubePrefab != sand || readBlankCubeType == "SNOW" && cubesToSpawnList[i].cubePrefab != snow || readBlankCubeType == "DIRT" && cubesToSpawnList[i].cubePrefab != dirt)
                {
                    GameObject newCube = Instantiate(cubesToSpawnList[i].cubePrefab, cubesToSpawnList[i].position, Quaternion.identity); 
                    if (cubesToSpawnList[i].cubePrefab == fence || cubesToSpawnList[i].cubePrefab == fenceCorner)
                    {
                        newCube.transform.Rotate(transform.rotation.x, cubesToSpawnList[i].fenceRotation, transform.rotation.z);
                    }
                    newCube.tag = "Floor";
                }
                else
                {
                    GameObject newCube = Instantiate(cubesToSpawnList[i].cubePrefab, cubesToSpawnList[i].position, Quaternion.identity);
                    Debug.Log(cubesToSpawnList[i].cubePrefab);

                    if (cubesToSpawnList[i].cubePrefab == grass)
                    {
                        newCube.GetComponent<GrassCubeScript>().isBlackCube = true;
                    }
                    if (cubesToSpawnList[i].cubePrefab == dirt)
                    {
                        newCube.GetComponent<DirtCubeScript>().isBlackCube = true;
                    }
                    if (cubesToSpawnList[i].cubePrefab == sand)
                    {
                        newCube.GetComponent<SandCubeScript>().isBlackCube = true;
                    }
                    if (cubesToSpawnList[i].cubePrefab == snow)
                    {
                        newCube.GetComponent<SnowCubeScript>().isBlackCube = true;
                    }
                }
                   
            }
            
        }
    }

    IEnumerator ColourHouseCubes()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < houseCubesList.Count; i++)
        {
            foreach (GameObject cube in houseCubes)
            {
                if (cube.GetComponent<CubeScript>().ID == houseCubesList[i].ID)
                {
                    if (houseCubesList[i].material == CubeMaterial.STANDARD)
                    {
                        cube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
                        Material mat = cube.GetComponent<CubeScript>().standardMaterial;
                        cube.GetComponent<Renderer>().material = mat;

                        cube.GetComponent<Renderer>().material.color = houseCubesList[i].color;
                    }
                    if (houseCubesList[i].material == CubeMaterial.GLASS)
                    {
                        cube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.GLASS;
                        Material mat = cube.GetComponent<CubeScript>().standardMaterial;
                        cube.GetComponent<Renderer>().material = mat;

                        cube.GetComponent<Renderer>().material.color = houseCubesList[i].color;
                    }
                    if (houseCubesList[i].material == CubeMaterial.WOOD)
                    {
                        cube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.WOOD;
                        Material mat = cube.GetComponent<CubeScript>().woodMaterial;
                        cube.GetComponent<Renderer>().material = mat;

                        cube.GetComponent<Renderer>().material.color = houseCubesList[i].color;
                    }
                    if (houseCubesList[i].material == CubeMaterial.SNOW)
                    {
                        cube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.SNOW;
                        Material mat = cube.GetComponent<CubeScript>().snowMaterial;
                        cube.GetComponent<Renderer>().material = mat;

                        cube.GetComponent<Renderer>().material.color = houseCubesList[i].color;
                    }
                    if (houseCubesList[i].material == CubeMaterial.BRICK)
                    {
                        cube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.BRICK;
                        Material mat = cube.GetComponent<CubeScript>().brickMaterial;
                        cube.GetComponent<Renderer>().material = mat;

                        cube.GetComponent<Renderer>().material.color = houseCubesList[i].color;
                    }
                    
                }
            }
        }
    }



    IEnumerator ScreenshotSave(int screenshotSaveSlot)
    {
        yield return new WaitForSeconds(0.5f);
        ScreenCapture.CaptureScreenshot("saveScreenshot" + screenshotSaveSlot + ".png");
    }


    public static Texture2D LoadTexture(string filePath) 
    {

        Texture2D tex = null;
        byte[] fileData;

        if (System.IO.File.Exists(filePath))     
        {
            fileData = System.IO.File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

}


public class CubeToSpawn
{
    public Vector3 position;
    public GameObject cubePrefab;
    public int fenceRotation;
}


public class HouseCubeToColour
{
    public CubeMaterial material;
    public Color color;
    public string ID;
}
