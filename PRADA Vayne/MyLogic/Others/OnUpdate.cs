using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using PRADA_Vayne.MyUtils;

namespace PRADA_Vayne.MyLogic.Others
{
    public static partial class Events
    {
        public static void OnUpdate(EventArgs args)
        {
            if (Heroes.Player.HasBuff("rengarralertsound"))
            {
                if (Items.HasItem((int)ItemId.Oracles_Lens_Trinket, Heroes.Player) && Items.CanUseItem((int)ItemId.Oracles_Lens_Trinket))
                {
                    Items.UseItem((int)ItemId.Oracles_Lens_Trinket, Heroes.Player.Position);
                }
                else if (Items.HasItem((int)ItemId.Vision_Ward, Heroes.Player))
                {
                    Items.UseItem((int)ItemId.Vision_Ward, Heroes.Player.Position.Randomize(0, 125));
                }
            }
        }
    }
}
