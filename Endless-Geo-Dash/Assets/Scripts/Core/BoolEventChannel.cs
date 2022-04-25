/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the BoolEventChannel class, which defines a 
generic boolean unity event
*/
using UnityEngine;
using UnityEngine.Events;

namespace GPEJ
{
    [CreateAssetMenu(fileName = " BoolEventChannel", menuName = "Events/BoolEvent Channel")]
    public class BoolEventChannel : ScriptableObject
    {
        public UnityAction<bool> OnEventRaised;
        public void RaiseEvent(bool value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}
