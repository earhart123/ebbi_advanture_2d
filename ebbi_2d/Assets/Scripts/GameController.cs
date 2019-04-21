using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	enum State
	{
		Ready,
		Play,
		GameOver,
        Clear
	} 
	
	State state;
	int score;
	
	public EbbiController ebbi;
    public Text scoreLabel;
    public Image GetReadyImage;
    public Image GameOverImage;
    public Button Next;
    public Button BackStage;
    public Button Retire;
    public int scoreCheck;

    void Start ()
	{
		Ready();
	}
	
	void LateUpdate ()
	{
        switch (state)
        {
            case State.Ready:
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case State.Play:
                if (ebbi.isDead == true) GameOver();
                else if (score == scoreCheck) Clear();
                break;
            case State.GameOver:
                if (Input.GetButtonDown("Fire1")) Reload();
                break;
        }
	}
	
	void Ready ()
	{
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject so in scrollObjects) so.enabled = false;
        state = State.Ready;
        
        //ebbi.SetSteerActive(false);
        
        GameOverImage.gameObject.SetActive(false);
        Next.gameObject.SetActive(false);
        Retire.gameObject.SetActive(false);
        BackStage.gameObject.SetActive(false);
        GetReadyImage.gameObject.SetActive(true);
	}
	
	void GameStart ()
	{
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject so in scrollObjects) so.enabled = true;
        //ebbi.SetSteerActive(true);
        state = State.Play;
		
		ebbi.Flap();

        GetReadyImage.gameObject.SetActive(false);
	}
	
	void GameOver ()
	{
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject so in scrollObjects) so.enabled = false;
		state = State.GameOver;

        GameOverImage.gameObject.SetActive(true);
	}

    void Reload()
    {
        GameOverImage.gameObject.SetActive(false);
        Retire.gameObject.SetActive(true);
        BackStage.gameObject.SetActive(true);
    }

    void Clear()
    {
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject so in scrollObjects) so.enabled = false;
        GameOverImage.gameObject.SetActive(false);
        Next.gameObject.SetActive(true);
        BackStage.gameObject.SetActive(true);
    }

    public void IncreaseScore()
    {
        score++;
        scoreLabel.text = score + " / ";
    }
}