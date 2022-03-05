using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// code from https://medium.com/swlh/game-dev-how-to-make-health-bars-in-unity-from-beginner-to-advanced-9a1d728d0cbf, by C. James

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBarImage;
    public Fighter fighter;

    public void UpdateHealthBar() {
        healthBarImage.fillAmount = Mathf.Clamp((float)fighter.currentHp / (float)fighter.maxHp, 0, 1f);
        Debug.Log(healthBarImage.fillAmount);
    }
}
