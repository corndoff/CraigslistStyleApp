using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CraiglistAPI.Models
{
    public class NewWtb
    {
        public int PostId { get; set; }
        public string ObjectDescription { get; set; }
        public string ObjectType { get; set; }
        public string BuyersEmail { get; set; }
        public string BuyersPhoneNumber { get; set; }
        public string BuyersState { get; set; }
        public string PhotoFileName { get; set; }
    }
}