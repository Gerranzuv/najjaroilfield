﻿using najjar.biz.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace najjar.biz.Extra
{
    public class ParameterRepository
    {
        private static ApplicationDataContext db = new ApplicationDataContext();

        public static string findByCode(string code){
           return db.SystemParameters.Where(x => x.Code.Equals(code)).Select(y => y.Value).FirstOrDefault();
        }
    }
}