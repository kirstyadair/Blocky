using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float growAmount = 0;
    float shrinkAmount = 0;
    public Animator animator;



    public void OnPointerEnter(PointerEventData eventData)
    {
        growAmount = 0;
        if (animator != null)
        {
            animator.SetBool("openPopup", true);
        }
        StartCoroutine(GrowButton());
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        shrinkAmount = 0;
        if (animator != null)
        {
            animator.SetBool("openPopup", false);
        }
        StartCoroutine(ShrinkButton());
    }



    IEnumerator GrowButton()
    {
        do 
        {
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            growAmount += 0.01f;
            yield return new WaitForSeconds(0.01f);
        } while (growAmount < 0.05f);
    }



    IEnumerator ShrinkButton()
    {
        do 
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            shrinkAmount += 0.01f;
            yield return new WaitForSeconds(0.01f);
        } while (shrinkAmount < 0.05f);
    }
}
