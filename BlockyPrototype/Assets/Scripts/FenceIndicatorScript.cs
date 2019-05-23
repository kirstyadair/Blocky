using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FenceIndicatorScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public MenuScript menuScript;
    public GameObject indicator;
    public Image indicatorImage;

    public Sprite straight0;
    public Sprite straight90;
    public Sprite corner0;
    public Sprite corner90;
    public Sprite corner180;
    public Sprite corner270;

    public int woodRotation = 0;



    
    void Start()
    {
        indicator.SetActive(false);
    }




    
    void Update()
    {
        if (menuScript.currentOpenMenu == MenuOpen.FENCES && playerScript.floorDrawingPanelAnim.GetBool("slideIn"))
        {
            if (playerScript.cubeType == CubeType.FENCE)
            {
                indicator.SetActive(true);
                if (woodRotation == 0 || woodRotation == 180)
                {
                    indicatorImage.sprite = straight0;
                }
                else
                {
                    indicatorImage.sprite = straight90;
                }
            }
            else if (playerScript.cubeType == CubeType.FENCECORNER)
            {
                indicator.SetActive(true);
                if (woodRotation == 0)
                {
                    indicatorImage.sprite = corner0;
                }
                else if (woodRotation == 90)
                {
                    indicatorImage.sprite = corner90;
                }
                else if (woodRotation == 180)
                {
                    indicatorImage.sprite = corner180;
                }
                else if (woodRotation == 270)
                {
                    indicatorImage.sprite = corner270;
                }
            }
        }
        else
        {
            indicator.SetActive(false);
        }
    }




    public void RotateFence()
    {
        woodRotation += 90;
        if (woodRotation == 360)
        {
            woodRotation = 0;
        }
    }
}
