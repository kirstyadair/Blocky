using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationScript : MonoBehaviour
{
    public int rotationMode = 0;
    Animator cameraAnim;

    void Start()
    {
        cameraAnim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void Rotate()
    {
        rotationMode++;
        if (rotationMode > 4)
        {
            rotationMode = 1;
        }
        cameraAnim.SetInteger("RotationMode", rotationMode);
    }
}
