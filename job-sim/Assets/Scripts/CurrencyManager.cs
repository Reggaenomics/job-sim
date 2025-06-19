using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [Header("UI Elements")]
    public TextMeshProUGUI moneyText;            // your regular corner UI
    public TextMeshProUGUI dialogueMoneyText;    // the new green text

    public int Money { get; private set; }

    const string MoneyKey = "PlayerMoney";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Money = PlayerPrefs.GetInt(MoneyKey, 0);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start() => UpdateUI();

    public void AddMoney(int amount)
    {
        Money = Mathf.Max(0, Money + amount);
        PlayerPrefs.SetInt(MoneyKey, Money);
        UpdateUI();
    }

    void UpdateUI()
    {
        string txt = $"Money: ${Money}";
        if (moneyText != null)
            moneyText.text = txt;

        if (dialogueMoneyText != null)
            dialogueMoneyText.text = txt;
    }
}