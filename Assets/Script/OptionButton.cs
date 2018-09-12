using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour {

    GameObject optionPanel;
    GameObject pausePanel;

	// Use this for initialization
	void Start () {
        optionPanel = GameObject.Find("OptionPanel");
        pausePanel = GameObject.Find("PausePanel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickOptionInactive()
    {
        pausePanel.SetActive(true);
        optionPanel.SetActive(false);
    }
}
