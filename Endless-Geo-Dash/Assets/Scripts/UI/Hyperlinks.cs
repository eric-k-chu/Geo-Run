/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the Hyperlinks class, which opens the url for hyper links
*/

using UnityEngine;

namespace GPEJ.UI
{
    public class Hyperlinks : MonoBehaviour
    {
        public void OpenURL(string link)
        {
            Application.OpenURL(link);
        }
    }
}
