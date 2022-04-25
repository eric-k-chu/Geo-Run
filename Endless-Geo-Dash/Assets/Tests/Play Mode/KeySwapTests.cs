/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the KeySwapTests, which tests that the Reversal debuff is applied 
correctly to the player.
*/

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using GPEJ.Player;

namespace GPEJ.Tests
{
    public class KeySwapTests
    {
        [UnityTest]
        public IEnumerator DefaultDirectionalKeyTest()
        {
            var game_object = new GameObject();
            var player = game_object.AddComponent<PlayerController>();
            var controller = player.GetComponent<PlayerController>();

            yield return null;

            Assert.AreEqual(KeyCode.D, controller.RightKey);
            Assert.AreEqual(KeyCode.A, controller.LeftKey);
        }

        [UnityTest]
        public IEnumerator SwappedDirectionalKeyTest()
        {
            var game_object = new GameObject();
            var player = game_object.AddComponent<PlayerController>();
            var controller = player.GetComponent<PlayerController>();

            controller.SwapKeys(true);

            yield return null;

            Assert.AreEqual(KeyCode.A, controller.RightKey);
            Assert.AreEqual(KeyCode.D, controller.LeftKey);
        }

        [UnityTest]
        public IEnumerator SwappedDirectionalKeyBackToDefaultTest()
        {
            var game_object = new GameObject();
            var player = game_object.AddComponent<PlayerController>();
            var controller = player.GetComponent<PlayerController>();

            controller.SwapKeys(true);
            controller.SwapKeys(false);

            yield return null;

            Assert.AreEqual(KeyCode.D, controller.RightKey);
            Assert.AreEqual(KeyCode.A, controller.LeftKey);
        }
    }
}
