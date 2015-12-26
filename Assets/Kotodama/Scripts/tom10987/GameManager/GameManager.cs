
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  [SerializeField]
  SingletonInstance _instances = null;

  public bool isPause { get; set; }


  protected override void Awake() {
    base.Awake();
    isPause = false;
  }

  void Start() {
    DontDestroyOnLoad(gameObject);
    DontDestroyOnLoad(Instantiate(_instances.sceneSequencerObject));
    DontDestroyOnLoad(Instantiate(_instances.audioManagerObject));
    DontDestroyOnLoad(Instantiate(_instances.mainUIObject));
    DontDestroyOnLoad(Instantiate(_instances.enemyManagerObject));
  }
}
