using System;
namespace Grit.Web.Entities
{
    public class INetcoreMasterChild : INetcoreBasic
    {
        //never used to store data, just a mark for master detail
        public string HasChild { get; set; }
    }
}
