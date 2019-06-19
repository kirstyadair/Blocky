using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SaveToXMLScript : MonoBehaviour
{
    public GameObject[] floorCubes;
    public RestartScript restartScript;
    GameData gameData;
    public Material grassMaterial;
    public Material sandMaterial;
    public Material snowMaterial;
    public Material dirtMaterial;
    public Material standardMaterial;

    public GameObject fire;
    public GameObject burning;
    public GameObject longgrass;
    public GameObject tree;
    public GameObject flowers;
    public GameObject stone;
    public GameObject wood;
    public GameObject lantern;
    public GameObject fence;
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
    public List<CubeToSpawn> cubesToSpawnList;
    string readBlankCubeType;
    int floorCubeCount;


    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        cubesToSpawnList = new List<CubeToSpawn>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            floorCubes = GameObject.FindGameObjectsWithTag("Floor");
            SaveFloorToXMLFile(floorCubes, "saveTest", gameData.blankCubeType);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
             
            cubesToSpawnList = ReadFloorFromXML("saveTest");
            Debug.Log(cubesToSpawnList.Count);

            StartCoroutine(LoadInCubes());
            
        }
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
            /* else if (floorCubes[i].GetComponent<FenceCubeScript>() != null)
            {
                xmlWriter.WriteString("Fence");
                xmlWriter.WriteStartElement("FenceType");
                xmlWriter.WriteAttributeString("Rotation", floorCubes[i].GetComponent<FenceCubeScript>().rotation.ToString());
                xmlWriter.WriteAttributeString("IsCorner", floorCubes[i].GetComponent<FenceCubeScript>().isCorner.ToString());
                xmlWriter.WriteEndElement();
            }*/
            else if (floorCubes[i].GetComponent<LilypadCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Lilypad");
            }
            else if (floorCubes[i].GetComponent<LamppostCubeScript>() != null)
            {
                xmlWriter.WriteAttributeString("CubeType", "Lamppost");
            }

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
                                        newCube.cubePrefab = fence;
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
                                }
                            }
                        }
                    }
                }
            }
        }

        return cubes;
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
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < cubesToSpawnList.Count; i++)
        {
            if (cubesToSpawnList[i].cubePrefab != null)
            {
                if (readBlankCubeType == "GRASS" && cubesToSpawnList[i].cubePrefab != grass || readBlankCubeType == "SAND" && cubesToSpawnList[i].cubePrefab != sand || readBlankCubeType == "SNOW" && cubesToSpawnList[i].cubePrefab != snow || readBlankCubeType == "DIRT" && cubesToSpawnList[i].cubePrefab != dirt)
                {
                    GameObject newCube = Instantiate(cubesToSpawnList[i].cubePrefab, cubesToSpawnList[i].position, Quaternion.identity); 
                    newCube.tag = "Floor";
                }
                else
                {
                    GameObject newCube = Instantiate(cubesToSpawnList[i].cubePrefab, cubesToSpawnList[i].position, Quaternion.identity);
                    newCube.GetComponent<Renderer>().material = standardMaterial;
                }
                   
            }
            
        }
    }
}


public class CubeToSpawn
{
    public Vector3 position;
    public GameObject cubePrefab;
}
