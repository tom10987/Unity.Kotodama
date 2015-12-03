using UnityEngine;

public class MenuButton : MonoBehaviour {

  SceneSequencer _sequencer = null;
  UIScript _uiScript = null;

  void Start() {
    _sequencer = FindObjectOfType<SceneSequencer>();
    _uiScript = FindObjectOfType<UIScript>();
  }

  public void Back() {
    _uiScript._menuActive = false;
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
