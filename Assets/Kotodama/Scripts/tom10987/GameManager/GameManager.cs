
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  [SerializeField]
  GameObject _sceneSequencer = null;

  [SerializeField]
  GameObject _audioManager = null;

  public bool isPause { get; set; }


  protected override void Awake() {
    base.Awake();
    DontDestroyOnLoad(gameObject);
  }

  void Start() {
    isPause = false;
  }
}
