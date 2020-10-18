using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PutOnPulseBandScript : MonoBehaviour
{
    public Text p1NameText;
    public Text p2NameText;

    public Text p1BPMNumber;
    private Text _p1BPMNumber;
    public Text p2BPMNumber;
    private Text _p2BPMNumber;

    public Text p1BPMLabel;
    private Text _p1BPMLabel;
    public Text p2BPMLabel;
    private Text _p2BPMLabel;

    public Image p1HeartIcon;
    private Image _p1HeartIcon;
    public Image p2HeartIcon;
    private Image _p2HeartIcon;

    public Text p1ConnectedText;
    private Text _p1ConnectedText;
    public Text p2ConnectedText;
    private Text _p2ConnectedText;

    public void ClickedDoneButton()
    {
        if (GameState.P1Connected && GameState.P2Connected && GameState.P1HeartRate > 20 && GameState.P1HeartRate > 20)
        {
            SceneManager.LoadScene(sceneName: "HowTo1");
        }
        else
        { //TODO: Ta bort detta, testar bara med ett band just nu
            SceneManager.LoadScene(sceneName: "HowTo1");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        p1NameText.GetComponent<Text>().text = GameState.P1Name;
        p2NameText.GetComponent<Text>().text = GameState.P2Name;

        _p1BPMNumber = p1BPMNumber.GetComponent<Text>();
        _p2BPMNumber = p2BPMNumber.GetComponent<Text>();

        _p1BPMLabel = p1BPMLabel.GetComponent<Text>();
        _p2BPMLabel = p2BPMLabel.GetComponent<Text>();

        _p1HeartIcon = p1HeartIcon.GetComponent<Image>();
        _p2HeartIcon = p2HeartIcon.GetComponent<Image>();

        _p1ConnectedText = p1ConnectedText.GetComponent<Text>();
        _p2ConnectedText = p2ConnectedText.GetComponent<Text>();

        _p1Connected = GameState.P1Connected;
        _p2Connected = GameState.P2Connected;

        _p1HR = GameState.P1HeartRate;
        _p2HR = GameState.P2HeartRate;

        p1ConnectedChanges(_p1Connected);
        p2ConnectedChanges(_p2Connected);
    }

    private readonly string _connectedLabelText = "ANSLUTEN";
    private readonly string _disconnectedLabelText = "EJ ANSLUTEN";
    private readonly Color _connectedWhiteColor = Color.white;
    private readonly Color _connectedGreenColor = Color.green;
    private readonly Color _disconnectedRedColor = Color.red;
    private readonly Color _disconnectedGreyColor = new Color(112f/255f, 112f/255f, 112f/255f, 1f);

    private bool _p1Connected = false;
    private bool _p2Connected = false;

    private int _p1HR;
    private int _p2HR;

    private void p1ConnectedChanges(bool isConnected)
    {
        Debug.Log("p1 ConnectChanges called");
        _p1ConnectedText.color = isConnected ? _connectedGreenColor : _disconnectedRedColor;
        _p1ConnectedText.text = isConnected ? _connectedLabelText : _disconnectedLabelText;
        _p1HeartIcon.color = isConnected ? _connectedWhiteColor : _disconnectedGreyColor;
        _p1BPMLabel.color = isConnected ? _connectedWhiteColor : _disconnectedGreyColor;
        _p1BPMNumber.color = isConnected ? _connectedWhiteColor : _disconnectedGreyColor;
        _p1BPMNumber.text = isConnected ? GameState.P1HeartRate.ToString() : "0";
    }

    private void p2ConnectedChanges(bool isConnected)
    {
        Debug.Log("p2 ConnectChanges called");
        _p2ConnectedText.color = isConnected ? _connectedGreenColor : _disconnectedRedColor;
        _p2ConnectedText.text = isConnected ? _connectedLabelText : _disconnectedLabelText;
        _p2HeartIcon.color = isConnected ? _connectedWhiteColor : _disconnectedGreyColor;
        _p2BPMLabel.color = isConnected ? _connectedWhiteColor : _disconnectedGreyColor;
        _p2BPMNumber.color = isConnected ? _connectedWhiteColor : _disconnectedGreyColor;
        _p2BPMNumber.text = isConnected ? GameState.P1HeartRate.ToString() : "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.P1Connected != _p1Connected)
        {
            _p1Connected = GameState.P1Connected;
            p1ConnectedChanges(_p1Connected);
        }
        if (GameState.P2Connected != _p2Connected)
        {
            _p2Connected = GameState.P2Connected;
            p2ConnectedChanges(_p2Connected);
        }
        if (GameState.P1HeartRate != _p1HR)
        {
            _p1HR = GameState.P1HeartRate;
            _p1BPMNumber.text = _p1HR.ToString();
        }
        if (GameState.P2HeartRate != _p2HR)
        {
            _p2HR = GameState.P2HeartRate;
            _p2BPMNumber.text = _p2HR.ToString();
        }
    }
}
