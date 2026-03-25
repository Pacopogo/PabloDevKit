using UnityEngine;

namespace PabloDialogue
{
    [CreateAssetMenu(fileName = "Profile", menuName = "Dialogue/Profile", order = 1)]
    public class DialogueProfile : ScriptableObject
    {
        [Header("Personality")]
        public string Name = "No Name";         //Name of speaker
        public Sprite Sprite;                   //Character sprite

        [Header("Typing")]
        public float TypeSpeed = 5;             //The speed at which the dialogue will be typed
        public Color TextColor = Color.white;   //Text color
        public AudioClip TypeClip;              //for when text is typed out
        public Vector2 PitchRange = Vector2.one;//the range between which random pitches it takes (if x and y are the same that is just the set pitch)

    }
}
