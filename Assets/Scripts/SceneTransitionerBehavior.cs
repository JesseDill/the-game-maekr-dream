using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionerBehavior : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera currentCam;
    [SerializeField] CinemachineVirtualCamera nextCam;
    [SerializeField] GameObject player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            transitionToNextCamera();
            //gameObject.SetActive(false);
        }
    }

    private void transitionToNextCamera()
    {     
        int oldCur = currentCam.Priority;
        int oldNext = nextCam.Priority;
        currentCam.Priority = oldNext;
        nextCam.Priority = oldCur;
    }
}
