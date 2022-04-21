/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

SUMMARY:
PreferenceTests tests that the strings of Preference is the
correct string.
*/
using NUnit.Framework;
using GPEJ;

public class PreferenceTests
{
    [Test]
    public void CharacterTypeTest() 
    {
        Assert.AreEqual("Character-Type", Preference.CharacterType);
    }
    
    [Test]
    public void MasterVolumeTest()
    {
        Assert.AreEqual("Master-Volume", Preference.MasterVolume);
    }
    
    [Test]
    public void MusicVolumeTest()
    {
        Assert.AreEqual("Music-Volume", Preference.MusicVolume);
    }

    [Test]
    public void SFXVolumeTest()
    {
        Assert.AreEqual("SFX-Volume", Preference.SFXVolume);
    }

    [Test]
    public void UIVolumeTest()
    {
        Assert.AreEqual("UI-Volume", Preference.UIVolume);
    }

    [Test]
    public void HighScoreTest()
    {
        Assert.AreEqual("High-Score", Preference.HighScore);
    }
    
}
