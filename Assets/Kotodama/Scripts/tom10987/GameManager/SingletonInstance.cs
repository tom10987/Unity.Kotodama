
using UnityEngine;


[System.Serializable]
public class SingletonInstance {

  [SerializeField]
  GameObject _sceneSequencer = null;
  public GameObject sceneSequencerObject {
    get {
      if (_sceneSequencer == null) { _sceneSequencer = Resources.Load<GameObject>("GameManager/SceneSequencer"); }
      return _sceneSequencer;
    }
  }

  [SerializeField]
  GameObject _audioManager = null;
  public GameObject audioManagerObject {
    get {
      if (_audioManager == null) { _audioManager = Resources.Load<GameObject>("Audio/AudioManager"); }
      return _audioManager;
    }
  }

  [SerializeField]
  GameObject _mainUI = null;
  public GameObject mainUIObject {
    get {
      if (_mainUI == null) { _mainUI = Resources.Load<GameObject>("GameUI/MainUI"); }
      return _mainUI;
    }
  }
}
