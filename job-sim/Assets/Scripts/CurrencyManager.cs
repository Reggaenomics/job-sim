using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [Tooltip("Drag your MoneyText TMP UI element here")]
    public TextMeshProUGUI moneyText;

    public int Money { get; private set; }

    void Awake()
    {
        // Singleton pattern setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Load saved money (0 default)
            Money = PlayerPrefs.GetInt("PlayerMoney", 0);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        UpdateUI();
    }

    /// <summary> Adds (or subtracts) currency and updates UI + saves </summary>
    public void AddMoney(int amount)
    {
        Money += amount;
        if (Money < 0)
            Money = 0;

        UpdateUI();
        PlayerPrefs.SetInt("PlayerMoney", Money);
    }

    void UpdateUI()
    {
        // Display as: Money: $100
        moneyText.text = $"Money: ${Money}";
    }
}
