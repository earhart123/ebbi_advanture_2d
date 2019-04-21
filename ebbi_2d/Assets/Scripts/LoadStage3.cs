using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage3 : MonoBehaviour {
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Stage3");
    }
}
