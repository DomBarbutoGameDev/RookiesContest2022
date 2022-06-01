using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(SignalReceiver))]
public class OpeningCutsceneStart : MonoBehaviour
{
    [SerializeField] private GameObject _cutsceneToStart;
    [SerializeField] UIController uiController;


    private void Start()
    {
        Activate();
    }

    public void Activate()
    {
        _cutsceneToStart.SetActive(true);
        PlayerController.Instance.CutsceneCamera.SetActive(true);
        PlayerController.Instance.FirstPersonCamera.SetActive(false);
        //Stop player from being able to move
        PlayerController.Instance.Deactivate();
    }

    public void Deactivate()
    {
        _cutsceneToStart.SetActive(false);
        PlayerController.Instance.CutsceneCamera.SetActive(false);
        PlayerController.Instance.FirstPersonCamera.SetActive(true);
        //Let Player move again
        PlayerController.Instance.Activate();
        //Set first canvas after opening cutscene
        uiController.SetCurrentCanvas(1);
    }
}
