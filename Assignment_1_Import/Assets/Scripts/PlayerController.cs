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
    //Keeps track of the directions
    public Vector2 Move;
    private Dictionary<Direction, int> rotationByDirection = new()
    {
        {Direction.North, 0 },
        {Direction.East, 270 },
        {Direction.South, 180 },
        {Direction.West, 90 },
    };

    private Direction facingDirection;
    private bool isRotating = false;

    //Values for rotation
    [SerializeField] private float rotationTime = 0.5f;
    private float rotationTimer = 0.0f;
    private Quaternion previousRotation;

    //The current room the player is in
    public RoomBase currentRoom = null;

    //Values for movement
    [SerializeField] private float movementTime = 2.0f;
    private bool isMoving = false;
    private float movementTimer = 0.0f;
    private Vector3 previousPosition;
    private Vector3 moveToPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Setup()
    {
        //Array of the directions
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
        //Faces the player a random direction
        facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
        //Sets the rotation
        SetFacingDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //Keeps moving untill finished
        if (isMoving)
        {
            Vector3 currentPosition = Vector3.Lerp(previousPosition, moveToPosition, movementTimer / movementTime);
            transform.position = currentPosition;
            movementTimer += Time.deltaTime;

            if (movementTimer > movementTime)
            {
                isMoving = false;
                movementTimer = 0.0f;
                transform.position = moveToPosition;
            }
        }

        //Keeps rotating untill finished
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
                //Snaps to the final rotation
                SetFacingDirection();
            }
        }
        else
        {
            //Inputs for left and right
            //The reason they are reversed is because the players movement would also be reversed
            bool rotateRight = Input.GetKeyDown(KeyCode.A);
            bool rotateLeft = Input.GetKeyDown(KeyCode.D);
            //Makes sure only one is true
            if (rotateRight && !rotateLeft)
            {
                TurnRight();
            }
            else if (!rotateRight && rotateLeft)
            {
                TurnLeft();
            }
            //Searches current room
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentRoom != null)
                {
                    currentRoom.OnRoomSearched();
                }
            }
            //Moves the player
            else if (Input.GetKeyDown (KeyCode.W))
            {
                //Prevents moving into a room that doesnt exist
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
        //Gets transforms rotation
        Vector3 facing = transform.rotation.eulerAngles;
        //Y value for facing
        facing.y = rotationByDirection[facingDirection];
        //Saves rotaion as a quaternion
        transform.rotation = Quaternion.Euler(facing);
    }
    //Rotates left
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
    //Rotates not left
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

    //Rotates in general
    private void StartRotating()
    {
        previousRotation = transform.rotation;
        isRotating = true;
    }

    //Begins the movement
    private void StartMovement(RoomBase targetRoom)
    {
        previousPosition = transform.position;
        //The removed 35 z axis is to prevent the player being displaced from the rooms
        moveToPosition = targetRoom.transform.position - new Vector3(0, 0, 35);
        isMoving = true;
    }
    //The room being moved into
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
    //Unused code that is apparently for a different way to move
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }
    private void MoveInput(Vector2 newMoveDirection)
    {
        Move = newMoveDirection;
    }

    //On entering a room
    private void OnTriggerEnter(Collider otherObject)
    {
        currentRoom = otherObject.GetComponent<RoomBase>();
        currentRoom.OnRoomEntered();
    }
    //Whem leaving a room
    private void OnTriggerExit(Collider otherObject)
    {
        RoomBase exitingRoom = otherObject.GetComponent<RoomBase>();
        exitingRoom.OnRoomExit();
    }

}
