using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGameDialogue : MonoBehaviour
{
    //Audio clips for the two randomly chosen "4-5-6" 
    public AudioClip[] specialWinClipsArray;
    //Audio clips for the two randomly chosen "1-2-3" 
    public AudioClip[] specialLossClipsArray;
    //Audio clips for the randomly chosen "roll again" dialogues
    public AudioClip[] rollAgainClipsArray;
    //Plays random clip when player gets a score (a pair and the third die is the score)
    public AudioClip[] regularDialogueClipsArray;
    //Plays selected TRIPS dialogue
    public AudioClip[] tripsClipsArray;
    //Played randomly when dice land 
    public AudioClip[] diceLandingClipsArray;
    //Played randomly when dice are reset
    public AudioClip[] shuffleClipsArray;

    public AudioSource audioSource;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomWinClip()
    {
        audioSource.PlayOneShot(specialWinClipsArray[Random.Range(0, specialWinClipsArray.Length)], 1);
    }

    public void PlayRandomLossClip()
    {
        audioSource.PlayOneShot(specialLossClipsArray[Random.Range(0, specialLossClipsArray.Length)], 1);
        
    }

    public void PlayRandomRollAgainClip()
    {
        audioSource.PlayOneShot(rollAgainClipsArray[Random.Range(0, specialLossClipsArray.Length)], 1);
    }

    public void PlaySelectScoreDialogue(int i)
    {
        audioSource.PlayOneShot(regularDialogueClipsArray[i-1], 1f);
    }

    public void PlaySelectTripsDialogue(int i)
    {
        audioSource.PlayOneShot(tripsClipsArray[i - 1], 1f);
    }

    public void PlayRandomDiceLandingClip()
    {
        audioSource.PlayOneShot(diceLandingClipsArray[Random.Range(0, diceLandingClipsArray.Length)], 1);
    }

    public void PlayRandomShuffleClip()
    {
        audioSource.PlayOneShot(shuffleClipsArray[Random.Range(0, shuffleClipsArray.Length)], 1);
    }
}
