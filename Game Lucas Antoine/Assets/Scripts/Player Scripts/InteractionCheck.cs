using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCheck : MonoBehaviour
{
    private void Update()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(transform.position + new Vector3(0f,0.1f,0f), transform.forward*3, Color.red);

        if (Physics.Raycast(transform.position + new Vector3(0f,0.1f,0f), transform.forward, out hitInfo, 3))
        {
            Debug.Log(hitInfo.transform.name);
        }
    }
}
