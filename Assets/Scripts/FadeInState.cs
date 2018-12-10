using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInState : AFadeStates
{

    public FadeInState(Fading fading, bool active, float duration)
    {
        Fading = fading;
        Active = active;
        Setup(duration);

    }

    override public void Setup(float fadeDuration)
    {
        if (Active)
        {
            Fading.AudioSource.volume = 0f;
            Fading.AudioSource.playOnAwake = true;
            Fade(this, fadeDuration);
        }
    }

    override public void Transit(float fadeDuration)
    {
        if (Active)
        {
            if (!isTransitioning)
                return;
            Transition += -Time.deltaTime * (1 / Duration);
            Fading.TransitionImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, Transition);
            Fading.AudioSource.volume = Mathf.Lerp(1f, 0f, Transition);

            if (Transition > 1 || Transition < 0)
            {
                isTransitioning = false;
                Active = false;
            }
        }

    }
}