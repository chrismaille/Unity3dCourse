using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1;

    private Vector2 _paddleToBallVector2;
    
    // Start is called before the first frame update
    void Start()
    {
        _paddleToBallVector2 = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var currentPaddlePosition = paddle1.transform.position;
        var paddlePosition = new Vector2(currentPaddlePosition.x, currentPaddlePosition.y);
        transform.position = paddlePosition + _paddleToBallVector2;
    }
}
