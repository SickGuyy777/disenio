using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GranadeText : MonoBehaviour
{
    public CharacterController granadeE;
    public Text granadeText;

    private void Start()
    {
        UpdateGranadeText();
    }

    private void Update()
    {
        UpdateGranadeText();
    }

    public void UpdateGranadeText()
    {
        granadeText.text = $"{granadeE.currentGranadeCant}";
    }
}
