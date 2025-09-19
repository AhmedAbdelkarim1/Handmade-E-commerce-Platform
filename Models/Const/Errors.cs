using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Const
{
	public static class Errors
	{
		public const string RequiredField = "Required field";
		public const string MaxLength = "{PropertyName} cannot be more than {MaxLength} characters";
		public const string MaxMinLength = "The {PropertyName} must be at least {MinLength} and at max {MaxLength} characters long.";
		public const string MinLength = "{PropertyName} cannot be less than {MinLength} characters";
		public const string WeakPassword = "Passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least 8 characters long";
		public const string TypeError = "{PropertyName} must be 'Admin' or 'Seller' or 'Customer'.";
		public const string InvalidMobileNumber = "Invalid mobile number.";
		public const string InvalidNationalId = "Invalid national ID.";
		public const string OnlyNumbersAndLetters = "Only Arabic/English letters or digits are allowed.";
		public const string OnlyEnglishLetters = "Only English letters are allowed.";
        public const string Duplicated = "Another record with the same {PropertyName} is already exists!";

    }
}
