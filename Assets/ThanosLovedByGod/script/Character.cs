using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName ="Character Asset")]

public class Character : ScriptableObject {

    public new string name;
    public int level;
    public float health;
    public float attackDamage;
    public float attackSpeed;
    public float movementSpeed;
    public float CooldownTime;
    public float jumpPower;
    public float knockback;
    public float stamina;

    public float DefaultHealth;
    public float DefaultAttackDamage;
    public float DefaultAttackSpeed;
    public float DefaultMovementSpeed;
    public float DefaultDamageDelayTime;
    public float DefaultJumpPower;
    public float DefaultStamina;

    public void SaveChanges()
    {
        DefaultAttackDamage = attackDamage;
        DefaultAttackSpeed = attackSpeed;
        DefaultMovementSpeed = movementSpeed;
        DefaultJumpPower = jumpPower;
        DefaultHealth = health;
    }
}
