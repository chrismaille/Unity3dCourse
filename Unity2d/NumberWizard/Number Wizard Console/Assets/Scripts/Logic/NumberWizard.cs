using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    public int minNumber;
    public int maxNumber;
    private int _guess;
    public int oldGuess;
    public bool GameEnded = false;

    public int Guess => _guess = (maxNumber + minNumber) / 2;

    public bool GuessHasChanged()
    {
        return Guess != oldGuess;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    /*
     * <Summary> Display Initial Message and Instructions.
     */
    public void StartGame()
    {
        minNumber = 1;
        maxNumber = 1000;
        GameEnded = false;
        
        Debug.Log("Welcome to Number Machine Wizard");
        Debug.Log(
            "I will guess a number you picked, between" +
            $" {minNumber.ToString()} and {maxNumber.ToString()}"
        );
        Debug.Log("Push Arrow Up if my guess is higher than your number.");
        Debug.Log("Push Arrow Down if my guess is lower than your number.");
        Debug.Log("Hit Enter if I guess you number.");
        Debug.Log($"My Guess is: {Guess.ToString()}");
        maxNumber += 1;
        oldGuess = Guess;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEnded) StartGame();
        if (GuessHasChanged())
        {
            Debug.Log($"My Guess is: {Guess.ToString()}");
            oldGuess = Guess;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("Number is higher");
            minNumber = Guess;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("Number is lower");
            maxNumber = Guess;
        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Number is Correct!");
            GameEnded = true;
        }
    }
}