using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BosApen
{
    class Log
    {
        [Key]
        public int Id { get; set; }
        public int woodID { get; set; }
        public int monkeyID { get; set; }
        public string message { get; set; }

        public Log(int woodID,int monkeyID,string message)
        {
            this.woodID = woodID;
            this.monkeyID = monkeyID;
            this.message = message;
        }
    }
}
