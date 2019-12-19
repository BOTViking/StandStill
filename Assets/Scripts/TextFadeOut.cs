using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class TextFadeOut : MonoBehaviour
{
    //Fade time in seconds
    public float fadeOutTime;
    public void FadeOut()
    {
        Text myText = GetComponent<Text>();
        myText.color = new Color(255,255,255);
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        Text text = GetComponent<Text>();
        Color originalColor = text.color;
        for (float t = 0.001f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }
}