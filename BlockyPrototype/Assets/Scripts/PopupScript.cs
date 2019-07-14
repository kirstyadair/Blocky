using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopupScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject panel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GetComponent<Animator>().GetBool("introOut"))
        {
            Color hoverColour = panel.GetComponent<Image>().material.color;
            hoverColour.a = 0.1f;
            panel.GetComponent<Image>().material.color = hoverColour;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color hoverColour = panel.GetComponent<Image>().material.color;
        hoverColour.a = 1f;
        panel.GetComponent<Image>().material.color = hoverColour;
    }   
}
