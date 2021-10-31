using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    [SerializeField]
    private Camera MainCam;

    [SerializeField]
    private bool useStaticBillboard;
    

    void LateUpdate()
    {
        if(!useStaticBillboard)
        {
            transform.LookAt(MainCam.transform);
        }else
        {
            transform.rotation = MainCam.transform.rotation;
        }
        
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

    }
}
