using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGround;

    private void OnTriggerEnter(Collider other)
    {
        isGround = true;
        Debug.Log("enter");
    }

    private void OnTriggerExit(Collider other)
    {
        isGround = false;
        Debug.Log("exit");
    }
}
