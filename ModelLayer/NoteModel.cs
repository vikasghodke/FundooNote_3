using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelLayer
{
    public class NoteModel
    {
       
        public string title {  get; set; }
        public string color {  get; set; }
        public bool IsDeleted {  get; set; }
       
        
        public bool IsArchived {  get; set; }=false;
        //[ForeignKey("User")]

       


    }
}
