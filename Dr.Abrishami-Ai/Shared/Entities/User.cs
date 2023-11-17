
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dr.Abrishami_Ai.Shared.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public int RankInClass { get; set; }

        public string Name { get; set; }

        public string lastName { get; set; }

        public string nickName { get; set; }

        public long studentCode { get; set; }

        public long password { get; set; }

        public int teamId { get; set; }

        public string teamName { get; set; }

        public int friendsId { get; set; }  

        public int friendsNumber { get; set; }

        public virtual ICollection<friends> Friends { get; set; }

        public ShopItem shopItems { get; set; }

        public Questions questions { get; set; }

        public int Diamonds { get; set; }
    }
}
