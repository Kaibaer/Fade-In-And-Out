using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaderInState : AFaderStates
{
    /// <summary>
    ///Initializes a new FaderOutState object.
    /// </summary>
    /// <param name="fader"></param>
    /// <param name="stateActive"></param>
    /// <param name="duration"></param>
    public FaderInState(Fader fader, float duration)
    {
        Fader = fader;
        Setup(duration);
    }

    /// <summary>
    /// Refreshes the attributes used from the AbstractFaderStates. 
    /// </summary>
    /// <param name="fadeDuration"></param>
    override public void Setup(float fadeDuration)
    {
        Fader.AudioSource.volume = 0f;
        Fader.AudioSource.playOnAwake = true;
        GeneralSetup(this, fadeDuration);
    }

    /// <summary>
    /// Bringing the fade in to the screen and also increasing the volume of the Fader's music.
    /// </summary>
    /// <param name="fadeDuration"></param>
    override public void Transit()
    {
        if (!isTransitioning)
            return;
        Transition += -Time.deltaTime * (1 / Duration);
        Fader.TransitionImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, Transition);
        Fader.AudioSource.volume = Mathf.Lerp(1f, 0f, Transition);

        if (Transition > 1 || Transition < 0)
        {
            isTransitioning = false;
        }
    }
}