using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

    private Fading Instance { get; set; }
    protected AFadeStates State { get; set; }
    public AudioSource AudioSource;
    public string FollowUpScene;
    public Image TransitionImage;
    public float Duration;

    public void Start()
    {
        Instance = this;
        Debug.Log("Started");
        State = new FadeInState(this, true, Duration);
    }

    public void Awake()
    {

    }

    public void Update()
    {
        State.Transit(Duration);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            State = new FadeOutState(this, true, Duration, FollowUpScene);
        }
    }
}
