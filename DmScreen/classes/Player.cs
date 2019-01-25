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
    public class Player
    {
    #region public enums
        public enum CombatActions {Movement, Action, BonusAction, Reaction, Condition}
        public enum BattleCondition {Unharmed, Hurt, Injured, Bloodied, NearDeath, Dead}
        public enum StatusEffect { None, Blinded, Charmed, Deafened, Fatigued, Frightened, Grappled, Incapacitated, Invisible, Paralyzed, Petrified, Poisoned, Prone, Restrained, Stunned, Unconcious}
    #endregion

    #region public properties
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int ExhaustionLevel { get; set; }
        public StatusEffect CurrentStatus { get; set; }
        // MAKE A VARIABLE TO STORE THE PLAYER'S IMAGE??

        public int DeathSaveSuccesses { get; set; }
        public int DeathSaveFailures { get; set; }

        public int Xpos { get; set; }
        public int Ypos { get; set; }
    #endregion
    }
}
