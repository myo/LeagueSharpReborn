﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using PRADA_Vayne.MyUtils;

namespace PRADA_Vayne.MyLogic.E
{
    public static partial class Events
    {
        public static void OnUpdate(EventArgs args)
        {
            if (Program.E.IsReady())
            {
                if (Program.ComboMenu.Item("ManualE").GetValue<KeyBind>().Active)
                {
                    foreach (var hero in Heroes.EnemyHeroes.Where(h => h.Distance(Heroes.Player) < 550))
                    {
                        if (hero != null)
                        {
                            for (var i = 40; i < 425; i += 125)
                            {
                                var flags = NavMesh.GetCollisionFlags(
                                    hero.ServerPosition.To2D()
                                        .Extend(
                                            Heroes.Player.ServerPosition.To2D(),
                                            -i)
                                        .To3D());
                                if (flags != null && flags.HasFlag(CollisionFlags.Wall) || flags.HasFlag(CollisionFlags.Building))
                                {
                                    Program.E.Cast(hero);
                                    return;
                                }
                            }
                        }
                    }
                }
                if (Program.ComboMenu.Item("ECombo").GetValue<bool>())
                {
                    foreach (var enemy in Heroes.EnemyHeroes.Where(e=>e.IsValidTarget(550)))
                    {
                        if (enemy != null && enemy.IsCondemnable() && (!enemy.HasBuff("BlackShield") && !enemy.HasBuff("SivirE")
                        && !enemy.HasBuff("NocturneShroudofDarkness")))
                        {
                            Program.E.Cast(enemy);
                        }
                    }
                }
                var kindredUltedDyingTarget =
                    ObjectManager.Get<Obj_AI_Hero>()
                        .FirstOrDefault(
                            h =>
                                h.IsValidTarget(550) && h.HasBuff("KindredRNoDeathBuff") &&
                                h.Health < ObjectManager.Player.GetAutoAttackDamage(h));
                if (kindredUltedDyingTarget != null)
                {
                    Program.E.Cast(kindredUltedDyingTarget);
                }
            }
        }
    }
}
