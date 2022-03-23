/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameEventListener class, which listens for events
in the Game-Scene
*/
using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BoolEvents : UnityEvent<bool> { }

[Serializable]
public class Vector3Events : UnityEvent<Vector3> { }

namespace GPEJ
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel crystal_channel;
        [SerializeField] private BoolEventChannel player_pause_channel;
        [SerializeField] private BoolEventChannel player_death_channel;
        [SerializeField] private Vector3EventChannel platform_channel;
        [SerializeField] private Vector3EventChannel background_channel;

        public UnityEvent OnCrystalPickedUp;
        public BoolEvents OnPlayerPaused;
        public BoolEvents OnPlayerDied;
        public Vector3Events OnPlatformSpawned;
        public Vector3Events OnBackgroundSpawned;

        private void Start()
        {
            crystal_channel.OnEventRaised += TriggerCrystalUIAnimation;
            player_pause_channel.OnEventRaised += EnablePauseMenu;
            player_death_channel.OnEventRaised += EnableGameOverMenu;
            platform_channel.OnEventRaised += SpawnPlatform;
            background_channel.OnEventRaised += SpawnBackground;
        }

        private void OnDestroy()
        {
            crystal_channel.OnEventRaised -= TriggerCrystalUIAnimation;
            player_pause_channel.OnEventRaised -= EnablePauseMenu;
            player_death_channel.OnEventRaised -= EnableGameOverMenu;
            platform_channel.OnEventRaised -= SpawnPlatform;
            background_channel.OnEventRaised -= SpawnBackground;
        }

        public void TriggerCrystalUIAnimation()
        {
            OnCrystalPickedUp?.Invoke();
        }

        public void EnablePauseMenu(bool value)
        {
            OnPlayerPaused?.Invoke(value);
        }

        public void EnableGameOverMenu(bool value)
        {
            OnPlayerDied?.Invoke(value);
        }

        public void SpawnPlatform(Vector3 vect)
        {
            OnPlatformSpawned?.Invoke(vect);
        }

        public void SpawnBackground(Vector3 vect)
        {
            OnBackgroundSpawned?.Invoke(vect);
        }
    }
}
