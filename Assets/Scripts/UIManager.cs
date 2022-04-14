using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    TextMeshProUGUI killCounter_TMP;
    [HideInInspector]
    public int killCount;
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        Player.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateKillCounterUI()
    {
        killCounter_TMP.text = killCount.ToString();    // Päivittää tappolaskuria
    }

    public void RestartButton ()
    {   
        SceneManager.LoadScene("FirstLevel");
    }

    public void QuitButton ()
    {
        Application.Quit();
    }
}
