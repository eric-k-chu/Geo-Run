/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the AilmentCurves class, which contains the
mathematical functions for the three ailment multipliers
*/
using UnityEngine;

[CreateAssetMenu(fileName = "New Ailment Curves", menuName = "Game Functions/Ailment Curves")]
public class AilmentCurves : ScriptableObject
{
    public AnimationCurve burn_multiplier_curve;
    public AnimationCurve chill_multiplier_curve;
    public AnimationCurve grasp_multiplier_curve;
    
}
