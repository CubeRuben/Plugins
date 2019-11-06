using Smod2;
using Smod2.API;

using System.Collections.Generic;
using System;

namespace PPlugin
{


    public class Round
    {
        public VoteOfRoundType[] vote = { new VoteOfRoundType(), new VoteOfRoundType(), new VoteOfRoundType(), new VoteOfRoundType() };

        public bool eventEnabled = false, playing = false, ended = false;

        public RoundType type = RoundType.STANDART_ROUND;

        public List<int> votedPlayers = new List<int>();

        public readonly string[] TypesNames = new[] {
            "Обычный раунд",
            "Заражение SCP-173",
            "Заражение SCP-106",
            "Заражение SCP-049-2",
            "Заражение SCP-939",
            "Тюрьма",
            "Королевская битва",
            "МТФ против Хаоса",
            "Заложники",
            "Бомбардировка"
        };

        public void Clear() 
        {
            vote[0].count = 0;
            vote[1].count = 0;
            vote[2].count = 0;
            vote[3].count = 0;
            votedPlayers.Clear();
            type = RoundType.STANDART_ROUND;
        }
    }
    public enum RoundType
    {
        STANDART_ROUND = 0,
        INFECTION_173 = 1,
        INFECTION_106 = 2,
        INFECTION_049_2 = 3,
        INFECTION_939 = 4,
        JAIL = 5,
        BATTLE_ROYALE = 6,
        MTF_VS_CHAOS = 7,
        HOSTAGES = 8,
        BOMBARDMENT = 9
    }

    public class Func
    {
        public static bool RotVec(Vector a, Vector b)
        {
            if ((Convert.ToInt32(a.x) == Convert.ToInt32(b.x)) && (Convert.ToInt32(a.y) == Convert.ToInt32(b.y)) && (Convert.ToInt32(a.z) == Convert.ToInt32(b.z)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClearAmmo(Player player)
        {
            player.SetAmmo(AmmoType.DROPPED_5, 0);
            player.SetAmmo(AmmoType.DROPPED_7, 0);
            player.SetAmmo(AmmoType.DROPPED_9, 0);
        }
    }

    public class TeamKillPlayer
    {
        public int id = 0, count = 0;
    }

    namespace Rooms
    {
        public class ItemSpawn
        {
            public bool SCP_914 = true, CHECKPOINT_A = true, CHECKPOINT_B = true, WC00 = true, HCZ_ARMORY = true, LCZ_ARMORY = true, PC_LARGE = true, T_INTERSECTION = true, X_INTERSECTION = true, SCP_012 = true, SCP_106 = true;
        }

        public class Camera
        {
            public bool LCZ_X = true, HCZ_X = true, ENTRANCE_X = true, SCP_914 = true, PC_LARGE = true, WC00 = true, AIRLOCK_00 = true, CLASS_D_CELLS = true, SCP_372 = true;
        }

        public class RagdollSpawn
        {
            public bool SCP_173 = true, SCP_096 = true, SCP_939 = true, SCP_012 = true, TESLA_GATE = true;
        }
    }

    public class VoteOfRoundType
    {
        public int count = 0;
        public RoundType roundType = RoundType.STANDART_ROUND;
    }

    public class WinnersId
    {
        public string BOMBARDMENT = "", BATTLE_ROYALE = "";
    } 
}
