using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBunny : Fighter
{
    public override string Compliment()
    {
        // DO SOMETHING
        this.Damage(-2);
        return "'Who\'s a good dust bunny? You are! Yes you are!!.'\nDust Bunny thumps their leg on the ground joyfully, feeling a little healthier.";
    }

    public override string Insult()
    {
        this.turnsFrozen += 2;
        return "'It\'s hard to breath with you around! Get lost!'\nDust Bunny looks super depressed. They don\'t even wanna fight anymore.";
    }

    private void Awake()
    {
        // Toxic dust
        this.attack1execute = targets =>
        {
            string msg = "The bunny sends toxic dust your way.\n";
            foreach (Fighter f in targets)
            {
                AttackResult result = this.Hit(f, 2, "Dust");
                
                msg += result.msg + "\n";
                if (result.hit)
                {
                    f.poisonAttacks.Add(new PoisonAttack(2, 2));
                    msg += f.name + " is poisoned!\n";
                }
            }
            return msg;
        };

        // Dust cloud
        this.attack2execute = targets =>
        {
            string msg = "The bunny sends out a cloud of dust.\n";
            targets[0].Defense(-2, 3);
            msg += targets[0].name + "\'s defense is lowered by 2 for 3 turns.";
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
