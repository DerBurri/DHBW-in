create table dhbwin.[User]
(
    UID
    int
    identity
    constraint
    User_pk
    primary
    key
    nonclustered,
    Firstname
    char
(
    25
),
    Name char
(
    25
),
    [E-Mail] char
(
    50
),
    Street char
(
    25
),
    PLZ_fk int
    constraint PLZ_fk
    references dhbwin.PLZ,
    ExpPoints int,
    PasswordHash char
(
    500
),
    Walletbalance int,
    Profilepicture image
    )
    go

