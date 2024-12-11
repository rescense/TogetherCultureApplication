CREATE TABLE [user] (
    [user_id]       INT           IDENTITY (1, 1) NOT NULL,
    [username]      VARCHAR (50)  NOT NULL,
    [user_type]     VARCHAR (20)  DEFAULT ('non_member') NOT NULL,
    [password]      VARCHAR (50)  NOT NULL,
    [first_name]    VARCHAR (100) NOT NULL,
    [last_name]     VARCHAR (100) NOT NULL,
    [email]         VARCHAR (254) NOT NULL,
    [phone_number]  VARCHAR (15)  NOT NULL,
    [date_of_birth] DATE          NOT NULL,
    [date_joined]   DATE          NOT NULL,
    [Id]            INT           DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC),
    UNIQUE NONCLUSTERED ([email] ASC),
    UNIQUE NONCLUSTERED ([username] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Admin] ([Id]),
    CONSTRAINT [chk_user_type] CHECK ([user_type]='non_member' OR [user_type]='member')
);
GO

CREATE TABLE [documents] (
  [document_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [document_name] VARCHAR(255) NOT NULL,
  [document_type] VARCHAR(100) NOT NULL,
  [upload_date] DATETIME NOT NULL,
  [resource_link] TEXT NULL
);
GO

CREATE TABLE [membership] (
  [membership_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [membership_type] VARCHAR(40) NOT NULL,
  [access_lvl] VARCHAR(20) NOT NULL,
  [price] NUMERIC(19,4) NOT NULL,
  [duration_in_months] INT NOT NULL,
  [discount_rates] DECIMAL(5,2) NOT NULL,
  CONSTRAINT chk_membership_type CHECK ([membership_type] IN ('community_member', 'key_access_member', 'creative_workspace_member')),
  CONSTRAINT chk_access_lvl CHECK ([access_lvl] IN ('member', 'admin'))
);
GO

CREATE TABLE [shop_items] (
  [shop_item_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [item_name] VARCHAR(150) NOT NULL,
  [item_description] TEXT NOT NULL,
  [item_price] NUMERIC(19,4) NOT NULL,
  [item_stock_left] INT NOT NULL
);
GO

CREATE TABLE [event] (
  [event_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [event_name] VARCHAR(254) NOT NULL,
  [date] DATE NOT NULL,
  [time] TIME NOT NULL,
  [location] VARCHAR(254) NOT NULL,
  [ticket_price] NUMERIC(19,4) NOT NULL,
  [maximum_occupancy] INT NOT NULL
);
GO

CREATE TABLE [payments] (
  [payment_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [user_id] INT NULL,
  [payment_date] DATETIME NOT NULL,
  [payment_amount] NUMERIC(19,4) NOT NULL,
  [payment_method] VARCHAR(20) NOT NULL,
  [payment_status] VARCHAR(20) NOT NULL,
  CONSTRAINT chk_payment_method CHECK ([payment_method] IN ('credit_card', 'debit_card', 'paypal')),
  CONSTRAINT chk_payment_status CHECK ([payment_status] IN ('pending_payment', 'processing', 'complete')),
  FOREIGN KEY ([user_id]) REFERENCES [user]([user_id]) ON DELETE SET NULL
);
GO

CREATE TABLE [time_bank] (
  [time_bank_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [user_id] INT NOT NULL,
  [time_offered] TIME NOT NULL DEFAULT '00:00:00',
  [time_requested] TIME NOT NULL DEFAULT '00:00:00',
  [time_balance] TIME NOT NULL DEFAULT '00:00:00',
  [last_updated_date] DATETIME NOT NULL,
  FOREIGN KEY ([user_id]) REFERENCES [user]([user_id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE [user_memberships] (
  [user_membership_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [user_id] INT NOT NULL,
  [membership_id] INT NULL,
  [start_date] DATE NOT NULL,
  [end_date] DATE NOT NULL,
  FOREIGN KEY ([user_id]) REFERENCES [user]([user_id]) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY ([membership_id]) REFERENCES [membership]([membership_id]) ON DELETE SET NULL
);
GO

CREATE TABLE [event_orders] (
  [event_order_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [user_id] INT NOT NULL,
  [event_id] INT NULL,
  [order_date] DATE NOT NULL,
  [total_tickets] INT NOT NULL,
  [total_amount] NUMERIC(19,4) NOT NULL,
  [booking_status] VARCHAR(20) NOT NULL,
  [payment_id] INT NULL,
  CONSTRAINT chk_booking_status CHECK ([booking_status] IN ('pending_payment', 'paid', 'processing', 'delivered', 'complete')),
  FOREIGN KEY ([user_id]) REFERENCES [user]([user_id]) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY ([event_id]) REFERENCES [event]([event_id]) ON DELETE SET NULL,
  FOREIGN KEY ([payment_id]) REFERENCES [payments]([payment_id]) ON DELETE SET NULL
);
GO

CREATE TABLE [shop_orders] (
  [shop_order_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [user_id] INT NOT NULL,
  [order_date] DATE NOT NULL,
  [discount_applied] DECIMAL(5,2) NULL,
  [total_amount] NUMERIC(19,4) NOT NULL,
  [order_status] VARCHAR(20) NOT NULL,
  [shipping_address] VARCHAR(254) NOT NULL,
  [payment_id] INT NULL,
  CONSTRAINT chk_order_status CHECK ([order_status] IN ('pending_payment', 'paid', 'processing', 'delivered', 'complete')),
  FOREIGN KEY ([user_id]) REFERENCES [user]([user_id]) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY ([payment_id]) REFERENCES [payments]([payment_id]) ON DELETE SET NULL
);
GO

CREATE TABLE [skill_share] (
  [skill_share_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [user_id] INT NOT NULL,
  [service_title] VARCHAR(70) NOT NULL,
  [offering_or_requesting] VARCHAR(20) NOT NULL,
  [description] TEXT NOT NULL,
  [time_required] TIME NOT NULL,
  [contact] VARCHAR(255) NOT NULL,
  CONSTRAINT chk_offering_or_requesting CHECK ([offering_or_requesting] IN ('requesting', 'offering')),
  FOREIGN KEY ([user_id]) REFERENCES [user]([user_id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE [event_ticket_booking] (
  [ticket_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [event_order_id] INT NULL,
  [attendee_name] VARCHAR(200) NOT NULL,
  [attendee_type] VARCHAR(20) NOT NULL,
  [ticket_price] NUMERIC(19,4) NOT NULL,
  CONSTRAINT chk_attendee_type CHECK ([attendee_type] IN ('concession', 'full_price', 'member')),
  FOREIGN KEY ([event_order_id]) REFERENCES [event_orders]([event_order_id]) ON DELETE SET NULL
);
GO

CREATE TABLE [shop_item_order_records] (
  [shop_item_order_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [shop_order_id] INT NOT NULL,
  [shop_item_id] INT NOT NULL,
  [quantity] INT NOT NULL,
  [price] NUMERIC(19,4) NOT NULL,
  FOREIGN KEY ([shop_order_id]) REFERENCES [shop_orders]([shop_order_id]) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY ([shop_item_id]) REFERENCES [shop_items]([shop_item_id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE [feedback] (
  [feedback_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [user_id] INT NULL,
  [event_id] INT NULL,
  [rating] INT NOT NULL CHECK(rating >= 0 AND rating <= 5),
  [comment] TEXT NOT NULL,
  [feedback_date] DATE NOT NULL,
  FOREIGN KEY ([user_id]) REFERENCES [user]([user_id]) ON DELETE SET NULL,
  FOREIGN KEY ([event_id]) REFERENCES [event]([event_id]) ON DELETE SET NULL
);
GO

CREATE TABLE [connections_board_post] (
  [post_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [user_id] INT NOT NULL,
  [post_title] VARCHAR(255) NOT NULL,
  [post_content] TEXT NOT NULL,
  [post_date] DATE NOT NULL,
  [document_id] INT NULL,
  [number_of_likes] INT NOT NULL DEFAULT 0,
  [number_of_comments] INT NOT NULL DEFAULT 0,
  FOREIGN KEY ([user_id]) REFERENCES [user]([user_id]) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY ([document_id]) REFERENCES [documents]([document_id]) ON DELETE SET NULL
);
GO

CREATE TABLE [comments] (
  [comment_id] INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
  [post_id] INT NOT NULL,
  [comment_contents] TEXT
  );
GO

CREATE TABLE [Admin] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [first_name] VARCHAR (50) NOT NULL,
    [last_name]  VARCHAR (50) NOT NULL,
    [password]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [admin_approvals] (
    [approval_id] INT IDENTITY (1, 1) NOT NULL,
    [admin_id]    INT NOT NULL,
    [is_approved] BIT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([approval_id] ASC),
    FOREIGN KEY ([admin_id]) REFERENCES [dbo].[Admin] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE [interests] (
    [user_id]  INT           NOT NULL,
    [interest] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC, [interest] ASC),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[user] ([user_id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CHECK ([interest]='working' OR [interest]='experiencing' OR [interest]='creating' OR [interest]='sharing' OR [interest]='caring')
);
GO


