/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the Vector3EventChannel class, which defines a 
generic vector3 unityevent
*/

using UnityEngine;
using UnityEngine.Events;

namespace GPEJ
{
    [CreateAssetMenu(fileName = " Vector3EventChannel", menuName = "Events/Vector3Event Channel")]
    public class Vector3EventChannel : ScriptableObject
    {
        public UnityAction<Vector3> OnEventRaised;
        public void RaiseEvent(Vector3 vect)
        {
            OnEventRaised?.Invoke(vect);
        }
    }
}
