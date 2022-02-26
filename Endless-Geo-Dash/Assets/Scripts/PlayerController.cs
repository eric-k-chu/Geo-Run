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
    private enum LanePosition {Left, Middle, Right}
    private Animator player_animator;

    [SerializeField] private float lane_distance;
    [SerializeField] private float player_speed;
    [SerializeField] private float horizontal_speed;
    private LanePosition current_lane_pos;
    private LanePosition target_lane_pos;
    private float target_pos_x;

    private bool changing_lanes;


    private void Awake()
    {
        player_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        current_lane_pos = LanePosition.Middle;
        changing_lanes = false;
    }

    private void Update()
    {
        // TODO: Stop forward movement on death
        transform.Translate(Vector3.forward * player_speed);

        // Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (current_lane_pos == LanePosition.Left)
            {
                player_animator.SetTrigger("move_right");
                target_lane_pos = LanePosition.Middle;
                changing_lanes = true;
                FindTargetPosX();
            }
            else if (current_lane_pos == LanePosition.Middle)
            {
                player_animator.SetTrigger("move_right");
                target_lane_pos = LanePosition.Right;
                changing_lanes = true;
                FindTargetPosX();
            }
        }
        // Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (current_lane_pos == LanePosition.Right)
            {
                player_animator.SetTrigger("move_left");
                target_lane_pos = LanePosition.Middle;
                changing_lanes = true;
                FindTargetPosX();
            }
            else if (current_lane_pos == LanePosition.Middle)
            {
                player_animator.SetTrigger("move_left");
                target_lane_pos = LanePosition.Left;
                changing_lanes = true;
                FindTargetPosX();
            }
        }

        if (changing_lanes)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target_pos_x, transform.position.y, transform.position.z * player_speed), horizontal_speed);
            if (transform.position.x == target_pos_x)
            {
                changing_lanes = false;
                current_lane_pos = target_lane_pos;
            }
        }
    }

    private void FindTargetPosX()
    {
        if (target_lane_pos == LanePosition.Right)
        {
            target_pos_x = lane_distance;
        } 
        else if (target_lane_pos == LanePosition.Left)
        {
            target_pos_x = -1 * lane_distance;
        }
        else
        {
            target_pos_x = 0f;
        }
    }

}
