using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage : MonoBehaviour {

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Stage");
    }
}
