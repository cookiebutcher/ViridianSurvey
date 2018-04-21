INSERT INTO "UserAccounts" (
        "UserName",
        --"PasswordHash",
        --"PasswordSalt",
        "FirstName",
        "LastName",
        "Email",
        "CreatedDate",
        "IsActive")
VALUES (
    'test',
    --'hasz',
    --'salt',
    'Janusz',
    'Testowy',
    'test@test.com',
    '2018-04-01',
    1
)

INSERT INTO "Surveys" (
	"AllowBackwardNavigation", 
	"Code", 
	"CreatedById",
       	"CreatedDate",
       	"Description", 
	"EndMessage",
       	"ShowGroupDescription",
       	"ShowGroupName",
       	"ShowProgressBar",
       	"ShowWelcomeScreen",
       	"Title",
       	"WelcomeMessage")
VALUES (
	0,
	'S001',
	1,
	'2017-09-05',
	'descriptionik',
	'end mesedzyk',
	0,
	0,
	0,
	0,
	'titelek',
	'welcome mesedzyk'
)
