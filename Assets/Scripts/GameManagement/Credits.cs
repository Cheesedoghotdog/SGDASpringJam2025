using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    public bool isVisible = false;
    public TMP_Text textmeshPro;
    public void Start() {
    textmeshPro.color = new Color32(178, 16, 25, 0); }

    public void Appear() {
            StartCoroutine(Wait(0.01f));
    }
    IEnumerator Wait(float delay) {
            if(!isVisible) {
            for(byte i = 0; i < 255; i++) {
            textmeshPro.color = new Color32(178, 16, 25, i);
            isVisible = true;
            yield return new WaitForSeconds(delay);
        }
        } else {
            for(byte i = 255; i > 1; i--) {
            textmeshPro.color = new Color32(178, 16, 25, i);
            isVisible = false;
            yield return new WaitForSeconds(delay);
        }
        }
        }
}