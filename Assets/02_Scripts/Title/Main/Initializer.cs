using UnityEngine;

namespace _02_Scripts.Title.Main
{
    public static class Initializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Execute() {
            Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Main")));
        }
    }
}