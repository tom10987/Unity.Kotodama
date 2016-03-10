
using UnityEngine;
using System.Linq;

//------------------------------------------------------------
// TIPS:
// プレハブの座標調整専用
// 調整が終了したらスクリプトを外すこと
//
//------------------------------------------------------------

public class TreeSort : MonoBehaviour {

  [SerializeField]
  bool _activate = false;

  [SerializeField]
  string _treeName = string.Empty;

  [SerializeField]
  float _offset = 3f;

  [SerializeField]
  float _scale = 1f;

  [SerializeField]
  Vector3 _polygonOffset = Vector3.zero;

  float treeOffset { get { return _offset * _scale; } }
  Vector3 treeScale { get { return Vector3.one * _scale; } }

  void OnValidate() {
    var children = this.GetComponentsOnlyChildren<TreeComponent>();
    var baseOffset = Vector3.left * treeOffset * (children.Count() - 1) * 0.5f;

    var i = 0;
    foreach (var child in children) {
      var number = (i < 10 ? string.Format("0{0}", i) : i.ToString());
      child.name = "Tree_" + number;
      child.polygon.localPosition = _polygonOffset;
      child.transform.localPosition = Vector3.right * (treeOffset * i++) + baseOffset;
      child.transform.localScale = treeScale;
    }
    transform.name = string.Format("Trees({0}_{1})", _treeName, i);
  }
}
