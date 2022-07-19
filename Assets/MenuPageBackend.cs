using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPageBackend : MonoBehaviour
{
    public GameObject goToScoresButton;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
           goToScoresButton.SetActive(false);
        }
        else
        {
            goToScoresButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
