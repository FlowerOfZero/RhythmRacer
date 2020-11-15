using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class UIFader : MonoBehaviour
{
    public Text text;
    public float t;


    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    private void Update()
    {
        t += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + .01f, gameObject.transform.position.z);
        if (t > 2)
            Destroy(gameObject);
    }

    //Fade time in seconds
    public float fadeOutTime;
    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        
        Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }
}
