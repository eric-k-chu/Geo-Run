/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the SceneName class, which tests that SceneNames contains the correct
string for each scene.
*/
using NUnit.Framework;
using GPEJ;

public class SceneNameTests
{
    [Test]
    public void MenuScene()
    {
        Assert.AreEqual("Menu-Scene", SceneNames.MainMenu);
    }

    [Test]
    public void GameScene()
    {
        Assert.AreEqual("Game-Scene", SceneNames.Game);
    }

    [Test]
    public void LoadScene()
    {
        Assert.AreEqual("Load-Scene", SceneNames.Load);
    }
}
