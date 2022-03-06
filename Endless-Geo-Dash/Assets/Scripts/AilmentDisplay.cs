/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the AilmentDisplay class, which contains
functions that modifies the fill image of the ring sprite
located under the Ailment Display UI object
*/
using UnityEngine;
using UnityEngine.UI;

public class AilmentDisplay : MonoBehaviour
{
    [SerializeField] private Color fire_color;

    [SerializeField] private Color water_color;

    [SerializeField] private Color earth_color;

    [SerializeField] private Color default_color;

    private GameObject player_object;
    private PlayerStats player_stats;
    private Image image;

    private Ailments current_ailment;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (player_object == null)
        {
            player_object = GameObject.FindWithTag("Player");
            player_stats = player_object.GetComponent<PlayerStats>();
        }

        current_ailment = player_stats.GetCurrentAilmentOnPlayer();
        switch (current_ailment)
        {
            case Ailments.Burning:
                image.color = fire_color;
                break;
            case Ailments.Chilled:
                image.color = water_color;
                break;
            case Ailments.Grasped:
                image.color = earth_color;
                break;
            case Ailments.None:
                image.color = default_color;
                break;
            default:
                break;
        }
    }
}
