using UnityEngine;

public class CharacterData : ScriptableObject
{
    [field: SerializeField] public int FighterID { get; private set; }
    [field: SerializeField] public float BaseSpeed { get; private set; }
}