using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// FaderOutState is deriving from AFaderStates and helps in providing a State Pattern for
/// having the Fader to work. FaderOutState is used, when a Fade Out from a Scene shall occur.
/// </summary>

public class FaderOutState : AFaderStates
{

    /// <summary>
    /// Initializes a new FaderOutState object.
    /// </summary>
    /// <param name="fader"></param>
    /// <param name="stateActive"></param>
    /// <param name="duration"></param>
    /// <param name="nextScene"></param>
    public FaderOutState(Fader fader, float duration, string nextScene)
    {
        Fader = fader;
        Setup(duration);
        NextScene = nextScene;
    }

    /// <summary>
    /// Refreshes the attributes used from the AbstractFaderStates. 
    /// </summary>
    /// <param name="fadeDuration"></param>
    public override void Setup(float fadeDuration)
    {
        GeneralSetup(this, fadeDuration);
    }

    /// <summary>
    /// Bringing the fade out to the screen and also reducing the volume of the Fader's music. Lastly, loads the following scene after the fade out.
    /// </summary>
    /// <param name="fadeDuration"></param>
    override public void Transit()
    {
        if (!isTransitioning)
            return;
        Transition += Time.deltaTime * (1 / Duration);
        Fader.TransitionImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, Transition);
        Fader.AudioSource.volume = Mathf.Lerp(1f, 0f, Transition);

        if (Transition > 1 || Transition < 0)
        {
            Fader.AudioSource.Stop();
            isTransitioning = false;
            // Setup scene load function here as you need
            SceneManager.LoadScene(NextScene);
        }
    }

}