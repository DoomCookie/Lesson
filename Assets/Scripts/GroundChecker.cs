using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGround;

    private void OnCollisionEnter(Collision other)
    {
        isGround = true;
        Debug.Log("Enter");
    }

    private void OnCollisionExit(Collision other)
    {
        isGround = false;
        Debug.Log("Exit");
    }

}
