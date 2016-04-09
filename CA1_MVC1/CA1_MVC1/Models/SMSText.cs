using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA1_MVC1.Models
{
    public class SMSText
    {
        public int Id { get; set; }
       // public DateTime LogTime { get; set; }
        [Required]
        [RegularExpression(@"\d{3}", ErrorMessage = "The area code Can not great or less than 3 eg.087")]
        [DisplayName("Area Code   :")]
        public string AreaCodeSmS { get; set; }

        [Required]
        [RegularExpression(@"\d{7}", ErrorMessage = "The Phone Number code Can not great or less than 7 digis")]
        [DisplayName("Phone Number:")]
        public string PhoneNumberSmS { get; set; }
        
        [Required]
        
        [StringLength(140, ErrorMessage = "The message content has to less than 140 charts")]
        //because the content field is [required] which can not leave as empty, here has no needs to setup Min. [StringLenght]
        [DisplayName("Text Content:")]
        [DataType(DataType.MultilineText)]
        public string TextContentSmS { get; set; }


    }
   // ISMSTextRepository 
   //this part use to try using Moq.
    public interface ISMSTextRepository
    {
        SMSText GetContactById(string id);
    }
}