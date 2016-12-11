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
        public static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!Program.E.IsReady() || !(sender is Obj_AI_Hero))
            {
                return;
            }
            if ((args.Target != null && args.Target.IsMe) || ObjectManager.Player.Distance(args.End, true) < 350*350)
            {
                if (args.SData.Name == "RenektonDice")
                {
                    Console.WriteLine("renekton gapclose");
                    Program.E.Cast(sender);
                }
                if ((sender.CharData.BaseSkinName == "Leona" || sender.CharData.BaseSkinName == "Graves") && args.Slot == SpellSlot.E)
                {
                    Console.WriteLine("Leona/Graves gapclose");
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Alistar" && args.Slot == SpellSlot.W)
                {
                    Console.WriteLine("Alistar Gapclose");
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Diana" && args.Slot == SpellSlot.R)
                {
                    Console.Write("diana gapclose");
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Shyvana" && args.Slot == SpellSlot.R)
                {
                    Console.WriteLine("shyv gapclose");
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Akali" && args.Slot == SpellSlot.R && args.SData.Cooldown > 2.5)
                {
                    Console.WriteLine("akali gapclsoe");
                    Program.E.Cast(sender);
                }
                if (args.SData.Name.ToLower().Contains("flash") && sender.IsMelee)
                {
                    Console.WriteLine("flash gapclose");
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName.ToLower().Contains("zhao") && args.Slot == SpellSlot.E)
                {
                    Console.WriteLine("xin gc");
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Pantheon" && args.Slot == SpellSlot.W)
                {
                    Program.E.Cast(sender);
                }

                //INTERRUPTER
                if (sender.CharData.BaseSkinName == "Katarina" && args.Slot == SpellSlot.R)
                {
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "MasterYi" && args.Slot == SpellSlot.W)
                {
                    for (var i = 40; i < 425; i += 125)
                    {
                        var flags = NavMesh.GetCollisionFlags(
                            sender.ServerPosition.To2D()
                                .Extend(
                                    Heroes.Player.ServerPosition.To2D(),
                                    -i)
                                .To3D());
                        if (flags != null && flags.HasFlag(CollisionFlags.Wall) || flags.HasFlag(CollisionFlags.Building))
                        {
                            Program.E.Cast(sender);
                            return;
                        }
                    }
                }
            }
        }
    }
}
