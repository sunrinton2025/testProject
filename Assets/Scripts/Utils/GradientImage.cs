using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientImage : MonoBehaviour
{
    Image image;
    [SerializeField]
    List<Color> colors = new();
    [SerializeField]
    float delay;
    [SerializeField]
    bool useRealtime;
    int index;
    float time;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (useRealtime)
            time += Time.unscaledDeltaTime;
        else
        {
            time += Time.deltaTime;
        }

        if (colors.Count > 0)
        {
            float t = Mathf.Clamp01(time / delay);

            image.color = Color.LerpUnclamped(image.color, colors[index], t);

            if (time >= delay)
            {
                index++;
                time = 0;

                if (index >= colors.Count)
                {
                    index = 0;
                }
            }
        }
    }
}
