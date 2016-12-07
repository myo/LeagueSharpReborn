using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using PRADA_Vayne.MyUtils;

namespace PRADA_Vayne.MyLogic.Others
{
    public static class SkinHack
    {
        public static void Load()
        {
            Utility.DelayAction.Add(250, RefreshSkin);
            Game.OnUpdate += OnUpdate;
            Game.OnNotify += OnNotify;
        }

        private static void OnNotify(GameNotifyEventArgs args)
        {
            if (args.EventId == GameEventId.OnReincarnate || args.EventId == GameEventId.OnResetChampion)
            {
                Utility.DelayAction.Add(250, RefreshSkin);
            }
        }

        public static void OnUpdate(EventArgs args)
        {
        }

        public static void RefreshSkin()
        {
            ObjectManager.Player.SetSkin(ObjectManager.Player.CharData.BaseSkinName, Program.SkinhackMenu.Item("skin").GetValue<StringList>().SelectedIndex);
        }
    }
}
