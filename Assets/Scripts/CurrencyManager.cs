using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI Blood;

    int hp = 0;
    int blood = 0;

    void Awake()
    {
        CurrencyManager.instance = this;
    }
    
    void Start()
    {
        HP.text = "HP:" + hp.ToString();
        Blood.text = "Blood:" + blood.ToString();
    }

    public void SpillBlood()
    {
        blood += 10;
        Blood.text = "Blood:" + blood.ToString();
    }
}
