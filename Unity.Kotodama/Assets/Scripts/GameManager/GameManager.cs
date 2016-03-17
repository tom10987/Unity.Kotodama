
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

  [SerializeField]
  EnemyManager _enemyManager = null;
  public EnemyManager enemy { get { return _enemyManager; } }

  [SerializeField]
  ItemManager _itemManager = null;
  public ItemManager item { get { return _itemManager; } }

  [SerializeField]
  WindowManager _windowManager = null;
  public WindowManager window { get { return _windowManager; } }

  /// <summary> シーン開始時のプレイヤー初期位置を指定 </summary>
  public Vector3 start { get; set; }

  public GameScene current { get; set; }
  public GameScene previous { get; set; }

  void Start() { start = Vector3.zero; }

  public void Pause() {
    PlayerState.instance.Stop();
    EnemyManager.instance.ActivateActors();
  }

  public void ReStart() {
    PlayerState.instance.Play();
    EnemyManager.instance.Pause();
  }
}
