
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  [SerializeField]
  GameObject _sceneSequencer = null;
  GameObject sceneSequencerObject {
    get {
      if (_sceneSequencer == null) { _sceneSequencer = Resources.Load<GameObject>(""); }
      return _sceneSequencer;
    }
  }

  [SerializeField]
  GameObject _audioManager = null;
  GameObject audioManagerObject {
    get {
      if (_audioManager == null) { _audioManager = Resources.Load<GameObject>(""); }
      return _audioManager;
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
  }
}
