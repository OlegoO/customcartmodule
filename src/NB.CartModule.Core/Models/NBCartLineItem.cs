using System;
using System.Collections.Generic;
using System.Text;
using VirtoCommerce.CartModule.Core.Model;

namespace NB.CartModule.Core.Models
{
    public class NBCartLineItem : LineItem
    {
        public string PrescriptionId { get; set; }

        //public override object Clone()
        //{
        //    var result = base.Clone() as NBCartLineItem;

        //    result.PrescriptionId = PrescriptionId;

        //    return result;
        //}

    }
}
