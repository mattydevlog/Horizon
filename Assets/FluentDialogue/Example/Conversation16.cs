using System;
using Fluent;
using UnityEngine;

/// <summary>
/// Here is a more complex example that has some of the FluentNodes generated by methods
/// </summary>
public class Conversation16 : MyFluentDialogue
{
    public int EnemyHealth = 10;
    public GameObject PlayerGameObject;
    bool stillFighting = true;

    public override void OnStart()
    {
        EnemyHealth = 10;
        stillFighting = true;
        base.OnStart();
    }

    void DoDamage(int damage)
    {
        EnemyHealth -= damage;
        if (EnemyHealth <= 0)
            stillFighting = false;
    }

    FluentNode AttackOption(string itemName, string yell, int damage)
    {
        return
            Option(itemName) *
            Hide() *
            Yell(PlayerGameObject, yell) *
            Yell("You delt " + damage + " damage") *
            Do(() => DoDamage(damage)) *
            Yell(Eval(() => EnemyHealth + " hp left")) *
            Show() *
            If(() => EnemyHealth <= 0,
                Hide() *
                Yell("I died!") *
                Yell("You win!")
            ) *
            End();
    }   

    FluentNode SpellList()
    {
        return
            Options
            (
                AttackOption("Magic Missile", "Missles away!", 4) *
                AttackOption("Fairy Fire", "Boom!", 2) *
                Option("Back") *
                    Back()
            );
    }

    public override FluentNode Create()
    {
        return
            Show() *
            While(() => stillFighting,
                Show() * 
                Options
                (
                    If(() => EnemyHealth >= 10, Write(0, "You will NEVER defeat me !!")) *
                    If(() => EnemyHealth >= 6 && EnemyHealth < 10, Write(0, "I'v been hurt!")) *
                    If(() => EnemyHealth >= 2 && EnemyHealth < 6, Write(0, "Awwwwwwww! Stop that!")) *

                    Option("Spells") *
                        Write(0, "Choose a spell") *
                        SpellList() *

                    AttackOption("Melee", "Hand 2 Hand!", 2) *                        

                    Option("Flee") *
                        Hide() *
                        Yell("Coward!") *
                        Do(() => stillFighting = false) *
                        End()
                )
            );
    }
}
