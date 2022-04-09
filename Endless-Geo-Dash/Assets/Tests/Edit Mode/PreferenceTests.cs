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
    /*
    [Test]
    public void MasterVolumeTest()
    {

    }

    [Test]
    public void MusicVolumeTest()
    {

    }

    [Test]
    public void SFXVolumeTest()
    {

    }

    [Test]
    public void UIVolumeTest()
    {

    }

    [Test]
    public void HighScoreTest()
    {

    }
    */
}
