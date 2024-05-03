namespace Pure.Blazor.Components.Forms;

public static class InputAutoFillMap
{
    public static Dictionary<InputAutoComplete, string> Map = new ()
    {
        { InputAutoComplete.None, "none" },
        { InputAutoComplete.Off, "off" },
        { InputAutoComplete.On, "on" },
        { InputAutoComplete.Name, "name" },
        { InputAutoComplete.HonorificPrefix, "honorific-prefix" },
        { InputAutoComplete.GivenName, "given-name" },
        { InputAutoComplete.AdditionalName, "additional-name" },
        { InputAutoComplete.FamilyName, "family-name" },
        { InputAutoComplete.HonorificSuffix, "honorific-suffix" },
        { InputAutoComplete.Nickname, "nickname" },
        { InputAutoComplete.Email, "email" },
        { InputAutoComplete.Username, "username" },
        { InputAutoComplete.NewPassword, "new-password" },
        { InputAutoComplete.CurrentPassword, "current-password" },
        { InputAutoComplete.OrganizationTitle, "organization-title" },
        { InputAutoComplete.Organization, "organization" },
        { InputAutoComplete.StreetAddress, "street-address" },
        { InputAutoComplete.AddressLine1, "address-line1" },
        { InputAutoComplete.AddressLine2, "address-line2" },
        { InputAutoComplete.AddressLine3, "address-line3" },
        { InputAutoComplete.AddressLevel4, "address-level4" },
        { InputAutoComplete.AddressLevel3, "address-level3" },
        { InputAutoComplete.AddressLevel2, "address-level2" },
        { InputAutoComplete.AddressLevel1, "address-level1" },
        { InputAutoComplete.Country, "country" },
        { InputAutoComplete.CountryName, "country-name" },
        { InputAutoComplete.PostalCode, "postal-code" },
        { InputAutoComplete.CCName, "cc-name" },
        { InputAutoComplete.CCCSC, "cc-csc" },
        { InputAutoComplete.CCExp, "cc-exp" },
        { InputAutoComplete.CCExpMonth, "cc-exp-month" },
        { InputAutoComplete.CCExpYear, "cc-exp-year" },
        { InputAutoComplete.CCToken, "cc-token" },
        { InputAutoComplete.TransactionCurrency, "transaction-currency" },
        { InputAutoComplete.TransactionAmount, "transaction-amount" },
        { InputAutoComplete.Language, "language" },
        { InputAutoComplete.Bday, "bday" },
        { InputAutoComplete.BdayDay, "bday-day" },
        { InputAutoComplete.BdayMonth, "bday-month" },
        { InputAutoComplete.BdayYear, "bday-year" },
        { InputAutoComplete.Sex, "sex" },
        { InputAutoComplete.URL, "url" },
        { InputAutoComplete.Photo, "photo" }
    };
}
