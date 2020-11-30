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
            textComponent.text += "\n3. Foo?";
        }
    }

    private void AddRandomState()
    {
        fluffy = ScriptableObject.CreateInstance<State>();
        fluffy.name = "Fluffly State";
        fluffy.storyText = "BAR\n\n1. Voltar.";
        state.storyText = textComponent.text;
        fluffy.nextStates = new List<State> {state};
        state.nextStates.Add(fluffy);
        state.notProcessed = false;
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowState(nextStates[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowState(nextStates[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowState(nextStates[2]);
        }
    }
}