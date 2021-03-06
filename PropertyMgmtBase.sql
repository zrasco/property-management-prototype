USE [PropertyMgmt]
GO
SET IDENTITY_INSERT [dbo].[Owners] ON 

INSERT [dbo].[Owners] ([id], [company_name]) VALUES (1, N'Owner #1')
SET IDENTITY_INSERT [dbo].[Owners] OFF
SET IDENTITY_INSERT [dbo].[HOAs] ON 

INSERT [dbo].[HOAs] ([id], [company_name], [address1], [city], [state], [zip], [phone1], [phone2], [address2], [fax]) VALUES (1, N'Noneya', N'123 HOA Way', N'Las Vegas', N'NV', N'89119', N'702-555-1212', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[HOAs] OFF
SET IDENTITY_INSERT [dbo].[Properties] ON 

INSERT [dbo].[Properties] ([id], [address1], [city], [state], [zip], [address2], [mailbox_info], [owner_pays_utilities], [hoa_id], [owner_id]) VALUES (1, N'2850 Preciso ln1', N'Henderson', N'NV', N'89074', NULL, N'BLAH', 0, 1, 1)
INSERT [dbo].[Properties] ([id], [address1], [city], [state], [zip], [address2], [mailbox_info], [owner_pays_utilities], [hoa_id], [owner_id]) VALUES (2, N'1234 Test way', N'Las Vegas', N'NV', N'89119', NULL, N'BLAH', 0, 1, 1)
INSERT [dbo].[Properties] ([id], [address1], [city], [state], [zip], [address2], [mailbox_info], [owner_pays_utilities], [hoa_id], [owner_id]) VALUES (3, N'5236 Golden ln', N'Las Vegas', N'NV', N'89119', N'Unit B', NULL, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Properties] OFF
SET IDENTITY_INSERT [dbo].[PropertyManagers] ON 

INSERT [dbo].[PropertyManagers] ([id], [company_name], [address1], [city], [state], [zip], [phone1], [phone2], [address2], [fax]) VALUES (1, N'Property Manager #1', N'1234 Properties way', N'Mesquite', N'NV', N'89054', N'775-555-1212', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PropertyManagers] OFF
