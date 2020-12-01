using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] public Text textComponent;
    [SerializeField] private State startingState;
    public State fluffy;


    private State state;

    private string[] descriptions =
    {
        "O céu está nublado.",
        "O chão está molhado",
        "Só tem homens no café.",
        "Uma música toca dentro do café.",
        "Alexa, que horas são?",
        "O Leão dorme a noite.",
        "Hello World!"
    };

    // Start is called before the first frame update
    void Start()
    {
        startingState.nextStates = startingState.nextStates.Take(2).ToList();
        startingState.notProcessed = true;
        ShowState(startingState);
    }

    public void ShowState(State currentState)
    {
        Debug.Log($"New state is: {currentState}");
        state = currentState;
        textComponent.text = state.storyText;
        if (state.hasRandomState && state.notProcessed)
        {
            Debug.Log("Adding Random State...");
            AddRandomState();
            textComponent.text += $"\n3. {descriptions[Random.Range(0, descriptions.Length)]}";
        }
    }

    private void AddRandomState()
    {
        fluffy = ScriptableObject.CreateInstance<State>();
        fluffy.name = "fluffly";
        fluffy.storyText = GetRandomText();
        state.storyText = textComponent.text;
        fluffy.nextStates = new List<State> {state};
        state.nextStates.Add(fluffy);
        state.notProcessed = false;
    }

    private string GetRandomText()
    {
        string text = $"{descriptions[Random.Range(0, descriptions.Length)]}\n\n1. Voltar.";
        return text;
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        for (int index = 0; index < nextStates.Count; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                ShowState(nextStates[index]);
            }
        }
    }
}