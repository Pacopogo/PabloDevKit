using TMPro;
using UnityEngine;

public class DebugInputDisplay : MonoBehaviour
{
    [SerializeField] private PacoInputReader reader;
    [SerializeField] private TMP_Text textDisplay;


    private void Update()
    {
        textDisplay.text = reader.currentInput.InputTitle;
    }
}
