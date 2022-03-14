using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAnim : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractDoor()
    {
        if(isOpened)
        {
            isOpened = false;
            animator.SetBool("isClosing", true);
            animator.SetBool("isOpening", false);
        }
        else
        {
            isOpened = true;
            animator.SetBool("isClosing", false);
            animator.SetBool("isOpening", true);
        }
    }
}
