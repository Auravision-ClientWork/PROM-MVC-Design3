using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VideoPlayer))]
public class SplashController : MonoBehaviour
{
    [Header("Timing Properties.")]
    [SerializeField][Tooltip("Length of time in seconds b4 playing splash")]
    float delayLength;

    [SerializeField]
    [Tooltip("Length of time in seconds b4 loading intro scene after starting splash")]
    float splashLength;

    [Header("Video Properties")]
    [SerializeField] VideoPlayer splashPlayer;

    [Header("Splash triggered Events")]
    [SerializeField]
    UnityEvent OnSplashFinished = new UnityEvent();
    [SerializeField]
    UnityEvent OnSplashStarted = new UnityEvent();

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delayLength);
        //get the video player and play the splash
        if (OnSplashStarted != null)
        {
            OnSplashStarted.Invoke();
        }
        splashPlayer.Play();
        StartCoroutine(GoToBlinkIntro());
    }

    IEnumerator GoToBlinkIntro()
    {
        yield return new WaitForSeconds(splashLength);

        if(OnSplashFinished != null)
        {
            OnSplashFinished.Invoke();
        }

        SceneManager.LoadScene(1);
    }
}
