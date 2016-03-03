namespace SiscosHooks
{
    /// <summary>
    /// List of available hooks.
    /// </summary>
    public enum HOOK_ID
    {
        /// <summary>
        /// DONT USE THIS, IT'S A PLACEHOLDER AND WON'T DO ANYTHING!
        /// </summary>
        NONE = 0,
        /// <summary>
        /// Called at the beginning of the VakPak's update function.
        /// <para> Class: WeaponVacuum </para>
        /// </summary>
        VacPak_Think,
        /// <summary>
        /// preEntitySpawn(int n, Randoms r) : Called BEFORE the spawner starts looping to spawn %n entitys
        /// <para> Class: DirectedActorSpawner </para>
        /// </summary>
        PreEntitySpawn,
        /// <summary>
        /// You can change the default spawn ratios here. Look at 'sender.cell' which is a CellDirector type.
        /// <para> Class: DirectedActorSpawner </para>
        /// </summary>
        EntitySpawner_Init,
        /// <summary>
        /// Beginning of the economy's init. Modify the senders baseValueMap var to change item base values.
        /// <para> Class: EconomyDirector </para>
        /// </summary>
        EconomyInit,
        /// <summary>
        /// Fires whenever we need to alter the stats on something because the player is spawning
        /// <para> Class: PlayerState </para>
        /// <paramref name="UpgradeFlag"/>
        /// </summary>
        Player_ApplyUpgrade,
        /// <summary>
        /// Set return value
        /// <para> Class: PlayerState </para>
        /// <paramref name="UpgradeFlag"/>
        /// </summary>
        Player_CanGetUpgrade,
        /// <summary>
        /// Fires whenever the player takes damage, make the sender return true to kill the player
        /// <para> Class: PlayerState </para>
        /// <param name="Damage">(int) The amount of damage to be taken.</param>
        /// </summary>
        Player_Damaged,
        /// <summary>
        /// Fires whenever the player should loose energy.
        /// <para> Class: PlayerState </para>
        /// <param name="energy">(float) The amount of energy to lose.</param>
        /// </summary>
        Player_LoseEnergy,
        /// <summary>
        /// Fires whenever the players energy value is being  altered.
        /// <para> Class: PlayerState </para>
        /// <param name="energy">(int) The amount of energy to set to.</param>
        /// </summary>
        Player_SetEnergy,
        /// <summary>
        /// Called to check if an entity can be sucked up by the VacPak.
        /// <para> Class: Vacuumable </para>
        /// </summary>
        Vac_Can_Capture,
        /// <summary>
        /// Called to perform capture logic on an entity, an entity is 'captured' when sucked into the VacPak
        /// <para> Class: Vacuumable </para>
        /// </summary>
        Vac_Capture,
        /// <summary>
        /// 
        /// <para> Class: CellDirector </para>
        /// </summary>
        CellDirector_Pre_Update,
        /// <summary>
        /// 
        /// <para> Class: CellDirector </para>
        /// </summary>
        CellDirector_Post_Update
    }

}