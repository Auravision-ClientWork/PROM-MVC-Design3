using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InputType
{
    Joystick,
    ScreenDrag,

}
public class InputManager : MonoBehaviour
{
    #region Singleton Setup
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;

    }
    #endregion

    //reference to the controllers
    public TouchInputController touchInputController;
    public JoystickController joystickController;
    public GameObject joyStickPanel;
    public GameObject cameraSettingsPanel;
    public Slider cameraSpeedSlider;
    public float maxCameraSpeed = 2;
    public float cameraSpeed { get; private set; }
    public event Action<float> OnCameraSpeedSet;

    public InputType inputType = InputType.Joystick;

    private bool isCameraSettingsOn;

    private void Start()
    {
        //cameraSpeedSlider.maxValue = maxCameraSpeed;
        cameraSettingsPanel.SetActive(false);
    }

    private void Update()
    {
        switch (inputType)
        {
            case InputType.Joystick:
                //disable TouchController, Enable JoystickController
                touchInputController.enabled = false;
                joystickController.enabled = true;
                joyStickPanel.SetActive(true);
                break;
            case InputType.ScreenDrag:
                //disable JoystickController, Enable TouchController
                touchInputController.enabled = true;
                joystickController.enabled = false;
                joyStickPanel.SetActive(false);
                break;
        }
    }

    public void ToggleJoystickControlsOnOff()
    {
        if (inputType == InputType.Joystick)
        {
            inputType = InputType.ScreenDrag;

        }
        else if (inputType == InputType.ScreenDrag)
        {
            inputType = InputType.Joystick;
        }
    }

    public void ToggleCameraSettingsControlsOnOff()
    {
        if (isCameraSettingsOn == true)
        {
            cameraSettingsPanel.SetActive(false);
            isCameraSettingsOn = false;
        }
        else if (isCameraSettingsOn == false)
        {
            cameraSettingsPanel.SetActive(true);
            isCameraSettingsOn = true;
        }
    }

    public void SetCameraSpeed(float newVal)
    {
      
        cameraSpeed = newVal;
        OnCameraSpeedSet?.Invoke(cameraSpeed);
    }
}
