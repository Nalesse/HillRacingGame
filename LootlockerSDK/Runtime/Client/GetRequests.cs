using System.Collections.Generic;

namespace Client
{
    public class LootLockerGetRequest
    {
        public List<string> getRequests = new List<string>();

        public bool ShouldSerializegetRequests()
        {
            // don't serialize the getRequests property.
            return false;
        }
    }
}