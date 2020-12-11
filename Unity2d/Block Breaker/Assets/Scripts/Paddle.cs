using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Camera camera => Camera.main;
    
    float WorldUnits => (camera.orthographicSize * 2) * camera.aspect;

    private float MAXPaddlePosition => (WorldUnits / 2) - 1;

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;

        var newPositionX = Input.mousePosition.x / Screen.width * WorldUnits;

        var paddlePosition = new Vector2(currentPosition.x, currentPosition.y);

        paddlePosition.x = Mathf.Clamp(newPositionX - (WorldUnits / 2), -MAXPaddlePosition, MAXPaddlePosition);

        transform.position = paddlePosition;
    }
}