using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogSystem : MonoBehaviour
{
    public static void ShowDialog(MonoBehaviour caller, string[] lines, TMP_Text text)
    {
        caller.StartCoroutine(ShowLines(lines, text));
    }

    private static IEnumerator ShowLines(string[] lines, TMP_Text text)
    {
        text.CrossFadeAlpha(0.0f, 0.0f, true);

        foreach (string line in lines)
        {
            // set text and fade in
            text.text = line;
            text.CrossFadeAlpha(1.0f, 0.5f, true);
            yield return new WaitForSeconds(2.5f);

            // fade out
            text.CrossFadeAlpha(0, 0.5f, true);
            yield return new WaitForSeconds(1.0f);
        }

        text.text = null;
        text.CrossFadeAlpha(0.0f, 0.0f, true);
    }
}
