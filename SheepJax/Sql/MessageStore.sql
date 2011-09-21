/* This SQL script is required if you use SqlCommandHub (recommended for production, esp. within clustered/web-farm environment) */

create table SheepJaxMessages
(
	MessageId int not null identity,
	ClientId uniqueidentifier not null,
	Message nvarchar(max) not null,
	Timestamp Timestamp not null,
	CreatedUtcTime datetime not null default GetUtcDate(),
	CONSTRAINT [PK_SheepJaxMessages] PRIMARY KEY CLUSTERED 
	(
		MessageId ASC
	)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [ix_Timestamp] ON SheepJaxMessages 
(
	Timestamp ASC
)

CREATE NONCLUSTERED INDEX [ix_ClientId_Timestamp] ON SheepJaxMessages 
(
	ClientId, Timestamp ASC
)

CREATE NONCLUSTERED INDEX [ix_CreatedUtcTime] ON SheepJaxMessages 
(
	CreatedUtcTime ASC
)