
using UnityEngine;
using System.Collections.Generic;


/// <summary> ゲームの進行状態 </summary>
public enum GameState {
  NewGame,
  PhoneStart,
  PhoneClear,
  ManholeStart,
  ManholeClear,
  LabyrinthStart,
  LabyrinthClear,
  Ending,

  Max,
  None = -1,
}


public class GameManager : SingletonBehaviour<GameManager> {

  [SerializeField]
  SingletonInstance _instances = null;
  List<GameObject> _instanceManager = null;

  public GameState state { get; private set; }
  public void NextStage() { ++state; }

  public bool isPause { get; private set; }
  public Vector3 playerStartPosition { get; set; }


  public void SwitchPause() {
    isPause = !isPause;
    if (isPause) { EnemyManager.instance.PauseEnemies(); }
    else { EnemyManager.instance.StartEnemies(); }
  }


  protected override void Awake() {
    base.Awake();

    isPause = false;
    playerStartPosition = Vector3.zero;

    _instanceManager = new List<GameObject>();
    _instanceManager.Add(Instantiate(_instances.sceneSequencerObject));
    _instanceManager.Add(Instantiate(_instances.audioManagerObject));
    _instanceManager.Add(Instantiate(_instances.mainUIObject));
    _instanceManager.Add(Instantiate(_instances.enemyManagerObject));

    foreach (var instance in _instanceManager) { instance.transform.SetParent(transform); }
    DontDestroyOnLoad(gameObject);
  }
}
