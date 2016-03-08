
using UnityEngine;
using UnityEngine.UI;


public class NovelSystem : SingletonBehaviour<NovelSystem> {

  EventResource eventSystem { get { return EventResource.instance; } }

  protected override void Awake() {
    base.Awake();
    _cashInt = 0;
    _cashFloat = 0f;
    _cashBool = false;
  }

  private Text _msgText = null;
  private Text _nameText = null;
  private Image _imageMari = null;
  private RectTransform _mariPosition = null;
  private Image _imageNana = null;
  private RectTransform _nanaPosition = null;
  private Image _nextIcon = null;

  public bool _isEndStory = false;

  public string[,] _reading;
  public int _msgCur = 0;
  public bool _isLineEnd = false;
  private float _count = 0f;

  private int _msgRow = 0;
  public float _msgSpeed = 0.5f;

  private GameObject _select = null;
  private GameObject _selectCanvas;
  private Button _button;
  public bool _isChoices = false;

  public int _cashInt;
  public float _cashFloat;
  public bool _cashBool;

  void Definition() {
    var obj = gameObject;
    _msgText = obj.transform.FindChild("Box/TextArea/Image/Text").GetComponent<Text>();
    _nameText = obj.transform.FindChild("Box/NameArea/Image/Name").GetComponent<Text>();
    _mariPosition = obj.transform.FindChild("Image/mari").GetComponent<RectTransform>();
    _nanaPosition = obj.transform.FindChild("Image/nana").GetComponent<RectTransform>();
    _imageMari = obj.transform.FindChild("Image/mari").GetComponent<Image>();
    _imageNana = obj.transform.FindChild("Image/nana").GetComponent<Image>();
    _selectCanvas = Resources.Load<GameObject>("Adventure/SelectCanvas");
    _button = Resources.Load<Button>("Adventure/Button");
    _nextIcon = obj.transform.FindChild("nextIcon").GetComponent<Image>();
  }

  void Start() {
    Debug.Log(_cashInt);
    Definition();
    _imageMari.enabled = false;
    _imageNana.enabled = false;
    FirstReadAct(_reading);
    _isChoices = false;
    _isLineEnd = false;
    _nextIcon.enabled = _isLineEnd;
  }

  void FirstReadAct(string[,] date) {
    for (int i = 0; i < date.Length / 4; ++i) {
      if (date[i, 0] == Command.act) {
        eventSystem._act.Add(date[i, 1], i);
        Debug.Log(i + " : " + date[i, 1].ToString());
      }
    }
  }

  /// <summary>
  /// 以下、実際の動き？の部分
  /// </summary>

  void Update() {
    _nextIcon.transform.localPosition = new Vector3(690f, -380 + (MovedIcon(_count) * 20f));
    _count += 2f * Time.deltaTime;
    _nextIcon.enabled = _isLineEnd;
    if (_isChoices) {
      _isChoices = false;
      Destroy(_select);
      _select = null;
    }
    if (!_isEndStory &&
        _reading != null &&
        _msgCur <= _reading.Length / 4) {
      /// ストーリーが続いている処理
      ReadingStory(_reading);
    }
  }

  void ReadingStory(string[,] cur) {
    Debug.Log(_msgCur + " : " + cur[_msgCur, 1].ToString());

    if (cur[_msgCur, 0] == Command.start) { ReadStart(); }

    else if (cur[_msgCur, 0] == Command.end) { ReadEnd(); }

    else if (cur[_msgCur, 0] == Command.name) { ReadName(cur[_msgCur, 1]); }

    else if (cur[_msgCur, 0] == Command.image) { ReadImage(cur[_msgCur, 1], cur[_msgCur, 2], cur[_msgCur, 3]); }

    else if (cur[_msgCur, 0] == Command.jump) { ReadJump(cur[_msgCur, 1], cur[_msgCur, 2], cur[_msgCur, 3]); }

    else if (cur[_msgCur, 0] == Command.text) { ReadText(cur[_msgCur, 1]); }

    else if (cur[_msgCur, 0] == Command.act) { ReadAct(); }

    else if (cur[_msgCur, 0] == Command.cashi) { _cashInt = ReadCashi(cur[_msgCur, 1]); _msgCur++; }

    else if (cur[_msgCur, 0] == Command.cashf) { _cashFloat = ReadCashf(cur[_msgCur, 1]); _msgCur++; }

    else if (cur[_msgCur, 0] == Command.cashb) { _cashBool = ReadCashb(cur[_msgCur, 1]); _msgCur++; }

    else { _msgCur++; } // 変なもの来たら強制スキップ
  }

  void ReadStart() {
    _nameText.text = "";
    _msgText.text = "";
    _imageMari.enabled = false;
    _imageNana.enabled = false;
    _msgCur++;
  }

  void ReadEnd() {
    eventSystem._act.Clear();
    Destroy(gameObject);
  }

  void ReadAct() {
    _nameText.text = "";
    _msgText.text = "";
    _imageMari.enabled = false;
    _imageNana.enabled = false;
    _msgCur++;
  }

  void ReadText(string str) {
    _msgText.text = str.Substring(0, _msgRow);
    if (_msgRow < str.Length) { _msgRow++; _isLineEnd = false; }
    if (_msgRow == str.Length) { _isLineEnd = true; }
    if (TouchController.IsTouchEnded()) { _msgRow = str.Length; _isLineEnd = true; }
    if (_msgRow == str.Length && TouchController.IsTouchEnded()) { _msgCur++; _msgRow = 0; _isLineEnd = false; }
  }

  void ReadName(string str) {
    _nameText.text = str;
    _msgCur++;
  }

  void ReadImage(string name, string image, string pos) {
    _msgCur++;
    if (name == CharaName.mari || name == "mari") {
      if (image == ImageName.REMOVE) {
        _imageMari.enabled = false;
      }
      else {
        _imageMari.enabled = true;
        _imageMari.sprite = eventSystem._images[image];
        CharaPosition(_mariPosition, pos);
      }
    }
    else if (name == CharaName.nana || name == "nana") {
      if (image == ImageName.REMOVE) {
        _imageNana.enabled = false;
      }
      else {
        _imageNana.enabled = true;
        _imageNana.sprite = eventSystem._images[image];
        CharaPosition(_nanaPosition, pos);
      }
    }
    else { Debug.Log("Who is " + name + "?"); }
  }

  void ReadJump(string target1, string target2, string target3) {
    if (_select == null) {
      _select = Instantiate(_selectCanvas);
      ViewButton(target1, new Vector3(0f, 200f));
      ViewButton(target2, new Vector3(0f, -0f));
      ViewButton(target3, new Vector3(0f, -200f));
    }
  }

  int ReadCashi(string str) {
    _cashInt = 0;
    var i = int.Parse(str);
    return i;
  }

  float ReadCashf(string str) {
    _cashFloat = 0f;
    var f = float.Parse(str);
    return f;
  }

  bool ReadCashb(string str) {
    var b = bool.Parse(str);
    return b;
  }

  void ViewButton(string target, Vector3 pos) {
    if (target.Length > 2) {
      string[] str = target.Split('(');
      string goTo = str[1].Replace(")", "");
      Debug.Log(goTo);
      Create(str[0], goTo, pos, _select);
    }
  }

  Button Create(string name, string fork, Vector3 pos, GameObject parent) {
    var b = Instantiate(_button);
    b.name = name;
    b.transform.SetParent(parent.transform);
    var set = b.gameObject.GetComponentInChildren<RectTransform>();
    set.localPosition = pos;
    set.localScale = new Vector3(1f, 1f, 1f);
    var script = b.GetComponentInChildren<SelectButton>();
    script._actName = name;
    script._goTo = fork;
    return b;
  }

  void CharaPosition(RectTransform rt, string pos) {
    Vector3 scale = Vector3.zero;
    Vector3 position = Vector3.zero;
    if (pos == ImagePosition.center) {
      scale = new Vector3(1f, 1f, 1f);
      position = new Vector3(0f, -120f);
    }
    else if (pos == ImagePosition.right) {
      scale = new Vector3(1f, 1f, 1f);
      position = new Vector3(320f, -120f);
    }
    else if (pos == ImagePosition.left) {
      scale = new Vector3(-1f, 1f, 1f);
      position = new Vector3(-320f, -120f);
    }
    rt.localPosition = position;
    rt.localScale = scale;
  }

  float MovedIcon(float count) {
    var sin = Mathf.Abs(Mathf.Sin(count));
    return sin;
  }
}
