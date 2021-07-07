using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoComponent : MonoBehaviour
{
    [SerializeField] private Button infoButton;
    [SerializeField] private GameObject infoTextObj;

    private void Awake()
    {
        infoButton.onClick.AddListener(ToggleShowInfo);
    }

    private void ToggleShowInfo()
    {
        infoTextObj.SetActive(!infoTextObj.activeSelf);
    }
}
