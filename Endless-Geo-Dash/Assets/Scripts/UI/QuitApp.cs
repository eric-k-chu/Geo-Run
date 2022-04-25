/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the QuitApp class, which allows the user to quit the game on a desktop 
platform.
*/

using UnityEngine;

public class QuitApp : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
}
