using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public void Update()
    {
        if (!_menuCanvas)
        {
            MeterUp();
            KotodamaView();
            GetItem();
        }
    }

    // コトダマメーター関連
    public Button MeterButton;
    public Image MeterImage;
    public float _meterUpSpeed = 0.01f;

    // メニューボタン関連
    public Button MenuButton;
    public bool _menuCanvas = false;
    public Canvas menucanvas;

    // コトダマ出現関連
    private GameObject Kotodama01;
    public float _KOTODAMA_ACTIVE_TIME = 50.0f;
    private float  _kotodamaActiveTime;
    public float _kotodamaView = 1.0f;

    // ポップアイコン関連
    private GameObject NoticeWindow;
    public Text NoticeMsgText;
    private string _NoticeMessage = "鍵を入手しました。";
    public bool _itemGet = false;

    public void Start()
    {
        Kotodama01 = GameObject.Find("Kotodama1");
        Kotodama01.SetActive(false);
        _kotodamaActiveTime = _KOTODAMA_ACTIVE_TIME;
        NoticeWindow = GameObject.Find("NoticeWindow");
        NoticeWindow.SetActive(_itemGet);
    }

    public void MeterUp()
    {
        MeterButton.interactable = !_menuCanvas;

        MeterImage.fillAmount += _meterUpSpeed * Time.deltaTime;

        if (MeterImage.fillAmount.Equals(1.0f))
        {
            MeterImage.color = new Color(1f, 1f, 1f);
            MeterButton.interactable = true;
        }
        else
        {
            MeterImage.color = new Color(0.1f, 0.1f, 0.1f, 0.5f);
            MeterButton.interactable = false;
        }
    }

    public void KotodamaView()
    {
        if (_kotodamaActiveTime < 0)
        {
            Kotodama01.SetActive(false);
            _kotodamaActiveTime = _KOTODAMA_ACTIVE_TIME;
        }

        if (Kotodama01.activeInHierarchy)
        { _kotodamaActiveTime -= _kotodamaView * Time.deltaTime; }
        Debug.Log("コトダマメーター１　:　" + _kotodamaActiveTime);
    }


    public void OnMeter()
    {
        Debug.Log("メーターボタンが押されました！！！！");
        MeterButton.interactable = !MeterButton.interactable;
        MeterImage.fillAmount = 0.0f;
        Kotodama01.SetActive(true);
        _kotodamaActiveTime = _KOTODAMA_ACTIVE_TIME;
    }

    public void OnMenu()
    {
        MeterButton.interactable = false;
        _menuCanvas = !_menuCanvas; 
        menucanvas.enabled = _menuCanvas;
    }

    public void GetItem()
    {
            NoticeMsgText.text = _NoticeMessage;
            NoticeWindow.SetActive(_itemGet);
    }



}
