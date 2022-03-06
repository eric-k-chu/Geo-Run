/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlayerStats class, which has variables and functions
that define and manipulate the various stats of the player
*/
using UnityEngine;

// Burning causes the player to take damage over time
// Chilled reduces the player's horizontal speed and forward speed
// Grasped reduces the player's vertical velocity
public enum Ailments { Burning, Chilled, Grasped, None }

public class PlayerStats : MonoBehaviour
{
    private float health = 100f;

    private int fire_crystal_count = 0;

    private int water_crystal_count = 0;

    private int earth_crystal_count = 0;

    private Ailments ailment_on_player;

    private float burn_multiplier = 1f;

    private float chill_multiplier = 1f;

    private float grasp_multiplier = 1f;

    [SerializeField] private AilmentCurves ailment_curves;

    private void Start()
    {
        ailment_on_player = Ailments.None;           
    }

    private void Update()
    {
        if (!GameStateManager.instance.IsLost())
        {
            if (health <= 0)
            {
                GameStateManager.instance.TransitionToLostState();
            }
            HandleAilmentState();

            switch (ailment_on_player)
            {
                case Ailments.Burning:
                    burn_multiplier = ailment_curves.burn_multiplier_curve.Evaluate(fire_crystal_count);

                    if (health > 0)
                    {
                        health -= (burn_multiplier / 100f);
                    }
                    break;
                case Ailments.Chilled:
                    chill_multiplier = ailment_curves.chill_multiplier_curve.Evaluate(water_crystal_count);
                    break;
                case Ailments.Grasped:
                    grasp_multiplier = ailment_curves.grasp_multiplier_curve.Evaluate(earth_crystal_count);

                    if (health < 100f)
                    {
                        health += 0.01f;
                        if (health > 100f)
                        {
                            health = 100f;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Elements obj = other.gameObject.GetComponent<Crystal>().GetElementalType();
        if (obj == Elements.Fire)
        {
            fire_crystal_count++;
            if (earth_crystal_count > 0)
            {
                earth_crystal_count--;
            }
        }
        else if (obj == Elements.Water)
        {
            water_crystal_count++;
            if (fire_crystal_count > 0)
            {
                fire_crystal_count--;
            }
        }
        else if (obj == Elements.Earth)
        {
            earth_crystal_count++;
            if (water_crystal_count > 0)
            {
                water_crystal_count--;
            }
        }
    }

    private void HandleAilmentState()
    {
        // Fire crystal count is highest
        if (fire_crystal_count > water_crystal_count && fire_crystal_count > earth_crystal_count)
        {
            ailment_on_player = Ailments.Burning;
        }

        // Water crystal count is highest
        else if (water_crystal_count > fire_crystal_count && water_crystal_count > earth_crystal_count)
        {
            ailment_on_player = Ailments.Chilled;
        }

        // Earth crystal count is highest
        else if (earth_crystal_count > fire_crystal_count && earth_crystal_count > water_crystal_count)
        {
            ailment_on_player = Ailments.Grasped;
        }

        // Fire crystal count = Water crystal count, both greater than earth crystal count
        else if (fire_crystal_count == water_crystal_count && fire_crystal_count > earth_crystal_count)
        {
            ailment_on_player = Ailments.Chilled;
        }

        // Earth crystal count = Water crystal count, both greater than fire crystal count
        else if (earth_crystal_count == water_crystal_count && earth_crystal_count > fire_crystal_count)
        {
            ailment_on_player = Ailments.Grasped;
        }

        // Earth crystal count = Fire crystal count, both greater than water crystal count
        else if (earth_crystal_count == fire_crystal_count && earth_crystal_count > water_crystal_count)
        {
            ailment_on_player = Ailments.Burning;
        }

        // All crystal counts are equal
        else if (earth_crystal_count == fire_crystal_count && earth_crystal_count == water_crystal_count)
        {
            ailment_on_player = Ailments.None;
        }
    }

    public Ailments GetCurrentAilmentOnPlayer()
    {
        return ailment_on_player;
    }

    public float GetCurrentAilmentMultiplier(Ailments ailment)
    {
        if (ailment == Ailments.Burning)
        {
            return burn_multiplier;
        }
        else if (ailment == Ailments.Chilled)
        {
            return chill_multiplier;
        }
        else if (ailment == Ailments.Grasped)
        {
            return grasp_multiplier;
        }
        return 0f;
    }

    public float GetCurrentHealth()
    {
        return health;
    }

    public int GetFireCrystalCount()
    {
        return fire_crystal_count;
    }

    public int GetWaterCrystalCount()
    {
        return water_crystal_count;
    }

    public int GetEarthCrystalCount()
    {
        return earth_crystal_count;
    }
}
