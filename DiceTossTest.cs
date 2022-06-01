using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTossTest : MonoBehaviour
{
    [Header("Dice Settings")]
    public GameObject dicePrefab;
    public int numberOfDice = 3;
    //The spawn position of the players' dice is relative to the camera using the offset
    public Vector3 playerTossPosition;
    public Vector3 playerTossPositionOffset = new Vector3(0.5f, 0.5f, -0.2f);
    
    public List<GameObject> diceInPlay;
    public List<int> diceInOrder;
    public bool canRoll = true;
    public bool rollDone = false;
    public float countWaitTime = 1f;

    [Header("CeeLo Settings")]
    public int wins = 0;
    public int losses = 0;
    public int betAmount = 5;

    [Header("UI Settings")]
    public Sprite[] diceFaceImages;
    public Image[] resultImageSlots;

    Transform cam;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Constantly update where the players throw location is relative to the camera (down and to the right)
        playerTossPosition = cam.TransformPoint(playerTossPositionOffset);

        if (!rollDone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeTurn("player");
            }
        }

        if(rollDone)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {

                ClearDice();
                ResetUI();
                rollDone = false;
            }
        }
    }

    public void TakeTurn(string whichPlayerIsRolling)
    {
        //If there is currently dice in play, clear the dice
        if (diceInPlay.Count != 0)
        {
            ClearDice();
        }

        StartCoroutine(ThrowDice(playerTossPosition));
    }

    public IEnumerator ThrowDice(Vector3 tossPosition)
    {
        Debug.Log("ThrowDice");
        //Instantiate all dice (Force is added to each die in their Start functions)
        for(int i = 0; i < numberOfDice; i++)
        {

            //Instantiate new die at spawn position 1-3 and add the new die to the dice in play list
            GameObject newDie = Instantiate(dicePrefab, tossPosition, Quaternion.Euler(Random.Range(0, 360),
                                                                                                         Random.Range(0, 360),
                                                                                                         Random.Range(0, 360)));
            diceInPlay.Add(newDie);
        }

        //Wait for dice to be done moving
        yield return new WaitForSeconds(countWaitTime);

        UpdateUI();
        rollDone = true;
        
    }

    /**
     * The resulting die faces being sent in are already in sorted order, so easy to see if there are pairs
     */
    public bool ValidateDiceRoll(List<int> diceInOrder)
    {
        
        //4-5-6 = automatic win
        if(diceInOrder[0] == 4 && diceInOrder[1] == 5 && diceInOrder[2] == 6)
        {
            Debug.Log("4-5-6, automatic win");
            return true;
        }

        //1-2-3 = automatic loss
        if (diceInOrder[0] == 1 && diceInOrder[1] == 2 && diceInOrder[2] == 3)
        {
            Debug.Log("1-2-3, automatic loss");
            return true;
        }

        //If there is TRIPS
        if (diceInOrder[0] == diceInOrder[1] && diceInOrder[1] == diceInOrder[2])
        {
            Debug.Log("TRIPS: " + diceInOrder[0]);
            return true;
        }

        //There is a PAIR (1st two match)
        else if (diceInOrder[0] == diceInOrder[1])
        {
            Debug.Log("Pair of " + diceInOrder[0] + "'s, Point of " + diceInOrder[2]);
            return true;
        }//There is a PAIR(2nd two match)
        else if (diceInOrder[1] == diceInOrder[2])
        {
            Debug.Log("Pair of " + diceInOrder[1] + "'s, Point of " + diceInOrder[0]);
            return true;
        }

        else
        {

            Debug.Log("Roll again");
            return false;
        }
    }

    public void ClearDice()
    {
        foreach(GameObject die in diceInPlay)
        {
            Destroy(die);
        }
        //Empty DiceInPlay List
        diceInPlay.Clear();
        //Empty DiceInOrder List
        diceInOrder.Clear();


    }

    public void ResetUI()
    {
        for (int i = 0; i < resultImageSlots.Length; i++)
        {
            resultImageSlots[i].sprite = null;
        }
    }

    /**
     * Updates the UI's result image slots and puts the dice images in order from least to greatest.
     */
    public void UpdateUI()
    {
        //The dice results are added to this list, which then gets sorted after upcoming for loop
        diceInOrder = new List<int>();
        
        for (int i = 0; i < resultImageSlots.Length; i++)
        {
            //Get the value of side facing up and add to a list to be sorted
            int diceRolledValue = diceInPlay[i].GetComponent<Die>().GetFaceUp();
            diceInOrder.Add(diceRolledValue);
        }

        diceInOrder.Sort();
        for (int i = 0; i < resultImageSlots.Length; i++)
        {
            resultImageSlots[i].sprite = diceFaceImages[diceInOrder[i]-1];
        }


        //FIX HERE
        if (diceInOrder != null)
        {

            //After getting results and updating UI,
            bool validRoll = ValidateDiceRoll(diceInOrder);
            /*do
            {
                validRoll = ValidateDiceRoll(diceInOrder);
                if (!validRoll)
                    canRoll = true;
            }
            while (!validRoll);*/

            if(validRoll)
            {
                canRoll = false;
            }
        }

    }





}
