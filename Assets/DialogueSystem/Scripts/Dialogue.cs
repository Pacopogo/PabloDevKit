using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace PabloDialogue
{
    [System.Serializable]
    public class DialogueInfo
    {

        public DialogueProfile profile;
        [Space(10)]
        [TextArea(5, 5)]
        public string text;                   //the dialogue itself

        [Header("Sounds & Clips")]
        public AudioClip initalClip;          //for sound effects or voice gasps
        public AudioClip voiceLine;           //For if we want to voice over the clip

        [Header("Timer")]
        public bool isTimed = false;
        public float time = 1f;

    }

    [CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue", order = 1)]
    public class Dialogue : ScriptableObject
    {
        public DialogueInfo[] dialogue;
    }
}