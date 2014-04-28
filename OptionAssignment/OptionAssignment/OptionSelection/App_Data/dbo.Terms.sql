CREATE TABLE [dbo].[Terms] (
    [TermCode]    INT           NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    [IsActive]    BIT           NOT NULL,
    CONSTRAINT [PK_dbo.Terms] PRIMARY KEY CLUSTERED ([TermCode] ASC)
);

