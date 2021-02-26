using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerNextStage : MonoBehaviour {

    public string nextScene;
    public fade f;

	// Use this for initialization
	void Start () {

        GetComponent<MeshRenderer>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            goNext();
        }

    }

    void next()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void goNext()
    {
        f.setFadeIn();
        Invoke("next", 4);
    }

}
