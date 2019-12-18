using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [SerializeField]
    private Button instructionButton;
    [SerializeField]
    private Text scoreText, endScoreText, highScoreText;
    [SerializeField]
    private GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _MakeInstance()
    {
        if( instance == null ) {
            instance = this;
        }
    }

    public void _InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void _SetScore(int score){
        scoreText.text = "" + score;
    }

    public void _SetEndScore(int score){
        endScoreText.text = "" + score;
    }

    public void _SetHighScoreText(int score){
        highScoreText.text = "" + score;
    }

    public void _ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

    public void _LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void _Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
