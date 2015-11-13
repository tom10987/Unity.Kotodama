
using UnityEngine;
using System.Collections.Generic;

//
// 敵キャラの管理
//
// 更新する対象キャラクターを追加するのは、各オブジェクトの
// Start() メソッドの最後に行う
//

public class EnemyManager : MonoBehaviour {

  static List<EnemyActor> _actors = null;
  static public List<EnemyActor> actors {
    get {
      if (_actors == null) { _actors = new List<EnemyActor>(); }
      return _actors;
    }
  }


  void Awake() {
    var findManager = FindObjectsOfType<EnemyManager>();
    if (findManager.Length > 1) { Destroy(gameObject); return; }
    if (_actors.Count != 0) { _actors.Clear(); }
  }

  void Start() {
  }

  void Update() {
    //TODO: ポーズ中は敵キャラの更新をしない
    //if (true) { return; }
    foreach (var actor in _actors) { actor.Execute(); }
  }
}
