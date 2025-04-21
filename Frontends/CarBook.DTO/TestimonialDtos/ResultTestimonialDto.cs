using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.TestimonialDtos
{
    public class ResultTestimonialDto
    {
            public int testimonialID { get; set; }
            public string name { get; set; }
            public string title { get; set; }
            public object comment { get; set; }
            public string imageUrl { get; set; }
    }
}
