using UnityEngine;
using TMPro;

public class CountBullet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float count;

    private ShootingHandiler sh;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        sh = FindAnyObjectByType<ShootingHandiler>().GetComponent<ShootingHandiler>();

        count = sh.currentBullet;
    }
    private void Update()
    {
        count = sh.currentBullet;
        text.text = count.ToString();
    }
}
