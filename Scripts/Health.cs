using Godot;
using System;
using EventCallback;
public class Health : Node
{
    int health = 5;

    public override void _Ready()
    {
        //The listener for the hit event
        HitEvent.RegisterListener(OnHitEvent);
    }

    private void OnHitEvent(HitEvent he)
    {
        if (he.target.GetInstanceId() == GetParent().GetInstanceId())
        {
            CalculateDamage();
        }
    }
    private void CalculateDamage()
    {
        //The calculated damage the actor will recive
        int calculatedDamage;

//Get attacker damage

//Get target defence

        //Get stats
        TakeDamage();
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        //If there is no more health
        if (health <= 0)
        {
            DeathEvent de = new DeathEvent();
            de.callerClass = "Health - TakeDamage";
            de.targetID = GetParent().GetInstanceId();
            de.FireEvent();
        }
    }

}
