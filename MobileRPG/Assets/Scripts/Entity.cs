using UnityEngine;
using System.Collections;

public class Entity : ScriptableObject
{
    public string entityName;
    public int age;

    protected string faction;

    public string occupation;
    public int level = 1;
    public int health = 2;
    public int strength = 1;
    public int magic = 0;
    public int defense = 0;
    public int speed = 1;
    public int damage = 1;
    public int armor = 0;
    public int numOfAttacks = 1;
    public string weapon;
    public Vector2 position;

    public void TakeDamage(int amount)
    {
        // Damage taken = amount - armor
        health -= Mathf.Clamp((amount - armor), 0, int.MaxValue);
    }

    public void Attack(Entity entity)
    {
        entity.TakeDamage(damage);
    }
}
