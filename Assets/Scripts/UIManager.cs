using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton class: UIManager

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [Header("Level Progess UI")]
    [SerializeField] public int sceneOffset;
    [SerializeField] public TMP_Text nextLevelText;
    [SerializeField] public TMP_Text currentLevelText;
    [SerializeField] public Image progressFillImage;

    [Space]
    [SerializeField] public TMP_Text levelCompletedText;

    [Space]
    [SerializeField] public Image fadePanel;


    public void Start()
    {
        FadeAtStart();
        progressFillImage.fillAmount = 0f;
        SetLevelProgressText();
    }

    public void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
    }


    public void UpdateLevelProgress()
    {
        float val = 1f - ((float)Level.Instance.objectsInScene / Level.Instance.totalObjects);
        progressFillImage.DOFillAmount(val, .4f);
    }


    public void ShowLevelCompleteUi()
    {
        levelCompletedText.DOFade(1f, .6f).From(0f);
    }

    public void FadeAtStart()
    {
        fadePanel.DOFade(0f, 1.3f).From(1f);
    }

}
