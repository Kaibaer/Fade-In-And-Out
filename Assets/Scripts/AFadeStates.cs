using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class AFadeStates
{
    protected AFadeStates Instance { get; set; }
    protected Fading Fading { get; set; }
    protected string NextScene { get; set; }
    protected bool isShowing;
    protected bool isTransitioning;
    protected float Transition;
    protected bool Active;
    public float Duration;
    public bool Initialized = false;


    public void Awake()
    {
        Instance = this;
    }

    abstract public void Transit(float fadeDuration);
    abstract public void Setup(float fadeDuration);

    public void Fade(AFadeStates state, float duration)
    {
        isTransitioning = true;
        Duration = duration;
        Transition = (state.GetType() == typeof(FadeInState)) ? 1 : 0;
    }

}