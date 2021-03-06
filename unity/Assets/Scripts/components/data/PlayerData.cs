using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.components.data
{
    public class PlayerData : MonoBehaviour
    {
        public string uid;
        public int Turn;
        public List<int> AckwowledgedPackages;
        public int fbId;
        public Color color;
        public int level;
        public int xp;
        public int currancy;
        public int hardCurrancy;
        public int games_played;
        public int games_won;
        public int games_lost;
        public int games_left;
        public int[] friendlist;
        public PlayerType playerType;

        public void Start()
        {
            AckwowledgedPackages = new List<int>();
        }

        public enum PlayerType
        {
            Player, Offensive, Neutral
        }

        public static PlayerType GetPlayerType(string type)
        {
            switch (type)
            {
                case "player" : return PlayerType.Player;
                case "offensive": return PlayerType.Offensive;
                case "neutral": 
                default: return PlayerType.Neutral;
            }
        }
    }
}