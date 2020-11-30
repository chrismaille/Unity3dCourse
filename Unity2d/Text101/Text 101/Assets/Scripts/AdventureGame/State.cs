using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] public string storyText;
    [SerializeField] public List<State> nextStates;
    [SerializeField] public bool hasRandomState;
    public bool notProcessed = true;

    public string GetStateStory()
    {
        return storyText;
    }

    public List<State> GetNextStates()
    {
        return nextStates;
    }
}