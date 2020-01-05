﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetcoreInfrastructure.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
    }
}
