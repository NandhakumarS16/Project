using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Syn.Bot.Channels.Widget;
using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Project.Models
{

    public class BotDialog : Dialog
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Request { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Keyword1 { get; set; }


        [StringLength(50, MinimumLength = 3)]
        public string Keyword2 { get; set; }


        [StringLength(50, MinimumLength = 1)]
        public string Keyword3 { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Response { get; set; }

       
    }
}