using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CraiglistAPI.Models
{
    public class NewPost
    {
        public int PostId { get; set; }
        public decimal ObjectPrice { get; set; }
        public string ObjectDescription { get; set; }
        public string ObjectType { get; set; }
        public string SellersEmail { get; set; }
        public string SellersPhoneNumber { get; set; }
        public string SellersState { get; set; }
        public string PhotoFileName { get; set; }
    }
}