using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour
{
    const float FADING_SPEED = 1f;

    private Text _textToFade;

    private void Start()
    {
        _textToFade = GetComponent<Text>();
        StartCoroutine(FadeCrtn());
    }
    
    private IEnumerator FadeCrtn()
    {
        if(_textToFade == null)
            yield break;

        var color = _textToFade.color;

        while (color.a > 0f)
        {
            color.a -= FADING_SPEED * Time.deltaTime;
            _textToFade.color = color;
            yield return new WaitForEndOfFrame();
        }
    }
}
