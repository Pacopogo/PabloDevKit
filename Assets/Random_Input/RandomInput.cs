using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RandomInput : MonoBehaviour
{
    [SerializeField] private List<InputData> inputDatas;

    public InputData GetRandomInput() => inputDatas[Random.Range(0, inputDatas.Count)];
}
