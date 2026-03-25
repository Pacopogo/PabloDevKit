
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PabloDialogue
{
    public class DialogueSystem : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject dialogueCanvas;
        [SerializeField] private Image characterImg;
        [SerializeField] private Animator characterAni;
        [Space(10)]
        [SerializeField] private TMP_Text nameTMP;
        [SerializeField] private TMP_Text dialogueTMP;
        [Space(10)]
        [SerializeField] private SimpleAudioPlayer audioPlayer;

        private Dialogue dialogue;
        private int current = 0;

        private bool isTyping = false;

        [Header("Events")]
        [SerializeField] private UnityEvent OnStart;
        [SerializeField] private UnityEvent OnFinish;

        #region Dialogue Functions

        private void SetDialogueData(Dialogue d) => dialogue = d;
        public void StartDialogue(Dialogue d)
        {
            StopAllCoroutines();
            dialogueTMP.text = "";

            SetDialogueData(d);

            dialogueCanvas.SetActive(true);

            current = 0;
            SetDialogueComponents(current);


            OnStart?.Invoke();
        }

        private void EndDialogue()
        {
            dialogueCanvas.SetActive(false);
            OnFinish?.Invoke();
        }

        public void SetDialogueComponents(int index)
        {
            if (dialogue == null)
                return;

            Sprite sprite = dialogue.dialogue[index].profile.Sprite;

            if (sprite == null)
            {
                characterImg.enabled = false;
            }
            else
            {
                characterImg.enabled = true;
                characterImg.sprite = sprite;
            }
            nameTMP.text = dialogue.dialogue[index].profile.Name;

            dialogueTMP.color = dialogue.dialogue[index].profile.TextColor;

            StartCoroutine(WaitAndPrint(index));
        }

        public void NextDialogue()
        {
            StopAllCoroutines();

            if (isTyping == true)
            {
                dialogueTMP.text = dialogue.dialogue[current].text;

                isTyping = false;
                DoneTyping();

                return;
            }

            current++;

            if (current >= dialogue.dialogue.Length)
            {
                current = 0;
                EndDialogue();

                return;
            }

            SetDialogueComponents(current);
        }

        #endregion

        private IEnumerator WaitAndPrint(int index)
        {
            AudioClip clip = dialogue.dialogue[index].profile.TypeClip;
            float speed = dialogue.dialogue[index].profile.TypeSpeed * 0.01f;

            dialogueTMP.text = "";

            foreach (char c in dialogue.dialogue[index].text)
            {
                isTyping = true;

                Vector2 pitchRange = dialogue.dialogue[index].profile.PitchRange;
                float rndPitch = Random.RandomRange(pitchRange.x, pitchRange.y);

                yield return new WaitForSeconds(speed);

                audioPlayer.SetPitch(rndPitch);
                audioPlayer.PlayAudioClip(clip);
                dialogueTMP.text += c;

                CheckAnimation();
            }

            isTyping = false;
            DoneTyping();

            StopCoroutine(WaitAndPrint(index));
        }

        private void DoneTyping()
        {
            CheckAnimation();

            if (!dialogue.dialogue[current].isTimed)
                return;
            StartCoroutine(TimeElaspedToNextDialogue());
        }

        private IEnumerator TimeElaspedToNextDialogue()
        {
            yield return new WaitForSeconds(dialogue.dialogue[current].time);
            NextDialogue();
        }


        private void CheckAnimation()
        {
            if (characterAni == null)
                return;

            characterAni.SetBool("isTyping", isTyping);
        }
    }
}