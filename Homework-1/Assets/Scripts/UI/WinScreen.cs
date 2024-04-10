using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WInScreen : MonoBehaviour
{
    [SerializeField] string menuSceneName;

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }
}
