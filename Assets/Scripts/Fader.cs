using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour {

    private Fader Instance;
    protected AFaderStates State;
    public AudioSource AudioSource;
    public string FollowUpScene;
    public Image TransitionImage;
    public float Duration;

    public void Start()
    {
        Instance = this;
        State = new FaderInState(this, Duration); //FaderInState is always used, when the scene starts.
    }

    public void Update()
    {
        State.Transit(); 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            State = new FaderOutState(this, Duration, FollowUpScene);
        }
    }
}
