
using UnityEngine;
using System.Linq;

//------------------------------------------------------------
// TIPS:
// プレハブの座標調整専用
// 調整が終了したらスクリプトを外すこと
//
//------------------------------------------------------------

public class GroundSort : MonoBehaviour {

  [SerializeField]
  bool _activate = false;

  [SerializeField]
  float _scale = 2f;

  float planeOffset { get { return _scale * 10f; } }
  Vector3 plane { get { return Vector3.one - Vector3.up; } }
  Vector3 planeScale { get { return plane * _scale + Vector3.up; } }

  void OnValidate() {
    var children = this.GetComponentsOnlyChildren<Transform>();
    var rowCount = Mathf.FloorToInt(Mathf.Sqrt(children.Count()));
    var baseOffset = -(plane * planeOffset) * (rowCount - 1) * 0.5f;

    var i = 0;
    foreach (var child in children) {
      var x = Vector3.right * planeOffset * (i % rowCount);
      var z = Vector3.forward * planeOffset * (i / rowCount);
      child.localPosition = x + z + baseOffset;
      child.localScale = planeScale;
      ++i;
    }
  }
}
