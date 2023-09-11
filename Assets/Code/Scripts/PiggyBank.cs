using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PiggyBank : MonoBehaviour
{
    [SerializeField]
    private double contents = 0;

    [SerializeField]
    private float scoreToCashMultiplier = 0.25f;

    [SerializeField]
    private GameObject cashInfoObject;

    public float ScoreToCashMultiplier
    {
        get { return scoreToCashMultiplier; }
    }

    public void IncreaseContents(double amount)
    {
        TextMeshProUGUI cashAddedText = cashInfoObject.GetComponentInChildren<TextMeshProUGUI>();
        cashAddedText.text = string.Format("+${0:0.##}", amount);
        GetComponentInChildren<Animator>().Play(0);
        contents += amount;
    }
}
