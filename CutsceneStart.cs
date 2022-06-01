using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SignalReceiver))]
public class CutsceneStart : Interactable
{
    [SerializeField] private GameObject _cutsceneToStart;
    [SerializeField] private GameObject _switchGameStart;

    public override void Activate()
    {
        base.Activate();
        _cutsceneToStart.SetActive(true);
        PlayerController.Instance.CutsceneCamera.SetActive(true);
        PlayerController.Instance.CutscenePlayerCamera.SetActive(true);
        PlayerController.Instance.FirstPersonCamera.SetActive(false);
        //Stop player from being able to move
        PlayerController.Instance.Deactivate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _cutsceneToStart.SetActive(false);
        PlayerController.Instance.CutsceneCamera.SetActive(false);
        PlayerController.Instance.CutscenePlayerCamera.SetActive(false);
        PlayerController.Instance.FirstPersonCamera.SetActive(true);
        //Let Player move again
        PlayerController.Instance.Activate();
        _switchGameStart.SetActive(true);
    }
}
