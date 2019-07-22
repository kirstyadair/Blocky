using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeModeLevelScript : MonoBehaviour
{
    public Animator popupAnim;
    public GameObject[] allCubes;
    public GameObject doneButton;
    public GameObject finishedPopup;
    SaveToXMLScript saveScript;

    public int[] cubeCounts;
    public Text[] cubeCountTexts;
    public bool[] hasHitObjective;

    // Start is called before the first frame update
    void Start()
    {
        saveScript = GameObject.Find("SaveObject").GetComponent<SaveToXMLScript>();
        doneButton.SetActive(false);
        finishedPopup.SetActive(false);
    }

    public void CloseMenu()
    {
        popupAnim.SetBool("introOut", true);
    }


    public void StartBlockCheck(List<CubeType> monitoredCubes)
    {
        hasHitObjective = new bool[monitoredCubes.Count];
        StartCoroutine(CheckBlockCount(monitoredCubes));
    }


    public void DoneButtonPressed()
    {
        finishedPopup.SetActive(true);
    }


    IEnumerator CheckBlockCount(List<CubeType> monitoredCubes)
    {
        

        for (int i = 0; i < 4; i++)
        {
            cubeCounts[i] = 0;
        }

        allCubes = GameObject.FindGameObjectsWithTag("Floor");
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < allCubes.Length; i++)
        {
            if (allCubes[i] != null)
            {
                for (int j = 0; j < monitoredCubes.Count; j++)
                {
                    if (allCubes[i].GetComponent<BaseCubeScript>().thisCubeType == monitoredCubes[j])
                    {
                        cubeCounts[j]++;
                    }
                    cubeCountTexts[j].text = cubeCounts[j].ToString();

                    if (cubeCounts[j] >= int.Parse(saveScript.neededCubeCount[j]))
                    {
                        cubeCountTexts[j].color = Color.green;
                        hasHitObjective[j] = true;
                    }
                    else
                    {
                        hasHitObjective[j] = false;
                        cubeCountTexts[j].color = new Color(1, 0.56f, 0.56f);
                    }
                }
            }
        }
        
        int numOfHitObj = 0;
        for (int i = 0; i < hasHitObjective.Length; i++)
        {
            if (hasHitObjective[i] == true)
            {
                numOfHitObj++;
            }
            
            if (numOfHitObj == hasHitObjective.Length)
            {
                doneButton.SetActive(true);
            }
        }
        StartCoroutine(CheckBlockCount(monitoredCubes));
    }
}
