using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResponseButton : MonoBehaviour
{
    public Button btn;
    public TMP_Text buttonText;
    public void SetUpResponseButton(int _scoreMultiplier,string _btnText)
    {
        buttonText.text = _btnText; 
        btn.onClick.AddListener(()=>SetScore(_scoreMultiplier));
    }

    private void SetScore(int _scoreMultiplier)
    {
        ScoreBackend.Instance.SetSelectedScore(_scoreMultiplier);
    }
}
