using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerUI : MonoBehaviour
    {
    
        [HideInInspector] public int shieldsCollected;

        [Header("Health")] public Image healthBar;
        public List<Image> shields;
    
        [Header("Buffs")] public Image dashBuff;
        public Image jumpBuff;
        public Image speedBuff;
        private void Update()
        {
            PlayerHealth health = PlayerEntity.Instance.Health;
            PlayerPowerUps powerUps = PlayerEntity.Instance.PowerUps;

            healthBar.fillAmount = health.currentHealth / (float) health.maxHealth;

            for (int i = 0; i < shields.Count; i++)
            {
                if (i < shieldsCollected)
                {
                    shields[i].gameObject.SetActive(true);
                }
                else
                {
                    shields[i].gameObject.SetActive(true);
                }
            }

            dashBuff.fillAmount = powerUps.dashTimeRemaining <= 0
                ? 0f
                : powerUps.dashTimeRemaining /  powerUps.maxDashTime;
            jumpBuff.fillAmount = powerUps.jumpBoostRemaining <= 0
                ? 0f
                : powerUps.jumpBoostRemaining / powerUps.maxJumpTime;
            speedBuff.fillAmount = powerUps.speedBoostRemaining <= 0
                ? 0f
                : powerUps.speedBoostRemaining / powerUps.maxSpeedTime;
        }


    }
}
