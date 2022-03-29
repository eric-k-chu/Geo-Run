using UnityEngine;
/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
Summary:
Stores variables that the UI will display. Only usable on runtime.
*/
namespace GPEJ
{
    [CreateAssetMenu(menuName = "Data/Runtime Data")]
    public class RuntimeDataContainer : ScriptableObject
    {
        [HideInInspector] public float velocity;
        [HideInInspector] public float distance;
        [HideInInspector] public int crystals;
    }
}
