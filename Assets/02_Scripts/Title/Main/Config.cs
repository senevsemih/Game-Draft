using UnityEngine;

namespace _02_Scripts.Title.Main
{
    /// Global configuration data container
    [CreateAssetMenu(fileName = "Config", menuName = "GamePackage/Config", order = 0)]
    public class Config: ScriptableObject
    {
        public float Value;
    }
}