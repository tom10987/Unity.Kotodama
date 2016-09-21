
using UnityEngine;
using System.Linq;

//------------------------------------------------------------
// TIPS:
// プレハブの座標調整専用
// 調整が終了したらスクリプトを外すこと
//
//------------------------------------------------------------

public class TreeGroupSort : MonoBehaviour {

  [SerializeField]
  Vector3 _groupOffset = Vector3.zero;

  static readonly float _treeScale = 4f;

  void OnValidate() {
    var children = this.GetComponentsOnlyChildren<TreeSort>();
    var rowCount = children.Count() - 1;
    var baseOffset = Vector3.back * rowCount * 0.5f * _treeScale;

    var i = 0;
    foreach (var child in children) {
      var translate = Vector3.forward * i * _treeScale;
      var offset = _groupOffset;
      offset.z = _groupOffset.z * (i++ - rowCount * 0.5f);
      child.transform.localPosition = translate + offset + baseOffset;
    }

    name = string.Format("TreeGroup({0})", children.Count());
  }
}
