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

    [SerializeField] private RawImage color_display;

    private RawImage image;

    private Ailments current_ailment;

    private void Awake()
    {
        image = GetComponent<RawImage>();
    }

    private void Start()
    {
        GameStateManager.instance.OnPlayerInflictedAilment += SetAilmentDisplay;
    }

    private void SetAilmentDisplay(Ailments type)
    {
        current_ailment = type;
        switch (current_ailment)
        {
            case Ailments.Burning:
                {
                    image.color = fire_color;
                    color_display.color = fire_color;
                    break;
                }
            case Ailments.Chilled:
                {
                    image.color = water_color;
                    color_display.color = water_color;
                    break;
                }
            case Ailments.Grasped:
                {
                    image.color = earth_color;
                    color_display.color = earth_color;
                    break;
                }
            case Ailments.None:
                {
                    image.color = default_color;
                    color_display.color = default_color;
                    break;
                }
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        GameStateManager.instance.OnPlayerInflictedAilment -= SetAilmentDisplay;
    }

}
