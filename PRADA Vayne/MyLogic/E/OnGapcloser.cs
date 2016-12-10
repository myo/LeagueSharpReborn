using System;
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
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Leona" && args.Slot == SpellSlot.E)
                {
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Alistar" && args.Slot == SpellSlot.W)
                {
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Diana" && args.Slot == SpellSlot.R)
                {
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Shyvana" && args.Slot == SpellSlot.R)
                {
                    Program.E.Cast(sender);
                }
                if (sender.CharData.BaseSkinName == "Akali" && args.Slot == SpellSlot.R && args.SData.Cooldown > 2.5)
                {
                    Program.E.Cast(sender);
                }
                if (args.SData.Name.ToLower().Contains("flash") && sender.IsMelee)
                {
                    Program.E.Cast(sender);
                }
            }
        }
    }
}
