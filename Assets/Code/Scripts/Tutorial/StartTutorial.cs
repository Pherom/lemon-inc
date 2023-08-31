using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTutorial : MonoBehaviour
{
    [SerializeField]
    private string tutorialScenePath;
    public void BeginTutorial()
    {
        SceneManager.LoadScene(tutorialScenePath);
    }
}
