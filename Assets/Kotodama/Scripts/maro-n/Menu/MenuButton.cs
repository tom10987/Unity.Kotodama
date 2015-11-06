
using UnityEngine;


public class MenuButton : MonoBehaviour {

  SceneSequencer _sequencer = null;


  void Start() {
    _sequencer = FindObjectOfType<SceneSequencer>();
  }


  public void Back() {
    DestroyObject();
  }

  public void GoTitle() {
    DestroyObject();
    _sequencer.SceneFinish("Title");
  }

  void DestroyObject() {
    Destroy(gameObject);
  }
}
