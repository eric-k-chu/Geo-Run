/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the VoidEventChannel class, which defines a generic void
unity event
*/
using UnityEngine;
using UnityEngine.Events;

namespace GPEJ
{
    [CreateAssetMenu(fileName = " VoidEventChannel", menuName = "Events/VoidEvent Channel")]
    public class VoidEventChannel : ScriptableObject
    {
        public UnityAction OnEventRaised;
        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }
    }
}
