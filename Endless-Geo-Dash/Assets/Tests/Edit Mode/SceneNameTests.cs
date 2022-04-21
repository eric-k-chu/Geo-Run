/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

SUMMARY:
SceneNameTests verifies that each scene name strings 
from SceneLoader are correctly typed.
*/
using NUnit.Framework;
using GPEJ;

public class SceneNameTests
{
    [Test]
    public void MenuScene()
    {
        Assert.AreEqual("Menu-Scene", SceneLoader.MainMenu);
    }

    [Test]
    public void GameScene()
    {
        Assert.AreEqual("Game-Scene", SceneLoader.Game);
    }

    [Test]
    public void LoadScene()
    {
        Assert.AreEqual("Load-Scene", SceneLoader.Load);
    }
}
