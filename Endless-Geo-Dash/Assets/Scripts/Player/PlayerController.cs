/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlayerController class, which contains methods that allow 
a user to control the player model and algorithms that manipulate the player's 
velocity.
*/
using System.Collections;
using UnityEngine;

namespace GPEJ.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerVariables player_var;
        [SerializeField] private RuntimeDataContainer runtimed_data;

        private enum LanePosition { Left, Middle, Right }
        private LanePosition current_lane_pos;

        private Animator player_animator;
        private CharacterController player_controller;
                   
        private float distance_to_lane;
        private float target_lane_xpos;
        private float forward_speed;
        private float vertical_velocity;
        private float gravity;

        private bool is_start_of_game;

        private KeyCode right_key;
        private KeyCode left_key;

        private void Awake()
        {
            player_controller = GetComponent<CharacterController>();
            player_animator = GetComponent<Animator>();
        }

        private void Start()
        {
            current_lane_pos = LanePosition.Middle;
            forward_speed = player_var.forward_speed;
            is_start_of_game = true;
            right_key = KeyCode.D;
            left_key = KeyCode.A;
        }

        private void Update()
        {
            if (Time.timeScale != 0f && !is_start_of_game)
            {
                forward_speed += (Time.deltaTime / 10f);

                if (Input.GetKeyDown(right_key) && Time.timeScale != 0f)
                {
                    MovingRight();
                }

                if (Input.GetKeyDown(left_key) && Time.timeScale != 0f)
                {
                    MovingLeft();
                }

                if (player_controller.isGrounded)
                {
                    if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0f)
                    {
                        Jump();
                    }
                }
                else
                {
                    EnableGravity();
                }

                MovePlayer();
                UpdateUIDisplay();
            }
        }

        private void UpdateUIDisplay()
        {
            runtimed_data.velocity = forward_speed;
            runtimed_data.distance = transform.position.z;
        }

        private void MovingRight()
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

        private void MovingLeft()
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

        private void Jump()
        {
            vertical_velocity = player_var.jump_force;
            AudioManager.instance.PlayJumpSFX();
        }

        private void EnableGravity()
        {
            gravity = Mathf.Lerp(player_var.fall_multiplier, player_var.fall_multiplier * 1.2f, Time.deltaTime);
            vertical_velocity -= player_var.jump_force * gravity * Time.deltaTime;
        }

        private void MovePlayer()
        {
            Vector3 motion_vector = new Vector3(distance_to_lane - transform.position.x,
                vertical_velocity * Time.deltaTime, forward_speed * Time.deltaTime);

            distance_to_lane = Mathf.Lerp(distance_to_lane, target_lane_xpos, 
                player_var.horizontal_speed * Time.deltaTime);

            player_controller.Move(motion_vector);
        }

        public void OnGameStart()
        {
            is_start_of_game = false;
        }

        public void SwapKeys(bool condition)
        {
            if (condition)
            {
                right_key = KeyCode.A;
                left_key = KeyCode.D;
                StartCoroutine(DebuffTimer(player_var.debuff_time));
            }
            else
            {
                right_key = KeyCode.D;
                left_key = KeyCode.A;
            }
        }

        private IEnumerator DebuffTimer(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            SwapKeys(false);
        }
    }
}
