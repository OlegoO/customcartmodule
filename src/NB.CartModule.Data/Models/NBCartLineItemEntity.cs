using System.ComponentModel.DataAnnotations;
using NB.CartModule.Core.Models;
using VirtoCommerce.CartModule.Core.Model;
using VirtoCommerce.CartModule.Data.Model;
using VirtoCommerce.Platform.Core.Common;

namespace NB.CartModule.Data.Models
{
    public class NBCartLineItemEntity : LineItemEntity
    {
        [StringLength(128)]
        public string PrescriptionId { get; set; }

        public override LineItem ToModel(LineItem lineItem)
        {
            base.ToModel(lineItem);

            if (lineItem is NBCartLineItem order2)
            {
                order2.PrescriptionId = PrescriptionId;
            }

            return lineItem;
        }

        public override LineItemEntity FromModel(LineItem operation, PrimaryKeyResolvingMap pkMap)
        {
            if (operation is NBCartLineItem lineitem)
            {
                PrescriptionId = lineitem.PrescriptionId;

            }

            return base.FromModel(operation, pkMap);
        }

        public override void Patch(LineItemEntity operation)
        {
            base.Patch(operation);
            if (operation is NBCartLineItemEntity target)
            {
                target.PrescriptionId = PrescriptionId;
            }

        }
    }
}
