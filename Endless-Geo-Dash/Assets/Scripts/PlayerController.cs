/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlayerController class, which contains methods that allow 
a user to control the player model.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum TilePosition {Left, Middle, Right};

    private Rigidbody player_rigidbody;

    [SerializeField] private Transform left_tiles_point;
    [SerializeField] private Transform mid_tiles_point;
    [SerializeField] private Transform right_tiles_point;

    private TilePosition player_tile_position;

    private void Awake()
    {
        player_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();
        else if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();
    }

    private void MoveRight()
    {
        player_tile_position = GetPlayerTilePosition();

        if (player_tile_position == TilePosition.Left)
        {
            transform.position = Vector3.Lerp(transform.position, mid_tiles_point.position, 1f);
        } 
        else if (player_tile_position == TilePosition.Middle)
        {
            transform.position = Vector3.Lerp(transform.position, right_tiles_point.position, 1f);
        }
    }

    private void MoveLeft()
    {
        player_tile_position = GetPlayerTilePosition();

        if (player_tile_position == TilePosition.Right)
        {
            transform.position = Vector3.Lerp(transform.position, mid_tiles_point.position, 1f);
        }
        else if (player_tile_position == TilePosition.Middle)
        {
            transform.position = Vector3.Lerp(transform.position, left_tiles_point.position, 1f);
        }
    }


    private TilePosition GetPlayerTilePosition()
    {
        if (transform.position == left_tiles_point.position)
        {
            return TilePosition.Left;        
        } 
        else if (transform.position == right_tiles_point.position)
        {
            return TilePosition.Right;
        }

        return TilePosition.Middle;
    }
}
