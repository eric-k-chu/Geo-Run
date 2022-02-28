/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlayerCamera class, which tells CM vcam1 which character model to track
*/
using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private UserSettings user_settings;

    [SerializeField] private GameObject[] character_models;

    [Header("Follow Offset")]
    [SerializeField] private Vector3 follow_offset;

    [Header("Transposer"), Range(0f, 20f)]
    [SerializeField] private float body_xdamping;

    [Range(0f, 20f)]
    [SerializeField] private float body_ydamping;

    [Header("Composer"), Range(0f, 20f)]
    [SerializeField] private float aim_horizontal_damping;

    [Range(0f, 20f)]
    [SerializeField] private float aim_vertical_damping;

    private CinemachineVirtualCamera cinemachine;

    private void Awake()
    {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        cinemachine.Follow = character_models[user_settings.character_type].transform; 
        cinemachine.LookAt = character_models[user_settings.character_type].transform;

        CinemachineTransposer transposer = cinemachine.AddCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = follow_offset;
        transposer.m_XDamping = body_xdamping;
        transposer.m_YawDamping = body_ydamping;

        CinemachineComposer composer = cinemachine.AddCinemachineComponent<CinemachineComposer>();
        composer.m_HorizontalDamping = aim_horizontal_damping;
        composer.m_VerticalDamping = aim_vertical_damping;


    }
}
