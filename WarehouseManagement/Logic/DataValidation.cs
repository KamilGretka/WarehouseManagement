using System.Collections.Generic;
using System.Linq;
using WarehouseManagement.Messages;
using WarehouseManagement.Models.DTO;

namespace WarehouseManagement.Logic
{
    internal class DataValidation
    {
        public static List<(string, bool)> CheckProductFields(Product product)
        {
            List<(string, bool)> validationPredicate = new List<(string, bool)>();

            try
            {
                validationPredicate.Add(product.Name.All(char.IsDigit) ? (UserMessages.ProductNameInvalidFormat, false) : (string.Empty, true));
                validationPredicate.Add(CheckNumber(product.NetPrice));
                validationPredicate.Add(CheckNumber(product.Amount));
            }
            catch
            {
                validationPredicate.Add((UserMessages.TextBoxNotFilled, false));
            }

            return validationPredicate;
        }

        public static (string, bool) CheckNumber(decimal number)
        {
            return number.Equals(0) ? (UserMessages.ParameterCannotBeEqualsToZero, false) : (string.Empty, true);
        }
    }
}