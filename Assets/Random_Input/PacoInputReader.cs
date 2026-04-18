using UnityEngine;

public class PacoInputReader : MonoBehaviour
{
    public RandomInput RandomInput;
    public InputData currentInput;
    public bool IsReading;

    private void Start()
    {
        SetOther();
    }

    private void Update()
    {
        ReadingInput();
    }

    public void ReadingInput()
    {
        IsReading = currentInput.inputContext.action.IsPressed();
    }

    [ContextMenu("Randomize")]
    public void SetOther()
    {
        currentInput = RandomInput.GetRandomInput();
    }
}
