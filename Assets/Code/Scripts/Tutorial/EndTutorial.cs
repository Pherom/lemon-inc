using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour
{
    [SerializeField]
    private string yardScenePath;

    public void FinishTutorial()
    {
        SceneManager.LoadScene(yardScenePath);
    }
}
