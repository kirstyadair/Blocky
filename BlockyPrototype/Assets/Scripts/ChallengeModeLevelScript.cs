using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeModeLevelScript : MonoBehaviour
{
    public Animator popupAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CloseMenu()
    {
        popupAnim.SetBool("introOut", true);
    }
}
