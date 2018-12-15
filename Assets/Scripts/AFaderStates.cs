using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class AFaderStates
{
    protected AFaderStates Instance;
    protected Fader Fader;
    protected string NextScene; 
    protected bool isTransitioning;
    protected float Transition;
    public float Duration;

    public void GeneralSetup(AFaderStates state, float duration)
    {
        isTransitioning = true;
        Duration = duration;
        Transition = (state.GetType() == typeof(FaderInState)) ? 1 : 0;
    }

    /// <summary>
    /// Bringing the fade in/out to the screen.
    /// </summary>
    /// <param name="fadeDuration"></param>
    abstract public void Transit();
    /// <summary>
    /// Setting up basic values.
    /// </summary>
    /// <param name="fadeDuration"></param>
    abstract public void Setup(float fadeDuration);

}