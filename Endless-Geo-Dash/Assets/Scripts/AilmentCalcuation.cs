/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the AilmentCalcuation class, which has variables and functions
that define and manipulate the different ailment on the player
*/
using UnityEngine;

public class AilmentCalcuation : MonoBehaviour
{
    [SerializeField] private GameSettings game_settings;

    private float health;

    private int fire_crystal_count = 0;

    private int water_crystal_count = 0;

    private int earth_crystal_count = 0;

    private Ailments current_ailment;

    private float burn_multiplier = 1f;

    private float chill_multiplier = 1f;

    private float grasp_multiplier = 1f;

    [SerializeField] private AilmentCurves ailment_curves;

    private void Start()
    {
        current_ailment = Ailments.None;
        health = game_settings.maximum_player_health;
    }

    private void Update()
    {
        if (!GameStateManager.instance.IsLost())
        {
            if (health <= 0)
            {
                Debug.Log("HP has reached zero");
                GameStateManager.instance.LoseGame();
            }
            HandleAilmentState();

            switch (current_ailment)
            {
                case Ailments.Burning:
                    burn_multiplier = ailment_curves.burn_multiplier_curve.Evaluate(fire_crystal_count);
                    PlayerStats.instance.SetBurnMultiplier(burn_multiplier);

                    if (health > 0)
                    {
                        health -= (burn_multiplier / 100f);
                        PlayerStats.instance.SetCurrentHealth(health);
                    }
                    break;
                case Ailments.Chilled:
                    chill_multiplier = ailment_curves.chill_multiplier_curve.Evaluate(water_crystal_count);
                    PlayerStats.instance.SetChillMultiplier(chill_multiplier);
                    break;
                case Ailments.Grasped:
                    grasp_multiplier = ailment_curves.grasp_multiplier_curve.Evaluate(earth_crystal_count);
                    PlayerStats.instance.SetGraspMultiplier(grasp_multiplier);

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
        if (other.gameObject.CompareTag("Crystal"))
        {
            Elements type = other.gameObject.GetComponent<Crystal>().GetElementalType();
            if (type == Elements.Fire)
            {
                PlayerStats.instance.SetFireCount(++fire_crystal_count);
                if (earth_crystal_count > 0)
                {
                    PlayerStats.instance.SetEarthCount(--earth_crystal_count);
                }
            }
            else if (type == Elements.Water)
            {
                PlayerStats.instance.SetWaterCount(++water_crystal_count);
                if (fire_crystal_count > 0)
                {
                    PlayerStats.instance.SetFireCount(--fire_crystal_count);
                }
            }
            else if (type == Elements.Earth)
            {
                PlayerStats.instance.SetEarthCount(++earth_crystal_count);
                if (water_crystal_count > 0)
                {
                    PlayerStats.instance.SetWaterCount(--water_crystal_count);
                }
            }
        }
        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            Elements type = other.gameObject.GetComponent<Checkpoints>().GetElementalType();
            if (type == Elements.Fire && current_ailment != Ailments.Burning)
            {
                AudioManager.instance.PlayDeathSFX();
                GameStateManager.instance.LoseGame();
            }
            else if (type == Elements.Water && current_ailment != Ailments.Chilled)
            {
                AudioManager.instance.PlayDeathSFX();
                GameStateManager.instance.LoseGame();
            }
            else if (type == Elements.Earth && current_ailment != Ailments.Grasped)
            {
                AudioManager.instance.PlayDeathSFX();
                GameStateManager.instance.LoseGame();
            }
            else
            {
                AudioManager.instance.PlayCheckpointPassSFX();
            }
        }
    }

    private void HandleAilmentState()
    {
        // Fire crystal count is highest
        if (fire_crystal_count > water_crystal_count && fire_crystal_count > earth_crystal_count)
        {
            current_ailment = Ailments.Burning;
        }

        // Water crystal count is highest
        else if (water_crystal_count > fire_crystal_count && water_crystal_count > earth_crystal_count)
        {
            current_ailment = Ailments.Chilled;
        }

        // Earth crystal count is highest
        else if (earth_crystal_count > fire_crystal_count && earth_crystal_count > water_crystal_count)
        {
            current_ailment = Ailments.Grasped;
        }

        // Fire crystal count = Water crystal count, both greater than earth crystal count
        else if (fire_crystal_count == water_crystal_count && fire_crystal_count > earth_crystal_count)
        {
            current_ailment = Ailments.Chilled;
        }

        // Earth crystal count = Water crystal count, both greater than fire crystal count
        else if (earth_crystal_count == water_crystal_count && earth_crystal_count > fire_crystal_count)
        {
            current_ailment = Ailments.Grasped;
        }

        // Earth crystal count = Fire crystal count, both greater than water crystal count
        else if (earth_crystal_count == fire_crystal_count && earth_crystal_count > water_crystal_count)
        {
            current_ailment = Ailments.Burning;
        }

        // All crystal counts are equal
        else if (earth_crystal_count == fire_crystal_count && earth_crystal_count == water_crystal_count)
        {
            current_ailment = Ailments.None;
        }
        PlayerStats.instance.SetCurrentAilment(current_ailment);
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
