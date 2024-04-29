using System.Text.Json.Serialization;

namespace httpClient_p2.Models
{
    public record Merchant(
                [property: JsonPropertyName("Id")] Guid? Id,
                [property: JsonPropertyName("MerchantCode")] string? MerchantCode,
                [property: JsonPropertyName("Name")] string? Name,
                [property: JsonPropertyName("Status")] string? Status,
                [property: JsonPropertyName("Address")] string? Address,
                [property: JsonPropertyName("City")] string? City,
                [property: JsonPropertyName("StateTerritory")] string? StateTerritory,
                [property: JsonPropertyName("PostalCode")] string? PostalCode,
                [property: JsonPropertyName("Country")] string? Country,
                [property: JsonPropertyName("Phone")] string? Phone,
                [property: JsonPropertyName("EmailAddresses")] List<string>? EmailAddresses,
                [property: JsonPropertyName("TaxId")] string? TaxId,
                [property: JsonPropertyName("CreatedBy")] string? CreatedBy,
                [property: JsonPropertyName("CreatedDate")] DateTime? CreatedDate,
                [property: JsonPropertyName("ModifiedBy")] string? ModifiedBy,
                [property: JsonPropertyName("ModifiedDate")] DateTime? ModifiedDate,
                [property: JsonPropertyName("DetailedResponseMessage")] string? DetailedResponseMessage,
                [property: JsonPropertyName("OrgBankId")] Guid? OrgBankId,
                [property: JsonPropertyName("OrgCompanyId")] Guid? OrgCompanyId
        );
}
