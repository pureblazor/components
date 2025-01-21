namespace Pure.Blazor.Components;

/// <summary>
/// Input autofill values
/// https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofilling-form-controls:-the-autocomplete-attribute
/// </summary>
[Flags]
public enum InputAutoComplete
{
    None,
    Off,
    On,
    Name,
    HonorificPrefix,
    GivenName,
    AdditionalName,
    FamilyName,
    HonorificSuffix,
    Nickname,
    Email,
    Username,
    NewPassword,
    CurrentPassword,
    OrganizationTitle,
    Organization,
    StreetAddress,
    AddressLine1,
    AddressLine2,
    AddressLine3,
    AddressLevel4,
    AddressLevel3,
    AddressLevel2,
    AddressLevel1,
    Country,
    CountryName,
    PostalCode,
    CCName,
    CCCSC,
    CCExp,
    CCExpMonth,
    CCExpYear,
    CCToken,
    TransactionCurrency,
    TransactionAmount,
    Language,
    Bday,
    BdayDay,
    BdayMonth,
    BdayYear,
    Sex,
    URL,
    Photo
}
