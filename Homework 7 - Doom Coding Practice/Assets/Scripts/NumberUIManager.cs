using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class NumberUIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Sprite[] DigitSrites;

    private Image[] digits;
    private Health playerHealth;

    private string numberType;

    // Start is called before the first frame update
    void Start()
    {
        digits = GetComponentsInChildren<Image>(true);
        playerHealth = player.GetComponent<Health>();

        numberType = gameObject.tag;
    }

    private void Update()
    {
        if (numberType == "NumberHP")
            SetNumber(playerHealth.HP);
        else if (numberType == "NumberArmor")
            SetNumber(playerHealth.Armor);
    }

    private void SetNumber(int number)
    {
        if (number < 0)
            return;

        for (int i = 1; i < digits.Length; i++)
            digits[i].gameObject.SetActive(true);

        digits[0].sprite = DigitSrites[number % 10];

        if (number >= 10)
            digits[1].sprite = DigitSrites[(number / 10) % 10];
        
        if (number >= 100)
            digits[2].sprite = DigitSrites[(number / 100)];
    }

}
