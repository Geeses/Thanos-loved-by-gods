using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour {


    public Character enemy;
    //public List<Attack_ScriptableObject> AO;
    public Attack_ScriptableObject StoneAO;
    public Attack_ScriptableObject ThunderAO;
    public Attack_ScriptableObject TornadoAO;
    public Slider DamageSlider;
    public Slider SpeedSlider;
    public Slider HealthSlider;
    public Slider JumpSlider;
    public Slider AttackSpeedSlider;
    public Slider StoneCDSlider;
    public Slider ThunderCDSlider;
    public Slider TornadoCDSlider;
    public Slider StoneAttSlider;
    public Slider ThunderAttSlider;
    public Slider TornadoAttSlider;

    public Text Value01;
    public Text Value02;
    public Text Value03;
    public Text Value04;
    public Text Value05;
    public Text Value06;

    private void Update()
    {
        if (StoneAO || ThunderAO || TornadoAO)
        {
            if (Value01) Value01.text = StoneCDSlider.value.ToString();
            if (Value02) Value02.text = ThunderCDSlider.value.ToString();
            if (Value03) Value03.text = TornadoCDSlider.value.ToString();
            if (Value04) Value04.text = StoneAttSlider.value.ToString();
            if (Value05) Value05.text = ThunderAttSlider.value.ToString();
            if (Value06) Value06.text = TornadoAttSlider.value.ToString();
        }
        else
        {

            if (Value01) Value01.text = HealthSlider.value.ToString();
            if (Value02) Value02.text = SpeedSlider.value.ToString();
            if (Value03) Value03.text = JumpSlider.value.ToString();
            if (Value04) Value04.text = DamageSlider.value.ToString();
            if (Value05) Value05.text = AttackSpeedSlider.value.ToString();
            
        }
    }

    private void Start()
    {
        if (StoneAO || ThunderAO || TornadoAO)
        {
            if (TornadoCDSlider)    TornadoCDSlider.value   = TornadoAO.CooldownTime;
            if (ThunderCDSlider)    ThunderCDSlider.value   = ThunderAO.CooldownTime;
            if (StoneCDSlider)      StoneCDSlider.value     = StoneAO.CooldownTime;
            if (TornadoAttSlider)   TornadoAttSlider.value  = TornadoAO.Damage;
            if (ThunderAttSlider)   ThunderAttSlider.value  = ThunderAO.Damage;
            if (StoneAttSlider)     StoneAttSlider.value    = StoneAO.Damage;

        }
        else
        {
            if (AttackSpeedSlider) AttackSpeedSlider.value = enemy.DefaultAttackSpeed;
            if (DamageSlider) DamageSlider.value = enemy.DefaultAttackDamage;
            if (SpeedSlider) SpeedSlider.value = enemy.DefaultMovementSpeed;
            if (HealthSlider) HealthSlider.value = enemy.DefaultHealth;
            if (JumpSlider) JumpSlider.value = enemy.DefaultJumpPower;
        }
    }

    public void DefaultSettings()
    {
        enemy.attackDamage = enemy.DefaultAttackDamage;
        if (DamageSlider) DamageSlider.value = enemy.DefaultAttackDamage;
        enemy.movementSpeed = enemy.DefaultMovementSpeed;
        if (SpeedSlider) SpeedSlider.value = enemy.DefaultMovementSpeed;
        enemy.health = enemy.DefaultHealth;
        if (HealthSlider) HealthSlider.value = enemy.DefaultHealth;
        enemy.jumpPower = enemy.DefaultJumpPower;
        if (JumpSlider) JumpSlider.value = enemy.DefaultJumpPower;
        enemy.attackSpeed = enemy.DefaultAttackSpeed;
        if (AttackSpeedSlider) AttackSpeedSlider.value = enemy.DefaultAttackSpeed;
    }

    public void SetDamage()
    {
        if(DamageSlider)
        enemy.attackDamage = DamageSlider.value;
    }

    public void SetSpeed()
    {
        if(SpeedSlider)
        enemy.movementSpeed = SpeedSlider.value;
    }
    public void SetJump()
    {
        if(JumpSlider)
        enemy.jumpPower = JumpSlider.value;
    }
    public void SetHealth()
    {
        if(HealthSlider)
        enemy.health = HealthSlider.value;
    }

    public void SetAttackSpeed()
    {
        if (AttackSpeedSlider)
        enemy.attackSpeed = AttackSpeedSlider.value;
    }

    public void SetStoneCD()
    {
        if (StoneCDSlider)
            StoneAO.CooldownTime = StoneCDSlider.value;
    }

    public void SetThunderCD()
    {
        if (ThunderCDSlider)
            ThunderAO.CooldownTime = ThunderCDSlider.value;
    }

    public void SetTornadoCD()
    {
        if (TornadoCDSlider)
            TornadoAO.CooldownTime = TornadoCDSlider.value;
    }

    public void SetStoneDMG()
    {
        if (StoneAttSlider)
            StoneAO.Damage = StoneAttSlider.value;
    }

    public void SetThunderDMG()
    {
        if (ThunderAttSlider)
            ThunderAO.Damage = ThunderAttSlider.value;
    }

    public void SetTornadoDMG()
    {
        if (TornadoAttSlider)
            TornadoAO.Damage = TornadoAttSlider.value;
    }

    public void SaveChanges()
    {
        enemy.SaveChanges();
    }
}
