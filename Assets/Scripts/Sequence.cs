using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public struct SequenceStep
{
    [TextArea] public string text;
    public float time;
    public bool changeSprite;
    public Sprite newSprite;
    public bool changeSound;
    public AudioClip newSound;
}

[CreateAssetMenu(fileName = "New Sequence", menuName = "Narrative Sequence")]
public class Sequence : ScriptableObject
{
    public string sequenceName;

    public List<SequenceStep> steps;

    [Header("Final Sequence")]
    [TextArea] public string finalText;

    public string optionAText;
    public Sequence optionASequence;
    
    public string optionBText;
    public Sequence optionBSequence;

    public bool isEnd;
}
