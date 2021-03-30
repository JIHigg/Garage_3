using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Utils
{
    public class FNameValidation : CompareAttribute
    {
        public FNameValidation(string otherProperty):base(otherProperty)
        {
            //bool success = true;
            //if (base.Equals(otherProperty))
            //    success = false;
            
        }
        public override object TypeId => base.TypeId;

        public override bool RequiresValidationContext => base.RequiresValidationContext;

        public override bool Equals(object obj)
        {
            bool success = true;
            if (base.Equals(obj))
                success = false;
            return success;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

        public override bool Match(object obj)
        {
            bool success = true;
            if (base.Equals(obj))
                success = false;
            return success;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
