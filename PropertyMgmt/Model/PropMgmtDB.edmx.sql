
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2015 10:48:20
-- Generated from EDMX file: C:\Users\zebr\Documents\Visual Studio 2013\Projects\PropertyMgmt\PropertyMgmt\Model\PropMgmtDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PropertyMgmt];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PropertiesTenants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tenants] DROP CONSTRAINT [FK_PropertiesTenants];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactTenants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tenants] DROP CONSTRAINT [FK_ContactTenants];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnersContact_Owners]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OwnersContact] DROP CONSTRAINT [FK_OwnersContact_Owners];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnersContact_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OwnersContact] DROP CONSTRAINT [FK_OwnersContact_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorsContact_Vendors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendorsContact] DROP CONSTRAINT [FK_VendorsContact_Vendors];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorsContact_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendorsContact] DROP CONSTRAINT [FK_VendorsContact_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_HOAsContact_HOAs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOAsContact] DROP CONSTRAINT [FK_HOAsContact_HOAs];
GO
IF OBJECT_ID(N'[dbo].[FK_HOAsContact_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOAsContact] DROP CONSTRAINT [FK_HOAsContact_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyManagersContact_PropertyManagers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PropertyManagersContact] DROP CONSTRAINT [FK_PropertyManagersContact_PropertyManagers];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyManagersContact_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PropertyManagersContact] DROP CONSTRAINT [FK_PropertyManagersContact_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertiesServiceCalls]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceCalls] DROP CONSTRAINT [FK_PropertiesServiceCalls];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilitiesPaymentHistoryUtilitiesTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UtilitiesPaymentHistories] DROP CONSTRAINT [FK_UtilitiesPaymentHistoryUtilitiesTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertiesGateCodes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GateCodes] DROP CONSTRAINT [FK_PropertiesGateCodes];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertiesParkingStalls]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParkingStalls] DROP CONSTRAINT [FK_PropertiesParkingStalls];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertiesUtilitiesPaymentHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UtilitiesPaymentHistories] DROP CONSTRAINT [FK_PropertiesUtilitiesPaymentHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_TenantsVehicles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_TenantsVehicles];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertiesHOAs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Properties] DROP CONSTRAINT [FK_PropertiesHOAs];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorsBusinessTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendors] DROP CONSTRAINT [FK_VendorsBusinessTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_LedgerRecordDepositTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LedgerRecords] DROP CONSTRAINT [FK_LedgerRecordDepositTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_LedgerRecordPaymentTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LedgerRecords] DROP CONSTRAINT [FK_LedgerRecordPaymentTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_TenantsLedgerRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LedgerRecords] DROP CONSTRAINT [FK_TenantsLedgerRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnersLedgerRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LedgerRecords] DROP CONSTRAINT [FK_OwnersLedgerRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorsLedgerRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LedgerRecords] DROP CONSTRAINT [FK_VendorsLedgerRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_HOAsLedgerRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LedgerRecords] DROP CONSTRAINT [FK_HOAsLedgerRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyManagersLedgerRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LedgerRecords] DROP CONSTRAINT [FK_PropertyManagersLedgerRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_LedgerRecordChargeTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LedgerRecords] DROP CONSTRAINT [FK_LedgerRecordChargeTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertiesOwners]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Properties] DROP CONSTRAINT [FK_PropertiesOwners];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorServiceCall]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceCalls] DROP CONSTRAINT [FK_VendorServiceCall];
GO
IF OBJECT_ID(N'[dbo].[FK_HOAHOA_PropertyManagerHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOA_PropertyManagerHistories] DROP CONSTRAINT [FK_HOAHOA_PropertyManagerHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyManagerHOA_PropertyManagerHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOA_PropertyManagerHistories] DROP CONSTRAINT [FK_PropertyManagerHOA_PropertyManagerHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_TenantCorrespondence]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Correspondences] DROP CONSTRAINT [FK_TenantCorrespondence];
GO
IF OBJECT_ID(N'[dbo].[FK_FileContainerFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContainers] DROP CONSTRAINT [FK_FileContainerFile];
GO
IF OBJECT_ID(N'[dbo].[FK_TenantFileContainer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContainers] DROP CONSTRAINT [FK_TenantFileContainer];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyFileContainer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContainers] DROP CONSTRAINT [FK_PropertyFileContainer];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorFileContainer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContainers] DROP CONSTRAINT [FK_VendorFileContainer];
GO
IF OBJECT_ID(N'[dbo].[FK_HOAFileContainer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContainers] DROP CONSTRAINT [FK_HOAFileContainer];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnerFileContainer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContainers] DROP CONSTRAINT [FK_OwnerFileContainer];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyManagerFileContainer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileContainers] DROP CONSTRAINT [FK_PropertyManagerFileContainer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Owners]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Owners];
GO
IF OBJECT_ID(N'[dbo].[Properties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Properties];
GO
IF OBJECT_ID(N'[dbo].[Tenants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tenants];
GO
IF OBJECT_ID(N'[dbo].[ParkingStalls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParkingStalls];
GO
IF OBJECT_ID(N'[dbo].[ServiceCalls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceCalls];
GO
IF OBJECT_ID(N'[dbo].[Vendors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vendors];
GO
IF OBJECT_ID(N'[dbo].[GateCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GateCodes];
GO
IF OBJECT_ID(N'[dbo].[Vehicles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicles];
GO
IF OBJECT_ID(N'[dbo].[HOAs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HOAs];
GO
IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[PropertyManagers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PropertyManagers];
GO
IF OBJECT_ID(N'[dbo].[HOA_PropertyManagerHistories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HOA_PropertyManagerHistories];
GO
IF OBJECT_ID(N'[dbo].[UtilitiesPaymentHistories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilitiesPaymentHistories];
GO
IF OBJECT_ID(N'[dbo].[LedgerRecords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LedgerRecords];
GO
IF OBJECT_ID(N'[dbo].[PaymentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentTypes];
GO
IF OBJECT_ID(N'[dbo].[ChargeTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChargeTypes];
GO
IF OBJECT_ID(N'[dbo].[BusinessTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessTypes];
GO
IF OBJECT_ID(N'[dbo].[UtilitiesTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilitiesTypes];
GO
IF OBJECT_ID(N'[dbo].[DepositTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepositTypes];
GO
IF OBJECT_ID(N'[dbo].[Correspondences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Correspondences];
GO
IF OBJECT_ID(N'[dbo].[Files]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files];
GO
IF OBJECT_ID(N'[dbo].[FileContainers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileContainers];
GO
IF OBJECT_ID(N'[dbo].[OwnersContact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OwnersContact];
GO
IF OBJECT_ID(N'[dbo].[VendorsContact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendorsContact];
GO
IF OBJECT_ID(N'[dbo].[HOAsContact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HOAsContact];
GO
IF OBJECT_ID(N'[dbo].[PropertyManagersContact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PropertyManagersContact];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Owners'
CREATE TABLE [dbo].[Owners] (
    [id] int IDENTITY(1,1) NOT NULL,
    [company_name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Properties'
CREATE TABLE [dbo].[Properties] (
    [id] int IDENTITY(1,1) NOT NULL,
    [address1] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NOT NULL,
    [zip] nvarchar(max)  NOT NULL,
    [address2] nvarchar(max)  NULL,
    [mailbox_info] nvarchar(max)  NULL,
    [owner_pays_utilities] bit  NOT NULL,
    [hoa_id] int  NULL,
    [owner_id] int  NOT NULL
);
GO

-- Creating table 'Tenants'
CREATE TABLE [dbo].[Tenants] (
    [id] int IDENTITY(1,1) NOT NULL,
    [lease_start] datetime  NOT NULL,
    [lease_end] datetime  NOT NULL,
    [rent_amt] int  NOT NULL,
    [section8] bit  NOT NULL,
    [property_id] int  NOT NULL,
    [contact_id] int  NOT NULL
);
GO

-- Creating table 'ParkingStalls'
CREATE TABLE [dbo].[ParkingStalls] (
    [stall] nvarchar(max)  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [property_id] int  NOT NULL
);
GO

-- Creating table 'ServiceCalls'
CREATE TABLE [dbo].[ServiceCalls] (
    [id] int IDENTITY(1,1) NOT NULL,
    [time_placed] datetime  NOT NULL,
    [time_completed] datetime  NULL,
    [summary] nvarchar(max)  NOT NULL,
    [notes] nvarchar(max)  NULL,
    [invoice_nbr] int  NOT NULL,
    [vendor_id] int  NULL,
    [amount_due] int  NULL,
    [next_eta] datetime  NULL,
    [property_id] int  NOT NULL
);
GO

-- Creating table 'Vendors'
CREATE TABLE [dbo].[Vendors] (
    [id] int IDENTITY(1,1) NOT NULL,
    [company_name] nvarchar(max)  NOT NULL,
    [address1] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NOT NULL,
    [zip] nvarchar(max)  NOT NULL,
    [phone1] nvarchar(max)  NOT NULL,
    [phone2] nvarchar(max)  NULL,
    [address2] nvarchar(max)  NULL,
    [fax] nvarchar(max)  NULL,
    [active] bit  NOT NULL,
    [BusinessType_id] int  NOT NULL
);
GO

-- Creating table 'GateCodes'
CREATE TABLE [dbo].[GateCodes] (
    [code] nvarchar(max)  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [property_id] int  NOT NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [license_plate] nvarchar(max)  NOT NULL,
    [make] nvarchar(max)  NOT NULL,
    [model] nvarchar(max)  NOT NULL,
    [year] int  NOT NULL,
    [tenant_id] int  NOT NULL,
    [color] nvarchar(max)  NULL
);
GO

-- Creating table 'HOAs'
CREATE TABLE [dbo].[HOAs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [company_name] nvarchar(max)  NOT NULL,
    [address1] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NOT NULL,
    [zip] nvarchar(max)  NOT NULL,
    [phone1] nvarchar(max)  NOT NULL,
    [phone2] nvarchar(max)  NULL,
    [address2] nvarchar(max)  NULL,
    [fax] nvarchar(max)  NULL
);
GO

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [address1] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [middle_initial] nvarchar(max)  NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NOT NULL,
    [zip] nvarchar(max)  NOT NULL,
    [phone1] nvarchar(max)  NOT NULL,
    [phone2] nvarchar(max)  NULL,
    [address2] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL,
    [fax] nvarchar(max)  NULL
);
GO

-- Creating table 'PropertyManagers'
CREATE TABLE [dbo].[PropertyManagers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [company_name] nvarchar(max)  NOT NULL,
    [address1] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [state] nvarchar(max)  NOT NULL,
    [zip] nvarchar(max)  NOT NULL,
    [phone1] nvarchar(max)  NOT NULL,
    [phone2] nvarchar(max)  NULL,
    [address2] nvarchar(max)  NULL,
    [fax] nvarchar(max)  NULL
);
GO

-- Creating table 'HOA_PropertyManagerHistories'
CREATE TABLE [dbo].[HOA_PropertyManagerHistories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date_start] datetime  NOT NULL,
    [date_end] datetime  NULL,
    [hoa_id] int  NOT NULL,
    [property_manager_id] int  NOT NULL
);
GO

-- Creating table 'UtilitiesPaymentHistories'
CREATE TABLE [dbo].[UtilitiesPaymentHistories] (
    [due_date] datetime  NOT NULL,
    [transaction_date] datetime  NOT NULL,
    [amount_paid] decimal(18,0)  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [property_id] int  NOT NULL,
    [UtilitiesType_id] int  NOT NULL
);
GO

-- Creating table 'LedgerRecords'
CREATE TABLE [dbo].[LedgerRecords] (
    [id] int IDENTITY(1,1) NOT NULL,
    [amount] decimal(18,0)  NOT NULL,
    [due_date] datetime  NULL,
    [transaction_date] datetime  NULL,
    [notes] nvarchar(max)  NULL,
    [DepositType_id] int  NULL,
    [PaymentType_id] int  NULL,
    [Tenant_id] int  NULL,
    [Owner_id] int  NULL,
    [Vendor_id] int  NULL,
    [HOA_id] int  NULL,
    [PropertyManager_id] int  NULL,
    [ChargeType_id] int  NULL
);
GO

-- Creating table 'PaymentTypes'
CREATE TABLE [dbo].[PaymentTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChargeTypes'
CREATE TABLE [dbo].[ChargeTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BusinessTypes'
CREATE TABLE [dbo].[BusinessTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UtilitiesTypes'
CREATE TABLE [dbo].[UtilitiesTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DepositTypes'
CREATE TABLE [dbo].[DepositTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Correspondences'
CREATE TABLE [dbo].[Correspondences] (
    [id] int IDENTITY(1,1) NOT NULL,
    [time_placed] datetime  NOT NULL,
    [time_completed] datetime  NULL,
    [summary] nvarchar(max)  NOT NULL,
    [notes] nvarchar(max)  NULL,
    [next_eta] datetime  NULL,
    [followup_notes] nvarchar(max)  NULL,
    [followup_required] bit  NOT NULL,
    [Tenant_id] int  NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [file_data] varbinary(max)  NOT NULL
);
GO

-- Creating table 'FileContainers'
CREATE TABLE [dbo].[FileContainers] (
    [file_name] nvarchar(max)  NOT NULL,
    [date_modified] datetime  NULL,
    [file_id] int  NOT NULL,
    [file_size] bigint  NOT NULL,
    [Tenant_id] int  NULL,
    [Property_id] int  NULL,
    [Vendor_id] int  NULL,
    [HOA_id] int  NULL,
    [Owner_id] int  NULL,
    [PropertyManager_id] int  NULL
);
GO

-- Creating table 'AuditEntries'
CREATE TABLE [dbo].[AuditEntries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [info] nvarchar(max)  NOT NULL,
    [date_entered] datetime  NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [Property_id] int  NULL,
    [Tenant_id] int  NULL,
    [Vendor_id] int  NULL,
    [HOA_id] int  NULL,
    [PropertyManager_id] int  NULL,
    [Owner_id] int  NULL
);
GO

-- Creating table 'OwnersContact'
CREATE TABLE [dbo].[OwnersContact] (
    [OwnersContact_Contact_id] int  NOT NULL,
    [Contacts_id] int  NOT NULL
);
GO

-- Creating table 'VendorsContact'
CREATE TABLE [dbo].[VendorsContact] (
    [VendorsContact_Contact_id] int  NOT NULL,
    [Contacts_id] int  NOT NULL
);
GO

-- Creating table 'HOAsContact'
CREATE TABLE [dbo].[HOAsContact] (
    [HOAsContact_Contact_id] int  NOT NULL,
    [Contacts_id] int  NOT NULL
);
GO

-- Creating table 'PropertyManagersContact'
CREATE TABLE [dbo].[PropertyManagersContact] (
    [PropertyManagersContact_Contact_id] int  NOT NULL,
    [Contacts_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Owners'
ALTER TABLE [dbo].[Owners]
ADD CONSTRAINT [PK_Owners]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [PK_Properties]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tenants'
ALTER TABLE [dbo].[Tenants]
ADD CONSTRAINT [PK_Tenants]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [property_id] in table 'ParkingStalls'
ALTER TABLE [dbo].[ParkingStalls]
ADD CONSTRAINT [PK_ParkingStalls]
    PRIMARY KEY CLUSTERED ([id], [property_id] ASC);
GO

-- Creating primary key on [id] in table 'ServiceCalls'
ALTER TABLE [dbo].[ServiceCalls]
ADD CONSTRAINT [PK_ServiceCalls]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [PK_Vendors]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [property_id] in table 'GateCodes'
ALTER TABLE [dbo].[GateCodes]
ADD CONSTRAINT [PK_GateCodes]
    PRIMARY KEY CLUSTERED ([id], [property_id] ASC);
GO

-- Creating primary key on [id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'HOAs'
ALTER TABLE [dbo].[HOAs]
ADD CONSTRAINT [PK_HOAs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PropertyManagers'
ALTER TABLE [dbo].[PropertyManagers]
ADD CONSTRAINT [PK_PropertyManagers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'HOA_PropertyManagerHistories'
ALTER TABLE [dbo].[HOA_PropertyManagerHistories]
ADD CONSTRAINT [PK_HOA_PropertyManagerHistories]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'UtilitiesPaymentHistories'
ALTER TABLE [dbo].[UtilitiesPaymentHistories]
ADD CONSTRAINT [PK_UtilitiesPaymentHistories]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [PK_LedgerRecords]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PaymentTypes'
ALTER TABLE [dbo].[PaymentTypes]
ADD CONSTRAINT [PK_PaymentTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ChargeTypes'
ALTER TABLE [dbo].[ChargeTypes]
ADD CONSTRAINT [PK_ChargeTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusinessTypes'
ALTER TABLE [dbo].[BusinessTypes]
ADD CONSTRAINT [PK_BusinessTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'UtilitiesTypes'
ALTER TABLE [dbo].[UtilitiesTypes]
ADD CONSTRAINT [PK_UtilitiesTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'DepositTypes'
ALTER TABLE [dbo].[DepositTypes]
ADD CONSTRAINT [PK_DepositTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Correspondences'
ALTER TABLE [dbo].[Correspondences]
ADD CONSTRAINT [PK_Correspondences]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [file_id] in table 'FileContainers'
ALTER TABLE [dbo].[FileContainers]
ADD CONSTRAINT [PK_FileContainers]
    PRIMARY KEY CLUSTERED ([file_id] ASC);
GO

-- Creating primary key on [Id] in table 'AuditEntries'
ALTER TABLE [dbo].[AuditEntries]
ADD CONSTRAINT [PK_AuditEntries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [OwnersContact_Contact_id], [Contacts_id] in table 'OwnersContact'
ALTER TABLE [dbo].[OwnersContact]
ADD CONSTRAINT [PK_OwnersContact]
    PRIMARY KEY CLUSTERED ([OwnersContact_Contact_id], [Contacts_id] ASC);
GO

-- Creating primary key on [VendorsContact_Contact_id], [Contacts_id] in table 'VendorsContact'
ALTER TABLE [dbo].[VendorsContact]
ADD CONSTRAINT [PK_VendorsContact]
    PRIMARY KEY CLUSTERED ([VendorsContact_Contact_id], [Contacts_id] ASC);
GO

-- Creating primary key on [HOAsContact_Contact_id], [Contacts_id] in table 'HOAsContact'
ALTER TABLE [dbo].[HOAsContact]
ADD CONSTRAINT [PK_HOAsContact]
    PRIMARY KEY CLUSTERED ([HOAsContact_Contact_id], [Contacts_id] ASC);
GO

-- Creating primary key on [PropertyManagersContact_Contact_id], [Contacts_id] in table 'PropertyManagersContact'
ALTER TABLE [dbo].[PropertyManagersContact]
ADD CONSTRAINT [PK_PropertyManagersContact]
    PRIMARY KEY CLUSTERED ([PropertyManagersContact_Contact_id], [Contacts_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [property_id] in table 'Tenants'
ALTER TABLE [dbo].[Tenants]
ADD CONSTRAINT [FK_PropertiesTenants]
    FOREIGN KEY ([property_id])
    REFERENCES [dbo].[Properties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertiesTenants'
CREATE INDEX [IX_FK_PropertiesTenants]
ON [dbo].[Tenants]
    ([property_id]);
GO

-- Creating foreign key on [contact_id] in table 'Tenants'
ALTER TABLE [dbo].[Tenants]
ADD CONSTRAINT [FK_ContactTenants]
    FOREIGN KEY ([contact_id])
    REFERENCES [dbo].[Contacts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactTenants'
CREATE INDEX [IX_FK_ContactTenants]
ON [dbo].[Tenants]
    ([contact_id]);
GO

-- Creating foreign key on [OwnersContact_Contact_id] in table 'OwnersContact'
ALTER TABLE [dbo].[OwnersContact]
ADD CONSTRAINT [FK_OwnersContact_Owners]
    FOREIGN KEY ([OwnersContact_Contact_id])
    REFERENCES [dbo].[Owners]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Contacts_id] in table 'OwnersContact'
ALTER TABLE [dbo].[OwnersContact]
ADD CONSTRAINT [FK_OwnersContact_Contact]
    FOREIGN KEY ([Contacts_id])
    REFERENCES [dbo].[Contacts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnersContact_Contact'
CREATE INDEX [IX_FK_OwnersContact_Contact]
ON [dbo].[OwnersContact]
    ([Contacts_id]);
GO

-- Creating foreign key on [VendorsContact_Contact_id] in table 'VendorsContact'
ALTER TABLE [dbo].[VendorsContact]
ADD CONSTRAINT [FK_VendorsContact_Vendors]
    FOREIGN KEY ([VendorsContact_Contact_id])
    REFERENCES [dbo].[Vendors]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Contacts_id] in table 'VendorsContact'
ALTER TABLE [dbo].[VendorsContact]
ADD CONSTRAINT [FK_VendorsContact_Contact]
    FOREIGN KEY ([Contacts_id])
    REFERENCES [dbo].[Contacts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendorsContact_Contact'
CREATE INDEX [IX_FK_VendorsContact_Contact]
ON [dbo].[VendorsContact]
    ([Contacts_id]);
GO

-- Creating foreign key on [HOAsContact_Contact_id] in table 'HOAsContact'
ALTER TABLE [dbo].[HOAsContact]
ADD CONSTRAINT [FK_HOAsContact_HOAs]
    FOREIGN KEY ([HOAsContact_Contact_id])
    REFERENCES [dbo].[HOAs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Contacts_id] in table 'HOAsContact'
ALTER TABLE [dbo].[HOAsContact]
ADD CONSTRAINT [FK_HOAsContact_Contact]
    FOREIGN KEY ([Contacts_id])
    REFERENCES [dbo].[Contacts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HOAsContact_Contact'
CREATE INDEX [IX_FK_HOAsContact_Contact]
ON [dbo].[HOAsContact]
    ([Contacts_id]);
GO

-- Creating foreign key on [PropertyManagersContact_Contact_id] in table 'PropertyManagersContact'
ALTER TABLE [dbo].[PropertyManagersContact]
ADD CONSTRAINT [FK_PropertyManagersContact_PropertyManagers]
    FOREIGN KEY ([PropertyManagersContact_Contact_id])
    REFERENCES [dbo].[PropertyManagers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Contacts_id] in table 'PropertyManagersContact'
ALTER TABLE [dbo].[PropertyManagersContact]
ADD CONSTRAINT [FK_PropertyManagersContact_Contact]
    FOREIGN KEY ([Contacts_id])
    REFERENCES [dbo].[Contacts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyManagersContact_Contact'
CREATE INDEX [IX_FK_PropertyManagersContact_Contact]
ON [dbo].[PropertyManagersContact]
    ([Contacts_id]);
GO

-- Creating foreign key on [property_id] in table 'ServiceCalls'
ALTER TABLE [dbo].[ServiceCalls]
ADD CONSTRAINT [FK_PropertiesServiceCalls]
    FOREIGN KEY ([property_id])
    REFERENCES [dbo].[Properties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertiesServiceCalls'
CREATE INDEX [IX_FK_PropertiesServiceCalls]
ON [dbo].[ServiceCalls]
    ([property_id]);
GO

-- Creating foreign key on [UtilitiesType_id] in table 'UtilitiesPaymentHistories'
ALTER TABLE [dbo].[UtilitiesPaymentHistories]
ADD CONSTRAINT [FK_UtilitiesPaymentHistoryUtilitiesTypes]
    FOREIGN KEY ([UtilitiesType_id])
    REFERENCES [dbo].[UtilitiesTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilitiesPaymentHistoryUtilitiesTypes'
CREATE INDEX [IX_FK_UtilitiesPaymentHistoryUtilitiesTypes]
ON [dbo].[UtilitiesPaymentHistories]
    ([UtilitiesType_id]);
GO

-- Creating foreign key on [property_id] in table 'GateCodes'
ALTER TABLE [dbo].[GateCodes]
ADD CONSTRAINT [FK_PropertiesGateCodes]
    FOREIGN KEY ([property_id])
    REFERENCES [dbo].[Properties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertiesGateCodes'
CREATE INDEX [IX_FK_PropertiesGateCodes]
ON [dbo].[GateCodes]
    ([property_id]);
GO

-- Creating foreign key on [property_id] in table 'ParkingStalls'
ALTER TABLE [dbo].[ParkingStalls]
ADD CONSTRAINT [FK_PropertiesParkingStalls]
    FOREIGN KEY ([property_id])
    REFERENCES [dbo].[Properties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertiesParkingStalls'
CREATE INDEX [IX_FK_PropertiesParkingStalls]
ON [dbo].[ParkingStalls]
    ([property_id]);
GO

-- Creating foreign key on [property_id] in table 'UtilitiesPaymentHistories'
ALTER TABLE [dbo].[UtilitiesPaymentHistories]
ADD CONSTRAINT [FK_PropertiesUtilitiesPaymentHistory]
    FOREIGN KEY ([property_id])
    REFERENCES [dbo].[Properties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertiesUtilitiesPaymentHistory'
CREATE INDEX [IX_FK_PropertiesUtilitiesPaymentHistory]
ON [dbo].[UtilitiesPaymentHistories]
    ([property_id]);
GO

-- Creating foreign key on [tenant_id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_TenantsVehicles]
    FOREIGN KEY ([tenant_id])
    REFERENCES [dbo].[Tenants]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TenantsVehicles'
CREATE INDEX [IX_FK_TenantsVehicles]
ON [dbo].[Vehicles]
    ([tenant_id]);
GO

-- Creating foreign key on [hoa_id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [FK_PropertiesHOAs]
    FOREIGN KEY ([hoa_id])
    REFERENCES [dbo].[HOAs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertiesHOAs'
CREATE INDEX [IX_FK_PropertiesHOAs]
ON [dbo].[Properties]
    ([hoa_id]);
GO

-- Creating foreign key on [BusinessType_id] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [FK_VendorsBusinessTypes]
    FOREIGN KEY ([BusinessType_id])
    REFERENCES [dbo].[BusinessTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendorsBusinessTypes'
CREATE INDEX [IX_FK_VendorsBusinessTypes]
ON [dbo].[Vendors]
    ([BusinessType_id]);
GO

-- Creating foreign key on [DepositType_id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [FK_LedgerRecordDepositTypes]
    FOREIGN KEY ([DepositType_id])
    REFERENCES [dbo].[DepositTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LedgerRecordDepositTypes'
CREATE INDEX [IX_FK_LedgerRecordDepositTypes]
ON [dbo].[LedgerRecords]
    ([DepositType_id]);
GO

-- Creating foreign key on [PaymentType_id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [FK_LedgerRecordPaymentTypes]
    FOREIGN KEY ([PaymentType_id])
    REFERENCES [dbo].[PaymentTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LedgerRecordPaymentTypes'
CREATE INDEX [IX_FK_LedgerRecordPaymentTypes]
ON [dbo].[LedgerRecords]
    ([PaymentType_id]);
GO

-- Creating foreign key on [Tenant_id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [FK_TenantsLedgerRecord]
    FOREIGN KEY ([Tenant_id])
    REFERENCES [dbo].[Tenants]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TenantsLedgerRecord'
CREATE INDEX [IX_FK_TenantsLedgerRecord]
ON [dbo].[LedgerRecords]
    ([Tenant_id]);
GO

-- Creating foreign key on [Owner_id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [FK_OwnersLedgerRecord]
    FOREIGN KEY ([Owner_id])
    REFERENCES [dbo].[Owners]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnersLedgerRecord'
CREATE INDEX [IX_FK_OwnersLedgerRecord]
ON [dbo].[LedgerRecords]
    ([Owner_id]);
GO

-- Creating foreign key on [Vendor_id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [FK_VendorsLedgerRecord]
    FOREIGN KEY ([Vendor_id])
    REFERENCES [dbo].[Vendors]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendorsLedgerRecord'
CREATE INDEX [IX_FK_VendorsLedgerRecord]
ON [dbo].[LedgerRecords]
    ([Vendor_id]);
GO

-- Creating foreign key on [HOA_id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [FK_HOAsLedgerRecord]
    FOREIGN KEY ([HOA_id])
    REFERENCES [dbo].[HOAs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HOAsLedgerRecord'
CREATE INDEX [IX_FK_HOAsLedgerRecord]
ON [dbo].[LedgerRecords]
    ([HOA_id]);
GO

-- Creating foreign key on [PropertyManager_id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [FK_PropertyManagersLedgerRecord]
    FOREIGN KEY ([PropertyManager_id])
    REFERENCES [dbo].[PropertyManagers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyManagersLedgerRecord'
CREATE INDEX [IX_FK_PropertyManagersLedgerRecord]
ON [dbo].[LedgerRecords]
    ([PropertyManager_id]);
GO

-- Creating foreign key on [ChargeType_id] in table 'LedgerRecords'
ALTER TABLE [dbo].[LedgerRecords]
ADD CONSTRAINT [FK_LedgerRecordChargeTypes]
    FOREIGN KEY ([ChargeType_id])
    REFERENCES [dbo].[ChargeTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LedgerRecordChargeTypes'
CREATE INDEX [IX_FK_LedgerRecordChargeTypes]
ON [dbo].[LedgerRecords]
    ([ChargeType_id]);
GO

-- Creating foreign key on [owner_id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [FK_PropertiesOwners]
    FOREIGN KEY ([owner_id])
    REFERENCES [dbo].[Owners]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertiesOwners'
CREATE INDEX [IX_FK_PropertiesOwners]
ON [dbo].[Properties]
    ([owner_id]);
GO

-- Creating foreign key on [vendor_id] in table 'ServiceCalls'
ALTER TABLE [dbo].[ServiceCalls]
ADD CONSTRAINT [FK_VendorServiceCall]
    FOREIGN KEY ([vendor_id])
    REFERENCES [dbo].[Vendors]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendorServiceCall'
CREATE INDEX [IX_FK_VendorServiceCall]
ON [dbo].[ServiceCalls]
    ([vendor_id]);
GO

-- Creating foreign key on [hoa_id] in table 'HOA_PropertyManagerHistories'
ALTER TABLE [dbo].[HOA_PropertyManagerHistories]
ADD CONSTRAINT [FK_HOAHOA_PropertyManagerHistory]
    FOREIGN KEY ([hoa_id])
    REFERENCES [dbo].[HOAs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HOAHOA_PropertyManagerHistory'
CREATE INDEX [IX_FK_HOAHOA_PropertyManagerHistory]
ON [dbo].[HOA_PropertyManagerHistories]
    ([hoa_id]);
GO

-- Creating foreign key on [property_manager_id] in table 'HOA_PropertyManagerHistories'
ALTER TABLE [dbo].[HOA_PropertyManagerHistories]
ADD CONSTRAINT [FK_PropertyManagerHOA_PropertyManagerHistory]
    FOREIGN KEY ([property_manager_id])
    REFERENCES [dbo].[PropertyManagers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyManagerHOA_PropertyManagerHistory'
CREATE INDEX [IX_FK_PropertyManagerHOA_PropertyManagerHistory]
ON [dbo].[HOA_PropertyManagerHistories]
    ([property_manager_id]);
GO

-- Creating foreign key on [Tenant_id] in table 'Correspondences'
ALTER TABLE [dbo].[Correspondences]
ADD CONSTRAINT [FK_TenantCorrespondence]
    FOREIGN KEY ([Tenant_id])
    REFERENCES [dbo].[Tenants]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TenantCorrespondence'
CREATE INDEX [IX_FK_TenantCorrespondence]
ON [dbo].[Correspondences]
    ([Tenant_id]);
GO

-- Creating foreign key on [file_id] in table 'FileContainers'
ALTER TABLE [dbo].[FileContainers]
ADD CONSTRAINT [FK_FileContainerFile]
    FOREIGN KEY ([file_id])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tenant_id] in table 'FileContainers'
ALTER TABLE [dbo].[FileContainers]
ADD CONSTRAINT [FK_TenantFileContainer]
    FOREIGN KEY ([Tenant_id])
    REFERENCES [dbo].[Tenants]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TenantFileContainer'
CREATE INDEX [IX_FK_TenantFileContainer]
ON [dbo].[FileContainers]
    ([Tenant_id]);
GO

-- Creating foreign key on [Property_id] in table 'FileContainers'
ALTER TABLE [dbo].[FileContainers]
ADD CONSTRAINT [FK_PropertyFileContainer]
    FOREIGN KEY ([Property_id])
    REFERENCES [dbo].[Properties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyFileContainer'
CREATE INDEX [IX_FK_PropertyFileContainer]
ON [dbo].[FileContainers]
    ([Property_id]);
GO

-- Creating foreign key on [Vendor_id] in table 'FileContainers'
ALTER TABLE [dbo].[FileContainers]
ADD CONSTRAINT [FK_VendorFileContainer]
    FOREIGN KEY ([Vendor_id])
    REFERENCES [dbo].[Vendors]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendorFileContainer'
CREATE INDEX [IX_FK_VendorFileContainer]
ON [dbo].[FileContainers]
    ([Vendor_id]);
GO

-- Creating foreign key on [HOA_id] in table 'FileContainers'
ALTER TABLE [dbo].[FileContainers]
ADD CONSTRAINT [FK_HOAFileContainer]
    FOREIGN KEY ([HOA_id])
    REFERENCES [dbo].[HOAs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HOAFileContainer'
CREATE INDEX [IX_FK_HOAFileContainer]
ON [dbo].[FileContainers]
    ([HOA_id]);
GO

-- Creating foreign key on [Owner_id] in table 'FileContainers'
ALTER TABLE [dbo].[FileContainers]
ADD CONSTRAINT [FK_OwnerFileContainer]
    FOREIGN KEY ([Owner_id])
    REFERENCES [dbo].[Owners]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnerFileContainer'
CREATE INDEX [IX_FK_OwnerFileContainer]
ON [dbo].[FileContainers]
    ([Owner_id]);
GO

-- Creating foreign key on [PropertyManager_id] in table 'FileContainers'
ALTER TABLE [dbo].[FileContainers]
ADD CONSTRAINT [FK_PropertyManagerFileContainer]
    FOREIGN KEY ([PropertyManager_id])
    REFERENCES [dbo].[PropertyManagers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyManagerFileContainer'
CREATE INDEX [IX_FK_PropertyManagerFileContainer]
ON [dbo].[FileContainers]
    ([PropertyManager_id]);
GO

-- Creating foreign key on [Property_id] in table 'AuditEntries'
ALTER TABLE [dbo].[AuditEntries]
ADD CONSTRAINT [FK_PropertyAuditEntry]
    FOREIGN KEY ([Property_id])
    REFERENCES [dbo].[Properties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyAuditEntry'
CREATE INDEX [IX_FK_PropertyAuditEntry]
ON [dbo].[AuditEntries]
    ([Property_id]);
GO

-- Creating foreign key on [Tenant_id] in table 'AuditEntries'
ALTER TABLE [dbo].[AuditEntries]
ADD CONSTRAINT [FK_TenantAuditEntry]
    FOREIGN KEY ([Tenant_id])
    REFERENCES [dbo].[Tenants]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TenantAuditEntry'
CREATE INDEX [IX_FK_TenantAuditEntry]
ON [dbo].[AuditEntries]
    ([Tenant_id]);
GO

-- Creating foreign key on [Vendor_id] in table 'AuditEntries'
ALTER TABLE [dbo].[AuditEntries]
ADD CONSTRAINT [FK_VendorAuditEntry]
    FOREIGN KEY ([Vendor_id])
    REFERENCES [dbo].[Vendors]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendorAuditEntry'
CREATE INDEX [IX_FK_VendorAuditEntry]
ON [dbo].[AuditEntries]
    ([Vendor_id]);
GO

-- Creating foreign key on [HOA_id] in table 'AuditEntries'
ALTER TABLE [dbo].[AuditEntries]
ADD CONSTRAINT [FK_HOAAuditEntry]
    FOREIGN KEY ([HOA_id])
    REFERENCES [dbo].[HOAs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HOAAuditEntry'
CREATE INDEX [IX_FK_HOAAuditEntry]
ON [dbo].[AuditEntries]
    ([HOA_id]);
GO

-- Creating foreign key on [PropertyManager_id] in table 'AuditEntries'
ALTER TABLE [dbo].[AuditEntries]
ADD CONSTRAINT [FK_PropertyManagerAuditEntry]
    FOREIGN KEY ([PropertyManager_id])
    REFERENCES [dbo].[PropertyManagers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyManagerAuditEntry'
CREATE INDEX [IX_FK_PropertyManagerAuditEntry]
ON [dbo].[AuditEntries]
    ([PropertyManager_id]);
GO

-- Creating foreign key on [Owner_id] in table 'AuditEntries'
ALTER TABLE [dbo].[AuditEntries]
ADD CONSTRAINT [FK_OwnerAuditEntry]
    FOREIGN KEY ([Owner_id])
    REFERENCES [dbo].[Owners]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnerAuditEntry'
CREATE INDEX [IX_FK_OwnerAuditEntry]
ON [dbo].[AuditEntries]
    ([Owner_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------