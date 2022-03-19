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

    private Ailments current_ailment;

    private float burn_multiplier = 1f;

    private float chill_multiplier = 1f;

    private float grasp_multiplier = 1f;

    private float timer;

    [SerializeField] private AilmentCurves ailment_curves;

    private void Start()
    {
        current_ailment = Ailments.None;
        health = game_settings.maximum_player_health;
        timer = 0f;
    }

    private void Update()
    {
        if (!GameStateManager.instance.IsLost())
        {
            if (health <= 0)
            {
                GameStateManager.instance.LoseGame();
            }

            timer += (Time.deltaTime / 10f );

            switch (current_ailment)
            {
                case Ailments.Burning:
                    {
                        burn_multiplier = ailment_curves.burn_multiplier_curve.Evaluate(timer);
                        PlayerStats.instance.SetBurnMultiplier(burn_multiplier);

                        if (health > 0)
                        {
                            health -= (burn_multiplier / 10f);
                            PlayerStats.instance.SetCurrentHealth(health);
                        }
                        break;
                    }
                case Ailments.Chilled:
                    {
                        chill_multiplier = ailment_curves.chill_multiplier_curve.Evaluate(timer);
                        PlayerStats.instance.SetChillMultiplier(chill_multiplier);
                        break;
                    }
                case Ailments.Grasped:
                    {
                        grasp_multiplier = ailment_curves.grasp_multiplier_curve.Evaluate(timer);
                        PlayerStats.instance.SetGraspMultiplier(grasp_multiplier);

                        if (health < 100f)
                        {
                            health += 0.1f;
                            PlayerStats.instance.SetCurrentHealth(health);
                            if (health > 100f)
                            {
                                health = 100f;
                                PlayerStats.instance.SetCurrentHealth(health);
                            }
                        }
                        break;
                    }
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
                if (current_ailment != Ailments.Burning)
                {
                    timer = 0f;
                    current_ailment = Ailments.Burning;
                }
            } 
            else if (type == Elements.Water)
            {
                if (current_ailment != Ailments.Chilled)
                {
                    timer = 0f;
                    current_ailment = Ailments.Chilled;
                }
            }
            else if (type == Elements.Earth)
            {
                if (current_ailment != Ailments.Grasped)
                {
                    timer = 0f;
                    current_ailment = Ailments.Grasped;
                }
            }
            PlayerStats.instance.SetCurrentAilment(current_ailment);
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
}
