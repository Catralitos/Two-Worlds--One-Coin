using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boss;

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

        public Image bossHealthBar;

        private void Update()
        {
            PlayerHealth health = PlayerEntity.Instance.Health;
            PlayerPowerUps powerUps = PlayerEntity.Instance.PowerUps;
            GameObject boss = PlayerEntity.Instance.bossMan;
            BossEnemy bossScript = null;
            if (boss.activeSelf)
            {
                bossScript = boss.GetComponent<BossEnemy>();
            }


            healthBar.fillAmount = health.currentHealth / (float) health.maxHealth;
            bossHealthBar.fillAmount = bossScript != null ? bossScript.currentHealth / bossScript.maxHealth : 1;

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
                : powerUps.dashTimeRemaining / powerUps.maxDashTime;
            jumpBuff.fillAmount = powerUps.jumpBoostRemaining <= 0
                ? 0f
                : powerUps.jumpBoostRemaining / powerUps.maxJumpTime;
            speedBuff.fillAmount = powerUps.speedBoostRemaining <= 0
                ? 0f
                : powerUps.speedBoostRemaining / powerUps.maxSpeedTime;
        }
    }
}