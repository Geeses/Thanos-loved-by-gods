using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class Attack_ScriptableObject : ScriptableObject {


    public string AttackMethodName;
    public Sprite AttackSprite;
    public float CooldownTime;
    public float Damage;
    public float DelayTilDamage;
    public bool loadable;
    public float maxLoadTime;
    public bool achieved;
    public float AchievementLevel;
    public float knockback;
    public float StaminaUsage;
}
