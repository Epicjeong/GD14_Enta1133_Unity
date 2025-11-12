using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 Move;
    private Dictionary<Direction, int> rotationByDirection = new()
    {
        {Direction.North, 0 },
        {Direction.East, 90 },
        {Direction.South, 180 },
        {Direction.West,270 },
    };

    private Direction facingDirection;
    private bool isRotating = false;

    [SerializeField] private float rotationTime = 0.5f;
    private float rotationTimer = 0.0f;
    private Quaternion previousRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Setup()
    {
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
        facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = Quaternion.Lerp(
        previousRotation,
        Quaternion.Euler(new Vector3(0, rotationByDirection[facingDirection])),
        rotationTimer / Time.deltaTime);
        transform.rotation = currentRotation;
        if (rotationTimer > rotationTime)
        {
            isRotating = false;
            rotationTimer = 0.0f;

        }
    }

    private void SetFacingDirection()
    {
        Vector3 facing = transform.rotation.eulerAngles;
        facing.y = rotationByDirection[facingDirection];
        transform.rotation = Quaternion.Euler(facing);
    }
    void TurnLeft()
    {
        switch (facingDirection)
        {
            case Direction.North:
                facingDirection = Direction.West;
                break;
            case Direction.West:
                facingDirection = Direction.South;
                break;
            case Direction.South:
                facingDirection = Direction.East;
                break;
            case Direction.East:
                facingDirection = Direction.North;
                break;
        }
    }
    void TurnRight()
    {
        switch (facingDirection)
        {
            case Direction.North:
                facingDirection = Direction.East;
                break;
            case Direction.West:
                facingDirection = Direction.North;
                break;
            case Direction.South:
                facingDirection = Direction.West;
                break;
            case Direction.East:
                facingDirection = Direction.South;
                break;
        }
    }

    private void StartRotating()
    {

    }

    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }
    private void MoveInput(Vector2 newMoveDirection)
    {
        Move = newMoveDirection;
        
    }

    

}
