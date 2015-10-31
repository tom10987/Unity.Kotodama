using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CallGameOver : MonoBehaviour
{
    //[SerializeField]
    //private
    //    GameObject
    //                gameOver_;

    SceneSequencer sceneSequencer_;
    //GameObject SS;


	void
        Start()
    {
        //gameOver_ = null;

        //SS = null;

        //sceneSequencer_ = GetComponent<SceneSequencer>();
        sceneSequencer_ = GameObject.FindObjectOfType<SceneSequencer>();

	}

    public void EndGame()
    {
        Destroy(this.gameObject);
    }

    public void Retry()
    {
        sceneSequencer_.SceneFinish("Chapter1");
    }

    public void GoTitle()
    {
        sceneSequencer_.SceneFinish("Title");
    }
}
