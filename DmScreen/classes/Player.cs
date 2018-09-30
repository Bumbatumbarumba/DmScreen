using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreen.classes
{
    //
    // Used to create player objects that only contain info pertainent to DM
    // functions; for example, the DM doesn't keep track of the player's items,
    // but their HP is important.
    //
    class Player
    {
        enum CombatActions {Movement, Action, BonusAction, Reaction, Condition}
        enum BattleCondition {Unharmed, Hurt, Injured, Bloodied, NearDeath, Dead}

        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        // MAKE A VARIABLE TO STORE THE PLAYER'S IMAGE??

        public int DeathSaveSuccesses { get; set; }
        public int DeathSaveFailures { get; set; }

    }
}
