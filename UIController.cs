using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject[] canvasArray;
    [SerializeField] private int currentCanvasIndex;

    void Start()
    {
        
        
        
    }

    /**
     *  0=canvasMain
     *  1=canvasExplore1
     *  2=canvasInteract
     *  3=canvasExplore2
     *  4=canvasDiceGame
     *  5=canvasPause
     */
    public void SetCurrentCanvas(int i)
    {
        currentCanvasIndex = i;
        SwitchActivesInList(i);

    }
        
    /*
     * Iterates through canvasList deactiving each canvas, then activates selected
     * canvas.
     */
    public void SwitchActivesInList(int i)
    {
        Debug.Log("Setting active canvas to " + i);
        
        //Deactivate each canvas
        foreach(GameObject can in canvasArray)
        {
            can.SetActive(false);
        }
        
        //Activate selected canvas
        canvasArray[currentCanvasIndex].SetActive(true);
    }

    public GameObject GetActiveCanvas()
    {
        return canvasArray[currentCanvasIndex].gameObject;
    }
}
