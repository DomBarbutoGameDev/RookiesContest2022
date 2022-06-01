using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    [SerializeField] private bool _playerWithinRange;
    [SerializeField] private bool _hasInteractedYet;
    [SerializeField] private bool _isPlayingDice;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            //Only changes to interactable canvas for cutscene trigger if is hasn't been played yet OR
            //It is the dice game trigger
            if((GetComponent<CutsceneStart>() && !_hasInteractedYet) || GetComponent<SwitchGameStart>())
            {
                //Parameter of 2 is index of canvasArray, holding canvasInteract
                uiController.SetCurrentCanvas(2);
                _playerWithinRange = true;
            }

            if(GetComponent<SwitchGameStart>())
            {
                //Parameter of 6 is index of canvasArray, holding canvasInteract
                uiController.SetCurrentCanvas(6);
                _playerWithinRange = true;
            }

        }
    }

    private void Update()
    {
        if (_playerWithinRange && Input.GetKeyUp(KeyCode.F))
        {
            Activate();

            //If this interactable was the Switch Game Start interactable (at the cardboard), then switch to that canvas
            if (GetComponent<SwitchGameStart>())
            {
                Debug.Log("In update, switching to game canvas");
                uiController.SetCurrentCanvas(4);
            }
        }
        
    }

    public virtual void Activate()
    {
        _hasInteractedYet = true;
        //Hide current canvas
        uiController.GetActiveCanvas().SetActive(false);
    }

    public virtual void Deactivate()
    {
        //_hasInteractedYet = true;
        //Hide current canvas
        uiController.GetActiveCanvas().SetActive(false);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _playerWithinRange = false;

            if (_hasInteractedYet || GetComponent<SwitchGameStart>())
            {

                //Parameter of 3 is index of canvasArray, holding canvasExplore3
                uiController.SetCurrentCanvas(3);
            }
            /*else if (GetComponent<SwitchGameStart>())
            {
                //Parameter of 2 is index of canvasArray, holding canvasExplore2
                uiController.SetCurrentCanvas(2);
            }*/
            else
            {
                //Parameter of 2 is index of canvasArray, holding canvasExplore1
                uiController.SetCurrentCanvas(1);
            }
            
        }
    }
}
