/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlayerController class, which contains methods that allow 
a user to control the player model and algorithms that manipulate the player's 
velocity.
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
    private LanePosition current_lane_pos;
    private float target_lane_xpos;
    private float distance_to_lane;

    // Movement Variables
    [SerializeField] private PlayerVariables player_var;
    private float forward_speed;
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
        forward_speed = player_var.forward_speed;
    }

    private void Update()
    {
        if (!GameStateManager.instance.IsLost())
        {
            GameStateManager.instance.SetDistance((int)transform.position.z);
            forward_speed += (Time.deltaTime / 10f);

            // User press Right
            if (Input.GetKeyDown(KeyCode.D) && Time.timeScale != 0f)
            {
                if (current_lane_pos == LanePosition.Left)
                {
                    player_animator.SetTrigger("move_right");
                    current_lane_pos = LanePosition.Middle;
                    target_lane_xpos = 0f;
                    AudioManager.instance.PlayMoveSFX();
                }
                else if (current_lane_pos == LanePosition.Middle)
                {
                    player_animator.SetTrigger("move_right");
                    current_lane_pos = LanePosition.Right;
                    target_lane_xpos = player_var.distance_between_lanes;
                    AudioManager.instance.PlayMoveSFX();
                }
            }
            // User press Left
            if (Input.GetKeyDown(KeyCode.A) && Time.timeScale != 0f)
            {
                if (current_lane_pos == LanePosition.Right)
                {
                    player_animator.SetTrigger("move_left");
                    current_lane_pos = LanePosition.Middle;
                    target_lane_xpos = 0f;
                    AudioManager.instance.PlayMoveSFX();
                }
                else if (current_lane_pos == LanePosition.Middle)
                {
                    player_animator.SetTrigger("move_left");
                    current_lane_pos = LanePosition.Left;
                    target_lane_xpos = -player_var.distance_between_lanes;
                    AudioManager.instance.PlayMoveSFX();
                }
            }

            // User press Jump 
            if (player_controller.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0f)
                {
                    vertical_velocity = player_var.jump_force;
                    AudioManager.instance.PlayJumpSFX();
                }
            }
            // Calculating Falling Physics
            else
            {
                artificial_gravity = Mathf.Lerp(player_var.fall_multiplier, player_var.fall_multiplier * 1.2f, Time.deltaTime);
                vertical_velocity -= player_var.jump_force * artificial_gravity * Time.deltaTime;
            }

            // Movement vector for move()
            Vector3 motion_vector = new Vector3(distance_to_lane - transform.position.x,
                vertical_velocity * Time.deltaTime, forward_speed * Time.deltaTime);

            // The distance between the lane will update as we approach the target lane
            distance_to_lane = Mathf.Lerp(distance_to_lane, target_lane_xpos,
                player_var.horizontal_speed * Time.deltaTime);

            player_controller.Move(motion_vector);
        }
    }
}
