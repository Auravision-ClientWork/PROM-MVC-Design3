using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip nextBtnFx;
    public AudioClip selectionActionFX;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void PlayNextBtnFX()
    {
        audioSource.PlayOneShot(nextBtnFx);
    }
    public void PlaySelectionActionFX()
    {
        audioSource.PlayOneShot(selectionActionFX);

    }
}
