using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector director;
    public KeyCode togglePauseKey = KeyCode.Space;
    /*
    [Space, Header("Timestepping")]
    public KeyCode restartKey = KeyCode.Home;
    public KeyCode incrementTimeKey = KeyCode.RightArrow;
    public KeyCode decrementTimeKey = KeyCode.LeftArrow;
    public float timeStep = 10;
    */

    void Update()
    {
        if (Input.GetKeyDown(togglePauseKey))
        {
            if (director.state == PlayState.Paused)
                director.Resume();
            else
                director.Pause();
        }

        /*
        if (Input.GetKeyDown(restartKey))
            director.time = 0;

        if (Input.GetKeyDown(incrementTimeKey))
        {
            if (director.time + timeStep > director.duration)
                director.time = director.duration;
            else
                director.time += timeStep;
        }

        if (Input.GetKeyDown(decrementTimeKey))
        {
            if (director.time - timeStep < 0)
                director.time = 0;
            else
                director.time -= timeStep;
        }
        */
    }
}