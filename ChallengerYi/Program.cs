using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.SDK;
using LeagueSharp.SDK.Utils;
using SharpDX;
using Bootstrap = ChallengerYi.Backbone.Bootstrap;
using Color = System.Drawing.Color;

namespace ChallengerYi
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Events.OnLoad += (arg1, arg2) =>
            {
                if (ObjectManager.Player.ChampionName.ToLower().Contains("yi"))
                {
                    DelayAction.Add(1250, Bootstrap.Start);
                }
            };
        }
    }
}
