using UnityEngine;
using System;
using TMPro;

public class ChangeAmountKills : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI amountKillUI;
    private int amountKill;

    private void Start()
    {
        Events.OnKilledEnemy += ChangeText;
    }

    private void ChangeText()
    {
        amountKill++;
        amountKillUI.text = "Killed: " + amountKill;
    }

    private void OnDestroy()
    {
        Events.OnKilledEnemy -= ChangeText;
    }
}
