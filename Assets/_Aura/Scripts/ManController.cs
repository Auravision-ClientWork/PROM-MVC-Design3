using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{
    public GameObject TouchControllerInterface;
     
    void Start()
    {
        ToggleTurnController();
    }
    public void ToggleTurnController()
    {
        TouchControllerInterface.SetActive(!TouchControllerInterface.activeInHierarchy);
    }
}
