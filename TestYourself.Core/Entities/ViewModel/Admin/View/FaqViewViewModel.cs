﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Core.Entities.ViewModel.Admin.Edition
{
    public class FaqViewViewModel
    {
        public FaqViewViewModel()
        {
            Faq = new Faq();
        }
        public Faq Faq { get; set; }
    }
}
