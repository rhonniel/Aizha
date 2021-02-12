using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBloks;

    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBloks()
    {
        breakableBloks++;
        
    }

    public void BlockDestroyed()
    {
        breakableBloks--;
        if (breakableBloks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
