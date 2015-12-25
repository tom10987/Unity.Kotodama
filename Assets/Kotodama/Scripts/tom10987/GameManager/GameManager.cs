
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  [SerializeField]
  GameObject _sceneSequencer = null;
  GameObject sceneSequencerObject {
    get {
      if (_sceneSequencer == null) { _sceneSequencer = Resources.Load<GameObject>("GameManager/SceneSequencer"); }
      return _sceneSequencer;
    }
  }

  [SerializeField]
  GameObject _audioManager = null;
  GameObject audioManagerObject {
    get {
      if (_audioManager == null) { _audioManager = Resources.Load<GameObject>("Audio/AudioManager"); }
      return _audioManager;
    }
  }

  [SerializeField]
  GameObject _mainUI = null;
  GameObject mainUIObject {
    get {
      if (_mainUI == null) { _mainUI = Resources.Load<GameObject>("GameUI/MainUI"); }
      return _mainUI;
    }
  }

  public bool isPause { get; set; }


  protected override void Awake() {
    base.Awake();
    isPause = false;
  }

  void Start() {
    DontDestroyOnLoad(gameObject);
    DontDestroyOnLoad(Instantiate(sceneSequencerObject));
    DontDestroyOnLoad(Instantiate(audioManagerObject));
    DontDestroyOnLoad(Instantiate(mainUIObject));
  }
}
