/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the SceneLoader class, which contains
the scene name that LoadSceneManager will call
*/
namespace GPEJ
{
    public static class SceneLoader
    {
        public static string SceneToLoad;
        public static readonly string MainMenu = "Menu-Scene";
        public static readonly string Game = "Game-Scene";
        public static readonly string Load = "Load-Scene";
    }
}
