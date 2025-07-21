using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugestedItemsIA {

    public class Purchase {
        public int ClientId { get; set; }
        public string ItemId { get; set; }

        public Purchase(int clientId, string itemId) {
            ClientId = clientId;
            ItemId = itemId;
        }
    }

}
