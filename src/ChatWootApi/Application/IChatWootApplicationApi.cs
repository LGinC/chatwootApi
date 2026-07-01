namespace ChatWootApi.Application;

public interface IChatWootApplicationApi :
    IApplicationAccountApi,
    IApplicationAccountAgentBotsApi,
    IApplicationAgentsApi,
    IApplicationAuditLogsApi,
    IApplicationAutomationRuleApi,
    IApplicationCannedResponsesApi,
    IApplicationContactLabelsApi,
    IApplicationContactsApi,
    IApplicationConversationAssignmentsApi,
    IApplicationConversationsApi,
    IApplicationCustomAttributesApi,
    IApplicationCustomFiltersApi,
    IApplicationHelpCenterApi,
    IApplicationInboxesApi,
    IApplicationIntegrationsApi,
    IApplicationLabelsApi,
    IApplicationMessagesApi,
    IApplicationProfileApi,
    IApplicationReportsApi,
    IApplicationTeamsApi,
    IApplicationWebhooksApi;
