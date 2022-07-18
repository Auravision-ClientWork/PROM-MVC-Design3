using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackNav : MonoBehaviour
{
    public void HandleBackButtonNavigation()
    {
        AudioManager.Instance.PlayNextBtnFX();
        UIController.Instance.ShowMenuPage();
    }
}
