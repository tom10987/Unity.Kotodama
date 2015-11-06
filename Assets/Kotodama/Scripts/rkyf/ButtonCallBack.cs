
using UnityEngine;


public class ButtonCallBack : MonoBehaviour {

  SceneSequencer _sequencer;


  void Start() {
    _sequencer = FindObjectOfType<SceneSequencer>();
  }


  public void Retry() {
    Debug.Log("pushed retry");
    //_sequencer.SceneFinish("Chapter1");
  }

  public void GoTitle() {
    _sequencer.SceneFinish("Title");
  }

  public void Quit() {
    Destroy(gameObject);
    Application.Quit();
  }
}
