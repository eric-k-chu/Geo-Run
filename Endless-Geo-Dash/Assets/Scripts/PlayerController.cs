/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlayerController class, which contains methods that allow 
a user to control the player model.
*/
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Three lane system
    private enum LanePosition {Left, Middle, Right}

    // Player Components
    private Animator player_animator;
    private CharacterController player_controller;

    // Lane Variables
    [SerializeField] private float lane_distance;
    private LanePosition current_lane_pos;
    private float target_lane_xpos;
    private float distance_to_lane;

    // Movement Variables
    [SerializeField] private float forward_speed;
    [SerializeField] private float horizontal_speed;
    [SerializeField] private float jump_force;
    [SerializeField] private float fall_multiplier;
    private float vertical_velocity;
    private float artificial_gravity;

    private void Awake()
    {
        player_controller = GetComponent<CharacterController>();
        player_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        current_lane_pos = LanePosition.Middle;
    }

    private void Update()
    {
        // User press Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (current_lane_pos == LanePosition.Left)
            {
                player_animator.SetTrigger("move_right");
                current_lane_pos = LanePosition.Middle;
                target_lane_xpos = 0f;
            }
            else if (current_lane_pos == LanePosition.Middle)
            {
                player_animator.SetTrigger("move_right");
                current_lane_pos = LanePosition.Right;
                target_lane_xpos = lane_distance;
            }
        }
        // User press Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (current_lane_pos == LanePosition.Right)
            {
                player_animator.SetTrigger("move_left");
                current_lane_pos = LanePosition.Middle;
                target_lane_xpos = 0f;

            }
            else if (current_lane_pos == LanePosition.Middle)
            {
                player_animator.SetTrigger("move_left");
                current_lane_pos = LanePosition.Left;
                target_lane_xpos = -lane_distance;
 
            }
        }

        // User press Jump 
        if (player_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vertical_velocity = jump_force;
            }
        }
        // Calculating Falling Physics
        else
        {
            artificial_gravity = Mathf.Lerp(fall_multiplier, fall_multiplier * 1.2f, Time.deltaTime);
            vertical_velocity -= jump_force * artificial_gravity * Time.deltaTime;
        }

        // Movement vector for move()
        Vector3 motion_vector = new Vector3(distance_to_lane - transform.position.x, 
            vertical_velocity * Time.deltaTime, forward_speed);

        // The distance between the lane will update as we approach the target lane
        distance_to_lane = Mathf.Lerp(distance_to_lane, target_lane_xpos, 
            Time.deltaTime * horizontal_speed);

        player_controller.Move(motion_vector);
    }
}
