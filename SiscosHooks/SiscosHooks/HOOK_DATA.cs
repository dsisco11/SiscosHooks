﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SiscosHooks
{
    /*
    THIS IS FOR INTERNAL USE BY THE LIBRARY ONLY
    I WILL NOT BE DOCUMENTING THIS AREA
    */

    public class InjectionSite
    {
        public HOOK_ID hook = HOOK_ID.NONE;
        public int id { get { return (int)hook; } set { this.hook = (HOOK_ID)value; } }
        public string method = null;
        public int offset = 0;

        public InjectionSite()
        {
        }
    }

    public static class Injects
    {
        public static InjectionSite[] HooksList = new InjectionSite[] {
            new InjectionSite() { hook = HOOK_ID.Player_CanGetUpgrade, method = "PlayerState.CanGetUpgrade", offset=-1 },
            new InjectionSite() { hook = HOOK_ID.Player_ApplyUpgrade, method="PlayerState.ApplyUpgrade", offset=-1 },
            new InjectionSite() { hook = HOOK_ID.Player_Damaged, method = "PlayerState.Damage" },
            new InjectionSite() { hook = HOOK_ID.Vac_Can_Capture, method = "Vacuumable.canCapture" },
            new InjectionSite() { hook = HOOK_ID.Vac_Capture, method = "Vacuumable.capture" },
            new InjectionSite() { hook = HOOK_ID.VacPak_Think, method = "WeaponVacuum.Update" },
            new InjectionSite() { hook = HOOK_ID.PreEntitySpawn, method = "DirectedActorSpawner.Spawn" },
            new InjectionSite() { hook = HOOK_ID.EntitySpawner_Init, method = "DirectedActorSpawner.Start" },
            new InjectionSite() { hook = HOOK_ID.EconomyInit, method = "EconomyDirector.InitForLevel" },
            new InjectionSite() { hook = HOOK_ID.Player_LoseEnergy, method = "PlayerState.SpendEnergy" },
            new InjectionSite() { hook = HOOK_ID.Player_SetEnergy, method = "PlayerState.SetEnergy" },
            new InjectionSite() { hook = HOOK_ID.CellDirector_Pre_Update, method = "CellDirector.Update", offset = 0 },
            new InjectionSite() { hook = HOOK_ID.CellDirector_Post_Update, method = "CellDirector.Update", offset = -1 },
            new InjectionSite() { hook = HOOK_ID.Get_Available_Saves, method = "GameData.AvailableGames", offset = 0 },
            new InjectionSite() { hook = HOOK_ID.Get_Save_Directory, method = "GameData.ToPath", offset = 0 }
        };
    }
}
