using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SaveToXMLScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SaveToXMLFile(GameObject.Find("FloorCubeSpawner").GetComponent<FloorCubeSpawnerScript>().floorCubes, "saveTest");
        }
    }

    /*public static void SaveToXMLFile(int[,,] voxelArray, string fileName, Vector3 position)
    {
        XmlWriterSettings writerSettings = new XmlWriterSettings();
        writerSettings.Indent = true;
        // Create a write instance
        XmlWriter xmlWriter = XmlWriter.Create(fileName + ".xml", writerSettings);
        
        // Write the beginning of the document
        xmlWriter.WriteStartDocument();
        // Create the root element
        xmlWriter.WriteStartElement("VoxelChunk");

        // iterate through all array elements
        for (int x = 0; x < voxelArray.GetLength(0); x++)
        {
            for (int y = 0; y < voxelArray.GetLength(1); y++)
            {
                for (int z = 0; z < voxelArray.GetLength(1); z++)
                {
                    if (voxelArray[x, y, z] != 0)
                    {
                        // Create a single voxel element
                        xmlWriter.WriteStartElement("Voxel");

                        // Write an attribute to store the x index
                        xmlWriter.WriteAttributeString("x", x.ToString());
                        // Write an attribute to store the y index
                        xmlWriter.WriteAttributeString("y", y.ToString());
                        // Write an attribute to store the z index
                        xmlWriter.WriteAttributeString("z", z.ToString());

                        // Store the voxel type
                        xmlWriter.WriteString(voxelArray[x, y, z].ToString());

                        // End the voxel element
                        xmlWriter.WriteEndElement();
                    }
                }
            }
        }

        xmlWriter.WriteStartElement("Position");
        xmlWriter.WriteAttributeString("x", position.x.ToString());
        xmlWriter.WriteAttributeString("y", position.y.ToString());
        xmlWriter.WriteAttributeString("z", position.z.ToString());

        // End the root element
        xmlWriter.WriteEndElement();
        
        // Write the end of the document
        xmlWriter.WriteEndDocument();
        // Close the document to save
        xmlWriter.Close();

    }*/

    public static void SaveToXMLFile(List<GameObject> floorCubes, string fileName)
    {
        XmlWriterSettings writerSettings = new XmlWriterSettings();
        writerSettings.Indent = true;
        // Create a write instance
        XmlWriter xmlWriter = XmlWriter.Create(fileName + ".xml", writerSettings);
        
        xmlWriter.WriteStartDocument();
        // Create the root element
        xmlWriter.WriteStartElement("FloorCubes");

        // iterate through all array elements
        for (int i = 0; i < floorCubes.Count; i++)
        {
            xmlWriter.WriteStartElement("FloorCube" + i.ToString());
            
            // Write the cube position
            xmlWriter.WriteStartElement("Position");
            xmlWriter.WriteAttributeString("x", floorCubes[i].transform.position.x.ToString());
            xmlWriter.WriteAttributeString("y", floorCubes[i].transform.position.y.ToString());
            xmlWriter.WriteAttributeString("z", floorCubes[i].transform.position.z.ToString());
            xmlWriter.WriteEndElement();

            // Write if the cube is a black floor cube
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

            xmlWriter.WriteEndElement();
        }

        // End the root element
        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();
        xmlWriter.Close();
    }
}
