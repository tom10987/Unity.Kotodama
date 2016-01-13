
using UnityEngine;
using System.Collections.Generic;


public class Command {
  public const string name = "name";
  public const string text = "text";
  public const string image = "image";
  public const string jump = "jump";
  public const string end = "end";
  public const string start = "start";
  public const string act = "act";
  public const string cashf = "cashf";
  public const string cashi = "cashi";
  public const string cashb = "cashb";
}


public class CharaName {
  public const string mari = "マリ";
  public const string nana = "ナナ";
  public const string empty = "";
  public const string narrator = "";
  public const string who = "？？？";
}


public class ImagePosition {
  /// <summary>
  /// position.y = -120;
  /// Left.x = -320; 
  /// Right.x = 320;
  /// center.x = 0;
  /// </summary>
  public const string left = "left";
  public const string right = "right";
  public const string center = "center";
}


public class ImageName {
  public const string REMOVE = "";
  // マリ
  public const string MARI_NORMAL = "mari01";
  // ナナ
  public const string NANA_NORMAL = "nana01";
}


public class EventResource : SingletonBehaviour<EventResource> {

  [SerializeField]
  public Sprite[] _mari;

  [SerializeField]
  public Sprite[] _nana;

  private Vector3 _left;
  private Vector3 _right;
  private Vector3 _center;

  public Dictionary<string, Sprite> _images = new Dictionary<string, Sprite>();
  public Dictionary<string, Vector3> _positions = new Dictionary<string, Vector3>();
  public Dictionary<string, int> _act = new Dictionary<string, int>();


  void Start() {
    _left = new Vector3(-320f, -120f);
    _center = new Vector3(0f, -120f);
    _right = new Vector3(320f, -120f);
    AddImages();
    AddPositions();
  }

  void AddImages() {
    // mari
    _images.Add(ImageName.MARI_NORMAL, _mari[0]);
    // nana
    _images.Add(ImageName.NANA_NORMAL, _nana[0]);
  }

  void AddPositions() {
    _positions.Add(ImagePosition.center, _center);
    _positions.Add(ImagePosition.left, _left);
    _positions.Add(ImagePosition.right, _right);
  }
}
