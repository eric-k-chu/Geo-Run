/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the VoidEventChannel class, which defines a 
generic void unityevent
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
