using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;
using ChatWootApi.Application;
using ChatWootApi.Application.Models;
using Refit;

namespace ChatWootApi.Tests;

/// <summary>
/// Locks API return types and response model shapes to application_swagger.json
/// (contact / contact_base / extended_contact / contact_show_response / contacts_list_response, etc.).
/// </summary>
public sealed class SwaggerResponseShapeContractTests
{
    [Fact]
    public void ContactCreateReturnsExtendedContact()
    {
        Assert.Equal(
            typeof(Task<ExtendedContact>),
            GetMethod(typeof(IApplicationContactsApi), nameof(IApplicationContactsApi.ContactCreateAsync)).ReturnType);
    }

    [Fact]
    public void ContactUpdateAndMergeReturnContactBase()
    {
        Assert.Equal(
            typeof(Task<ContactBase>),
            GetMethod(typeof(IApplicationContactsApi), nameof(IApplicationContactsApi.ContactUpdateAsync)).ReturnType);
        Assert.Equal(
            typeof(Task<ContactBase>),
            GetMethod(typeof(IApplicationContactsApi), nameof(IApplicationContactsApi.ContactMergeAsync)).ReturnType);
    }

    [Fact]
    public void ContactDetailsReturnsContactShowResponse()
    {
        Assert.Equal(
            typeof(Task<ContactShowResponse>),
            GetMethod(typeof(IApplicationContactsApi), nameof(IApplicationContactsApi.ContactDetailsAsync)).ReturnType);
    }

    [Fact]
    public void ContactListAndSearchReturnContactsListResponse()
    {
        Assert.Equal(
            typeof(Task<ContactsListResponse>),
            GetMethod(typeof(IApplicationContactsApi), nameof(IApplicationContactsApi.ContactListAsync)).ReturnType);

        // Public entry has optional query parameters.
        var searchEntry = typeof(IApplicationContactsApi)
            .GetMethods()
            .Single(method =>
                method.Name == nameof(IApplicationContactsApi.ContactSearchAsync) &&
                method.GetParameters().Any(parameter => parameter.Name == "q"));

        Assert.Equal(typeof(Task<ContactsListResponse>), searchEntry.ReturnType);
    }

    [Fact]
    public void ContactSwaggerShape_PayloadIsContactListItemArray()
    {
        // swagger contact.payload: array of contact fields
        AssertJsonProperty(
            typeof(Contact),
            "Payload",
            "payload",
            typeof(IReadOnlyList<ContactListItem>));
    }

    [Fact]
    public void ContactBaseSwaggerShape_IdPlusContactPayloadArray()
    {
        // swagger contact_base = generic_id + contact
        Assert.True(typeof(Contact).IsAssignableFrom(typeof(ContactBase)));
        AssertJsonProperty(typeof(ContactBase), "Id", "id", typeof(long?));
        AssertJsonProperty(
            typeof(ContactBase),
            "Payload",
            "payload",
            typeof(IReadOnlyList<ContactListItem>));
    }

    [Fact]
    public void ExtendedContactSwaggerShape_IdAvailabilityPlusContactPayloadArray()
    {
        // swagger extended_contact = contact + id + availability_status
        Assert.True(typeof(Contact).IsAssignableFrom(typeof(ExtendedContact)));
        AssertJsonProperty(typeof(ExtendedContact), "Id", "id", typeof(long?));
        AssertJsonProperty(typeof(ExtendedContact), "AvailabilityStatus", "availability_status", typeof(AgentAvailability?));
        AssertJsonProperty(
            typeof(ExtendedContact),
            "Payload",
            "payload",
            typeof(IReadOnlyList<ContactListItem>));
    }

    [Fact]
    public void ContactShowResponseSwaggerShape_PayloadIsSingleContactListItem()
    {
        // swagger contact_show_response.payload: contact_list_item (object, not array)
        AssertJsonProperty(
            typeof(ContactShowResponse),
            "Payload",
            "payload",
            typeof(ContactListItem));
    }

    [Fact]
    public void ContactsListResponseSwaggerShape_MetaAndPayloadArray()
    {
        AssertJsonProperty(typeof(ContactsListResponse), "Meta", "meta", typeof(ContactMeta));
        AssertJsonProperty(
            typeof(ContactsListResponse),
            "Payload",
            "payload",
            typeof(IReadOnlyList<ContactListItem>));
    }

    [Fact]
    public void ConversationShowSwaggerShape_InheritsConversationAndHasMeta()
    {
        Assert.True(typeof(Conversation).IsAssignableFrom(typeof(ConversationShow)));
        AssertJsonProperty(
            typeof(ConversationShow),
            "Meta",
            "meta",
            typeof(ConversationListItemMeta));
    }

    [Fact]
    public void ConversationListSwaggerShape_DataHasMetaAndPayloadArray()
    {
        AssertJsonProperty(typeof(ConversationList), "Data", "data", typeof(ConversationListData));
        AssertJsonProperty(typeof(ConversationListData), "Meta", "meta", typeof(ConversationListMeta));
        AssertJsonProperty(
            typeof(ConversationListData),
            "Payload",
            "payload",
            typeof(IReadOnlyList<ConversationListItem>));
    }

    [Fact]
    public void ReportSummaryApisReturnArraysPerSwagger()
    {
        Assert.Equal(
            typeof(Task<IReadOnlyList<AgentSummary>>),
            GetMethod(typeof(IApplicationReportsApi), nameof(IApplicationReportsApi.GetAgentSummaryReportAsync)).ReturnType);
        Assert.Equal(
            typeof(Task<IReadOnlyList<InboxSummary>>),
            GetMethod(typeof(IApplicationReportsApi), nameof(IApplicationReportsApi.GetInboxSummaryReportAsync)).ReturnType);
        Assert.Equal(
            typeof(Task<IReadOnlyList<TeamSummary>>),
            GetMethod(typeof(IApplicationReportsApi), nameof(IApplicationReportsApi.GetTeamSummaryReportAsync)).ReturnType);
        Assert.Equal(
            typeof(Task<IReadOnlyList<OutgoingMessagesCount>>),
            GetMethod(typeof(IApplicationReportsApi), nameof(IApplicationReportsApi.GetOutgoingMessagesCountAsync)).ReturnType);
    }

    [Fact]
    public void ChannelAndFrtDistributionAreStringKeyedMaps()
    {
        Assert.True(typeof(IDictionary<string, ChannelConversationStatusCounts>).IsAssignableFrom(typeof(ChannelSummary)));
        Assert.True(typeof(IDictionary<string, FirstResponseTimeBuckets>).IsAssignableFrom(typeof(FirstResponseTimeDistribution)));

        Assert.Equal(
            typeof(Task<ChannelSummary>),
            GetMethod(typeof(IApplicationReportsApi), nameof(IApplicationReportsApi.GetChannelSummaryReportAsync)).ReturnType);
        Assert.Equal(
            typeof(Task<FirstResponseTimeDistribution>),
            GetMethod(typeof(IApplicationReportsApi), nameof(IApplicationReportsApi.GetFirstResponseTimeDistributionAsync)).ReturnType);
    }

    [Fact]
    public void MessageStatusAndContentTypeUseDocumentedEnums()
    {
        AssertJsonProperty(typeof(Message), "Status", "status", typeof(MessageStatus?));
        AssertJsonProperty(typeof(Message), "ContentType", "content_type", typeof(MessageContentType?));

        var status = typeof(Message).GetProperty(nameof(Message.Status))!;
        var contentType = typeof(Message).GetProperty(nameof(Message.ContentType))!;
        Assert.NotNull(status.GetCustomAttribute<JsonConverterAttribute>());
        Assert.NotNull(contentType.GetCustomAttribute<JsonConverterAttribute>());
    }

    private static void AssertJsonProperty(
        Type type,
        string propertyName,
        string jsonName,
        Type expectedClrType)
    {
        var property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)
            ?? type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
        // FlattenHierarchy does not walk base for GetProperty on derived the same way for all runtimes;
        // walk base types explicitly.
        if (property is null)
        {
            for (var current = type; current is not null && property is null; current = current.BaseType)
            {
                property = current.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            }
        }

        Assert.NotNull(property);
        Assert.Equal(expectedClrType, property.PropertyType);

        var jsonProperty = property.GetCustomAttribute<JsonPropertyNameAttribute>();
        Assert.NotNull(jsonProperty);
        Assert.Equal(jsonName, jsonProperty.Name);
    }

    private static MethodInfo GetMethod(Type interfaceType, string methodName)
    {
        var method = interfaceType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);
        Assert.NotNull(method);
        return method;
    }
}
