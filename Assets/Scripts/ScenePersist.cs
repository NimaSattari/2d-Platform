using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int StartingSceneIndex;

    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if(numScenePersist> 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        StartingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(CurrentSceneIndex != StartingSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
