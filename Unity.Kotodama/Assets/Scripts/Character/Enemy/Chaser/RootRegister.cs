
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

//------------------------------------------------------------
// TIPS:
// 敵キャラの行動ルートを管理
// 複数の空オブジェクトを子オブジェクトにして、その座標を利用する
//
//------------------------------------------------------------

public class RootRegister : MonoBehaviour {

  IEnumerable<Vector3> _rootSpots = null;

  public void Initialize() {
    var children = this.GetComponentsOnlyChildren<Transform>();
    _rootSpots = children.Select(child => child.position);
  }

  /// <summary> 支配下にある全ての子オブジェクトの座標を取得 </summary>
  public IEnumerable<Vector3> GetRootSpots() {
    foreach (var spot in _rootSpots) { yield return spot; }
  }
}
