using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PopUpCanvas : SingletonBehaviour<PopUpCanvas> {

    /// <summary>
    /// 読み込むスクリプト
    /// </summary>
    SceneSequencer sceneSequencer { get { return SceneSequencer.instance; } }
    EffectSequencer effectSequencer { get { return EffectSequencer.instance; } }
    ManholeScript _manhole;

    /// <summary>
    /// ウィンドウの設定
    /// </summary>
    private bool _isChoice;
    private bool _isEffect;
    private GameObject _popupWindow;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private Text _text;
    private Button _yes;
    private Button _no;

    /// <summary>
    ///  いろいろな名前を記憶するためになくなく必要になった
    /// </summary>
    public string _str;
    public float _count;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        _isChoice = false;
        _isEffect = false;
    }

    void Update()
    {
        if (_count > 0) _count -= 1 * Time.deltaTime;
        if (_isChoice && _count<=0) { FadeDestroy(1.5f); }
        if (_isEffect) {
            effectSequencer.FadeStart(ManholeJump, 0.5f);
        }
    }

    void FadeDestroy(float time)
    {
        /// <summary>
        /// 表示しているキャンバスをフェードアウトさせ
        /// それを消滅させる関数です
        /// </summary>
        if (_canvasGroup != null)
        {
            _canvasGroup.interactable = false;
            var view = (_canvasGroup.alpha < 0.7f) ? time * 2 : time;
            _canvasGroup.alpha -= view * Time.deltaTime;
            if (_canvasGroup.alpha == 0) Destroy(_canvas.gameObject);
        }
    }

    public void CreatePopUpWindowVerGimmick(string str, UnityAction yes)
    {
        if (_canvasGroup == null)
        {
            _isChoice = false;
            _popupWindow = Resources.Load<GameObject>("GimmickPopUpWindow");
            var canvas = Instantiate(_popupWindow);
            canvas.name = "PopUpWindow";
            _canvas = GameObject.Find(canvas.name).GetComponent<Canvas>();
            _canvasGroup = _canvas.GetComponent<CanvasGroup>();
            _text = _canvas.transform.FindChild("MsgWindow").GetComponent<Text>();
            _yes = _canvas.transform.FindChild("Yes").gameObject.GetComponent<Button>();
            _no = _canvas.transform.FindChild("No").gameObject.GetComponent<Button>();
            _text.text = str;
            _no.onClick.AddListener(IsCancel);
            _yes.onClick.AddListener(yes);
        }
        else return;
    }

    public void CreatePopUpWindowVerItem(string str)
    {
        if (_canvasGroup == null)
        {
            _isChoice = false;
            _popupWindow = Resources.Load<GameObject>("ItemPopUpWindow");
            var canvas = Instantiate(_popupWindow);
            canvas.name = "PopUpWindow";
            _canvas = GameObject.Find(canvas.name).GetComponent<Canvas>();
            _canvasGroup = _canvas.GetComponent<CanvasGroup>();
            var image = _canvas.GetComponentInChildren<Image>();
            _text = image.transform.FindChild("MsgText").GetComponent<Text>();
            _text.text = str + "を手に入れました";
        }
        else return;
    }

    public void CreatePopUpWindow(string str)
    {
        if (_canvasGroup == null)
        {
            _isChoice = false;
            _popupWindow = Resources.Load<GameObject>("ItemPopUpWindow");
            var canvas = Instantiate(_popupWindow);
            canvas.name = "PopUpWindow";
            _canvas = GameObject.Find(canvas.name).GetComponent<Canvas>();
            _canvasGroup = _canvas.GetComponent<CanvasGroup>();
            var image = _canvas.GetComponentInChildren<Image>();
            _text = image.transform.FindChild("MsgText").GetComponent<Text>();
            _text.text = str;
        }
        else return;
    }


    /// 
    /// 引数なしのもの
    ///
    public void ManholeJump()
    {
        _manhole = GameObject.FindObjectOfType<ManholeScript>();
        _manhole.IsDestination(_str);
        _isEffect = false;
    }

    /// 
    /// 以下にボタン用のスクリプトを書く
    /// 必ず「 public void 関数名(){} 」とかくこと。エラー起こすから
    /// 引数を設けたい場合はこのクラスにstringとか新しく設けて、そこを経由させる…つら
    /// 

    public void IsCancel()
    {
        /// ウィンドウを消す
        _isChoice = true;
    }

    public void IsFloorMove()
    {
        _manhole = GameObject.FindObjectOfType<ManholeScript>();
        _isChoice = true;
        _manhole.MoveFloor();
    }

    public void IsWarpMari()
    {
        _isChoice = true;
        _isEffect = true;
    }

    public void IsEnd()
    {
        _isChoice = true;
        sceneSequencer.SceneFinish(SceneTag.shrine);
    }
}

