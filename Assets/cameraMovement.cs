using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField]private Transform target; //position of the character
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
         
    Vector3 cameraPos = target.position + offset + new Vector3(0, 5, -18);
        transform.position = cameraPos;
    }
}
