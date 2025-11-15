using GD14_1133_DiceGame_Jeong_Yuri;
using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

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

    public RoomBase currentRoom = null;

    [SerializeField] private float movementTime = 2.0f;
    private bool isMoving = false;
    private float movementTimer = 0.0f;
    private Vector3 previousPosition;
    private Vector3 moveToPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Setup()
    {
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
        facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
        SetFacingDirection();
        Debug.Log("Sadasd");
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector3 currentPosition = Vector3.Lerp(previousPosition, moveToPosition, movementTimer / movementTime);
            transform.position = currentPosition;
            movementTimer += Time.deltaTime;
            Debug.Log("oihasdf");

            if (movementTimer > movementTime)
            {
                isMoving = false;
                movementTimer = 0.0f;
                transform.position = moveToPosition;
            }
        }

        if (isRotating)
        {
            Quaternion currentRotation = Quaternion.Slerp(
                previousRotation,
                Quaternion.Euler(new Vector3(0, rotationByDirection[facingDirection])),
                rotationTimer / Time.deltaTime);
            transform.rotation = currentRotation;
            rotationTimer += Time.deltaTime;
            if (rotationTimer > rotationTime)
            {
                isRotating = false;
                rotationTimer = 0.0f;
                SetFacingDirection();
            }
        }
        else
        {
            bool rotateRight = Input.GetKeyDown(KeyCode.D);
            bool rotateLeft = Input.GetKeyDown(KeyCode.A);
            if (rotateRight && !rotateLeft)
            {
                TurnRight();
            }
            else if (!rotateRight && rotateLeft)
            {
                TurnLeft();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentRoom != null)
                {
                    currentRoom.OnRoomSearched();
                }
            }
            else if (Input.GetKeyDown (KeyCode.W))
            {
                RoomBase roomInFacingDirection = NextRoomInDirection();
                if (roomInFacingDirection != null)
                {
                    StartMovement(roomInFacingDirection);
                }
            }
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
        StartRotating();
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
        StartRotating();
    }

    private void StartRotating()
    {
        previousRotation = transform.rotation;
        isRotating = true;
    }

    private void StartMovement(RoomBase targetRoom)
    {
        previousPosition = transform.position;
        moveToPosition = targetRoom.transform.position;
        isMoving = true;
    }
    private RoomBase NextRoomInDirection()
    {
        if (currentRoom == null)
        {
            return null;
        }

        switch (facingDirection)
        {
            case Direction.North:
                return currentRoom.north;
            case Direction.East:
                return currentRoom.east;
            case Direction.South:
                return currentRoom.south;
            case Direction.West:
                return currentRoom.west;
            default:
                Debug.Log("Please input a valid option");
                return null;
        }
    }
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }
    private void MoveInput(Vector2 newMoveDirection)
    {
        Move = newMoveDirection;
        
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        currentRoom = otherObject.GetComponent<RoomBase>();
        currentRoom.OnRoomEntered();
    }
    private void OnTriggerExit(Collider otherObject)
    {
        Debug.Log("lev");
    }

}
