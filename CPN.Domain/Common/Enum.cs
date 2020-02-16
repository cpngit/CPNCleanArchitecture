namespace CPN.Model
{
    public enum IntegrationType
    {
        MailChimp,
        SuperLogicaCliente,
        SuperLogicaContrato,
        ClickSignContrato,
        Ploomes
    }

    public enum ContactType
    {
        Visit,
        PhoneCall,
        Email,
        Meeting,
        ConferenceCall,
        Other
    }
    
    public enum ProposalStatus
    {
        Pending,
        Sent,
        Closed
    }

    public enum OpportunityStatus
{
    FirstContact,
    SentProposal,
    Closed
};

    public enum ContractStatus
    {
        Pending,
        MissingDocuments,
        Active,
        Stopped
    }

    public enum InvoiceType
    {
        Charge,
        ClientNotification,
        Booking

    }

    public enum Recurrence
    {
        Daily,
        Weekly,
        Monthly,        
        Bimonthly,
        Quarterly,
        Semiannually,
        Annually,
        Forever
    }

    public enum ResourceType
    {
        Workstation,
        MeetRoom,
        TrainingRoom,
        Common,
        ExclusiveRoom
    }

    public enum Language
    {
        Portuguese,
        English
    }

    public enum Currency
    {
        BrazilianReal,
        USDDolar
    }

    public enum SpaceType
    {
        Office,
        CoworkingSpace,
        Metting
    }
}