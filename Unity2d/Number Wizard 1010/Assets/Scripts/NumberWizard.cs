using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] public int minNumber;
    [SerializeField] public int maxNumber;
    [SerializeField] private TextMeshProUGUI guessText;

    public int guess;


    void CalculateNextGuess()
    {
        guess = Random.Range(minNumber, maxNumber + 1);
        guessText.text = guess.ToString();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        CalculateNextGuess();
    }

    public void OnPressHigher()
    {
        minNumber = guess + 1;
        CalculateNextGuess();
    }

    public void OnPressLower()
    {
        maxNumber = guess - 1;
        CalculateNextGuess();
    }
}