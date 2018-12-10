using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutState : AFadeStates
{
    public FadeOutState(Fading fading, bool active, float duration, string nextScene)
    {
        Fading = fading;
        Active = active;
        Setup(duration);
        NextScene = nextScene;
    }

    public override void Setup(float fadeDuration)
    {
        Fade(this, fadeDuration);
        return;
    }

    override public void Transit(float fadeDuration)
    {
        if (Active)
        {
            if (!isTransitioning)
                return;
            Transition += Time.deltaTime * (1 / Duration);
            Fading.TransitionImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, Transition);
            Fading.AudioSource.volume = Mathf.Lerp(1f, 0f, Transition);

            if (Transition > 1 || Transition < 0)
            {
                Fading.AudioSource.Stop();
                isTransitioning = false;
                Active = false;
                SceneManager.LoadScene(NextScene);
                // Setup scene load function here 

            }
        }

    }

}