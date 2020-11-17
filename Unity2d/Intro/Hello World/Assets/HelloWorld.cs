using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerName = "Chris";
        print($"Hello {PlayerName}");
    }

    public string PlayerName { get; set; }

    // Update is called once per frame
    void Update()
    {
        
    }
}
