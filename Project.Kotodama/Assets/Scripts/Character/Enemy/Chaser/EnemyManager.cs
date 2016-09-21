
using System.Collections.Generic;

public class EnemyManager : SingletonBehaviour<EnemyManager> {

  readonly List<ChaseActor> _actors = new List<ChaseActor>();
  public List<ChaseActor> actors { get { return _actors; } }

  public bool isActive { get; private set; }

  /// <summary> 管理下にある全ての敵キャラを起動する </summary>
  public void ActivateActors() {
    isActive = true;
    foreach (var actor in _actors) {
      actor.gameObject.SetActive(isActive);
      actor.Activate();
    }
  }

  /// <summary> 管理下にある全ての敵キャラの動作を停止 </summary>
  public void Pause() { isActive = false; }

  /// <summary> 敵キャラを全て削除 </summary>
  public void DestroyActors() {
    Pause();
    foreach (var actor in _actors) { actor.Delete(); }
    actors.Clear();
  }
}
