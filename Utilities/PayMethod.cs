using System;
using System.Collections.Generic;
using System.Text;
using DTO.Clases;

namespace Utilities
{
    public class PayMethod
    {
        public static string Cash { set; get; }

        public static string Transfer { set; get; }

        public static string Card { set; get; }

        public static void LoadPayMents(List<FormaPago> payments)
        {

        }
    }
}