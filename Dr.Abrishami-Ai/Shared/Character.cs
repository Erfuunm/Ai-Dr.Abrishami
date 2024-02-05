using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dr.Abrishami_Ai.Shared
{
    public class Character
    {
        public int id { get; set; }

        public string PlayerName { get; set; }

        public int Power { get; set; }

        public bool Rifle { get; set; } = false;
        public bool Snipe { get; set; } = false;
        public bool ShotGun { get; set; } = true;

        public bool Knife { get; set; } = true;



    }
}
