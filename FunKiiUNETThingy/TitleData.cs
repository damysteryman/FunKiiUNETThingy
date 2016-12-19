using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace FunKiiUNETThingy
{
    [JsonObject]
    class TitleData
    {
        [JsonProperty("titleID")]
        public string TitleID { get; set; }

        [JsonProperty("titleKey")]
        public string TitleKey { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public bool TicketIsAvailable { get; set; }

        [JsonConstructor]
        public TitleData(string _titleID, string _titleKey, string name, string region, string ticket)
        {
            if (name == null || name == "")
                name = "UNKNOWN_TITLE";
            if (region == null || region == "")
                region = "UNK";

            TitleID = _titleID;
            TitleKey = _titleKey;
            Name = name;
            Region = region;
            TicketIsAvailable = Convert.ToBoolean(Convert.ToInt32(ticket));
        }

    }
}
