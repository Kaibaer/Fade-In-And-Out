Careful: No Null-Checks at the moment!

To use this Fade In and Out Manager:

- Add Prefab "SceneManager" to the scene
- Click on "FadeManager" in the "SceneManger"
- Add the name of the follow up scene of the current scene via "Follow Up Scene", please use the folder + name (eg. Folder: Scenes, Scene: Scene2 => Scenes/Scene2)
- Add a "Transition Image" if wanted (currently, it is just a black screen)
- Set the "Duration" of the fade in and fade out (currently the same time)
- To change the level sound, add another AudioClip to the AudioSource component attached to the FadeManger. 



See the example at: https://www.youtube.com/watch?v=AcCe611foT0



\```mermaid

classDiagram

​    MonoBehavior <|-- Fader

​    Fader -- AFaderStates

​    AudioSource -- Fader

​    Image -- Fader

​    AFaderStates <|-- FaderOutState

​    AFaderStates <|-- FaderInState

​    AFaderStates : bool : IsTransitioning

​    AFaderStates : Transit()

​    AFaderStates : Fade()

​    AFaderStates : Setup()

​    AFaderStates : float : Transition

​    Fader : float : Duration

​    Fader : string : NextScene

\```